using EventBus.Commands;
using EventBus.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBus.Implements
{
    public class RabbitEventBus : IRabbitEventBus
    {
        private readonly IMediator _mediator;
        // En manejadores registraremos como KEY el nombre del evento y como Type el tipo del manejador
        private readonly Dictionary<string, List<Type>> _manejadores;
        private readonly List<Type> _eventTypes;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _config;


        public RabbitEventBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory, IConfiguration config)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _manejadores = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _config = config;
        }


        public async Task Publish<T>(T evento) where T : EventBase.EventBase
        {
            // Crearemos una conexion con nuestro server de RabbitMQ
            var factory = new ConnectionFactory() { HostName = _config["Rabbit-Connection"]! };
            using (var connection = await factory.CreateConnectionAsync())
            {
                using (var channel = await connection.CreateChannelAsync())
                {
                    // Definire el nombre de mi Evento y Luego este sera el nombre de mi Queue, si no existe creara el Queue
                    // y si existe agregara el evento a la cola del Queue
                    var eventName = evento.GetType().Name;
                    await channel.QueueDeclareAsync(eventName, false, false, false, null);

                    // Convertiremos el Objeto EVENTO en un Mensaje JSON que se enviara al Event-Bus, realizando el Publish
                    var message = JsonConvert.SerializeObject(evento);
                    var body = Encoding.UTF8.GetBytes(message);
                    await channel.BasicPublishAsync(exchange: "", routingKey: eventName, body: body, CancellationToken.None);
                }
            }

        }

        // T es un Evento y TH es un Manejador de Eventos
        public async Task Suscribe<T, TH>() where T : EventBase.EventBase where TH : IEventHandler<T>
        {
            // Aqui capturamos el evento y su manejador, verificaremos si estos existen o no en la lista de eventos y manejadores
            var eventName = typeof(T).Name;
            var manejadorEventoType = typeof(TH);
            if (!_eventTypes.Contains(typeof(T))) _eventTypes.Add(typeof(T));
            if (!_manejadores.ContainsKey(eventName)) _manejadores.Add(eventName, new List<Type>());

            // Verifico que no haya una misma Key en el diccionario
            if (_manejadores[eventName].Any(x => x.GetType() == manejadorEventoType))
                throw new ArgumentException($"El handler {manejadorEventoType.Name} fue registrado anteriormente por {eventName}");

            _manejadores[eventName].Add(manejadorEventoType);

            // Creo una conexion con RabbitMQ y agrego el EventName a la cola
            var cadena = _config["Rabbit-Connection"]!;
            var factory = new ConnectionFactory() { HostName = cadena };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(eventName, false, false, false, null);

            // Creo el CONSUMER
            var consumer = new AsyncEventingBasicConsumer(channel);
            // Este delegate sera el encargado de leer los mensajes del QUEUE
            consumer.ReceivedAsync += Consumer_Delegate;

            // Realizare el consumo de los QUEUE del event-bus
            await channel.BasicConsumeAsync(eventName, true, consumer);
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }

        // Este metodo sera el encargado de disparar el Handler
        private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
        {
            // Capturo el nombre del evento y formateo su informacion en un string
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if (_manejadores.ContainsKey(eventName))
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var subscriptions = _manejadores[eventName];
                        foreach (var sb in subscriptions)
                        {
                            // Este metodo permitira que los Handlers puedan inyectar objetos por el constructor
                            var handler = scope.ServiceProvider.GetService(sb); //Activator.CreateInstance(sb);
                            if (handler == null) continue;
                            var eventType = _eventTypes.SingleOrDefault(x => x.Name == eventName);
                            var @event = JsonConvert.DeserializeObject(message, eventType!);

                            // Obtengo el Type de mi interfaz IEventHandler y lo utilizo para invocar su metodo Handle usando Reflection
                            var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType!);
                            await (Task)concreteType.GetMethod("Handle")!.Invoke(handler, new object[] { @event! })!;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
