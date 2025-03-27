using Grpc.Core.Interceptors;
using Grpc.Core;
using PruebaMicroservicios.Autor.Application.Common.Validators;

namespace PruebaMicroservicios.Autor.Presentation.Common.Exceptions
{
    public class GlobalExceptionHandler : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await base.UnaryServerHandler(request, context, continuation);
            }
            catch (ValidationExceptionCustom ex)
            {
                var serverResponse = new ServerResponse
                {
                    IsSuccess = false,
                    Message = "Errores en la ejecucion",
                    Errors = String.Join("; ", ex.Errors)
                };
                return MapResponse<TRequest, TResponse>(serverResponse);
            }
        }

        private TResponse MapResponse<TRequest, TResponse>(ServerResponse serverResponse)
        {
            var response = Activator.CreateInstance<TResponse>();
            SetNestedPropertyValue(response, "Response.IsSuccess", serverResponse.IsSuccess);
            SetNestedPropertyValue(response, "Response.Message", serverResponse.Message);
            SetNestedPropertyValue(response, "Response.Errors", serverResponse.Errors);
            return response;
        }

        private static void SetNestedPropertyValue<T>(T obj, string propertyPath, object value)
        {
            if (obj == null || string.IsNullOrEmpty(propertyPath))
            {
                throw new ArgumentNullException(nameof(obj), "El objeto o ruta de la propiedad no pueden ser nulls");
            }

            var properties = propertyPath.Split('.');
            var currentObject = (object)obj;

            for (int i = 0; i < properties.Length; i++)
            {
                var propertyName = properties[i];
                var property = currentObject!.GetType().GetProperty(propertyName);
                if (property == null)
                {
                    throw new ArgumentException($"La propiedad {propertyName} no existe en el objeto {currentObject.GetType().Name}");
                }

                if (i == properties.Length - 1)
                {
                    property.SetValue(currentObject, value);
                }
                else
                {
                    var nextObject = property.GetValue(currentObject);
                    if (nextObject == null)
                    {
                        nextObject = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(currentObject, nextObject);
                    }
                    currentObject = nextObject;
                }
            }
        }
    }
}
