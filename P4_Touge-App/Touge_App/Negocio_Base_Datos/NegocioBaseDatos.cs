using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo_Clases;

namespace Negocio_Base_Datos
{
    public class NegocioBaseDatos
    {
       
       
        public List<Musica> DevolverCanciones()
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            List<Musica> listaDeCanciones = new List<Musica>();
            
            try
            {
                negocioBD.SQLQuery("select MusicaID, Nombre Cancion, URL Archivo from Musica");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Musica auxiliar = new Musica();
                    auxiliar.IdMusica = (int)negocioBD.Guardador["MusicaID"];
                    auxiliar.NombreCancion = (string)negocioBD.Guardador["Cancion"];
                    auxiliar.CancionURL = (string)negocioBD.Guardador["Archivo"];
                    listaDeCanciones.Add(auxiliar); 
                }
                return listaDeCanciones;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Pistas> DevolverPistas()
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            List<Pistas> listaPistas = new List<Pistas>();
            try
            {
                negocioBD.SQLQuery("select Nombre, Bio Biografia, Distancia, Pais, ModalidadPreferida, Record, Imagenes, Imagen2 from pistas");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Pistas auxiliar = new Pistas();
                    auxiliar.NombrePista = (string)negocioBD.Guardador["Nombre"];
                    auxiliar.BiografiaPista = (string)negocioBD.Guardador["Biografia"];
                    auxiliar.Distancia = (string)negocioBD.Guardador["Distancia"];
                    auxiliar.Pais = (string)negocioBD.Guardador["Pais"];
                    auxiliar.ModalidadPreferida = (string)negocioBD.Guardador["ModalidadPreferida"];
                    auxiliar.Record = (string)negocioBD.Guardador["Record"];
                    auxiliar.Imagenes = (string)negocioBD.Guardador["Imagenes"];
                    auxiliar.Imagenes2 = (string)negocioBD.Guardador["Imagen2"];
                    listaPistas.Add(auxiliar);
                }
                return listaPistas;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Pilotos> DevolverPilotos()
        {
            List<Pilotos> listaPilotos = new List<Pilotos>();
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            try
            {
                negocioBD.SQLQuery("select Nombre, Apodo, Equipo, Ranking, Victorias, Derrotas, PorcentajeCarrerasGanadas WinRate, MayorRival, Altura, Peso, Edad, Bio Biografia, Foto FotoPiloto, Cornering, Braking, Reflexes, TyresManagement, Overtaking, Defending, Rain, Overall, Concentration, Presure, Experience, Agressive, Pace, Nacionalidad, Auto, PilotoID, AutoAtras, AutoDetalle, AutoMovimiento from Pilotos");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Pilotos auxiliar = new Pilotos();
                    auxiliar.NombrePiloto = (string)negocioBD.Guardador["Nombre"];
                    auxiliar.Apodo = (string)negocioBD.Guardador["Apodo"];
                    auxiliar.Equipo = (string)negocioBD.Guardador["Equipo"];
                    auxiliar.Ranking = (string)negocioBD.Guardador["Ranking"];
                    auxiliar.Victorias = (int)negocioBD.Guardador["Victorias"];
                    auxiliar.Derrotas = (int)negocioBD.Guardador["Derrotas"];
                    auxiliar.PorcentajeCarrerasGanadas = (double)negocioBD.Guardador["WinRate"];
                    auxiliar.Rival = (string)negocioBD.Guardador["MayorRival"];
                    auxiliar.Altura = (string)negocioBD.Guardador["Altura"];
                    auxiliar.Peso = (string)negocioBD.Guardador["Peso"];
                    auxiliar.Edad = (int)negocioBD.Guardador["Edad"];
                    auxiliar.Biografia = (string)negocioBD.Guardador["Biografia"];
                    auxiliar.Foto = (string)negocioBD.Guardador["FotoPiloto"];
                    auxiliar.Cornering = (int)negocioBD.Guardador["Cornering"];
                    auxiliar.Braking = (int)negocioBD.Guardador["Braking"];
                    auxiliar.Reflexes = (int)negocioBD.Guardador["Reflexes"];
                    auxiliar.TyresManagement = (int)negocioBD.Guardador["TyresManagement"];
                    auxiliar.Overtaking = (int)negocioBD.Guardador["Overtaking"];
                    auxiliar.Defending = (int)negocioBD.Guardador["Defending"];
                    auxiliar.RainHability = (int)negocioBD.Guardador["Rain"];
                    auxiliar.Concentracion = (int)negocioBD.Guardador["Concentration"];
                    auxiliar.ManejoPresion = (int)negocioBD.Guardador["Presure"];
                    auxiliar.Experiencia = (int)negocioBD.Guardador["Experience"];
                    auxiliar.Agresividad = (int)negocioBD.Guardador["Agressive"];
                    auxiliar.Pace = (int)negocioBD.Guardador["Pace"];
                    auxiliar.Overall = (int)negocioBD.Guardador["Overall"];
                    auxiliar.Nacionalidad = (string)negocioBD.Guardador["Nacionalidad"];
                    auxiliar.Auto = (string)negocioBD.Guardador["Auto"];
                    auxiliar.AutoAtras = (string)negocioBD.Guardador["AutoAtras"];
                    auxiliar.AutoFrontal = (string)negocioBD.Guardador["AutoDetalle"];
                    auxiliar.AutoDriving = (string)negocioBD.Guardador["AutoMovimiento"];
                    auxiliar.IdPiloto = (int)negocioBD.Guardador["PilotoID"];

                    listaPilotos.Add(auxiliar);
                }
                return listaPilotos;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Autos> DevolverAutos()
        {
            List<Autos> listaAutos = new List<Autos>();
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            try
            {
                negocioBD.SQLQuery("select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K, m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5   from Autos a, Marca m where a.Marca = m.ID ");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Autos auxiliar = new Autos();
                    auxiliar.NombreModelo = (string)negocioBD.Guardador["Nom"];
                    auxiliar.Anio = (int)negocioBD.Guardador["An"];
                    auxiliar.Traccion = (string)negocioBD.Guardador["Trac"];
                    auxiliar.PaisFabricacion = (string)negocioBD.Guardador["Pais"];
                    auxiliar.HP = (int)negocioBD.Guardador["HP"];
                    auxiliar.Torque = (int)negocioBD.Guardador["Torque"];
                    auxiliar.Peso = (int)negocioBD.Guardador["Peso"];
                    auxiliar.RelacionPesoPotencia = (double)negocioBD.Guardador["PP"];
                    auxiliar.TopSpeed = (double)negocioBD.Guardador["TS"];
                    auxiliar.Categoria = (string)negocioBD.Guardador["Cat"];
                    auxiliar.Kilometraje = (double)negocioBD.Guardador["K"];
                    auxiliar.ImagenAuto = (string)negocioBD.Guardador["f1"];
                    auxiliar.ImagenAutoSecundaria = (string)negocioBD.Guardador["f2"];
                    auxiliar.ImagenAutoTres = (string)negocioBD.Guardador["f3"];
                    auxiliar.ImagenAutoCuatro = (string)negocioBD.Guardador["f4"];
                    auxiliar.ImagenAutoCinco = (string)negocioBD.Guardador["f5"];
                    auxiliar.MarcaAuto.NombreMarca = (string)negocioBD.Guardador["NM"];
                    auxiliar.MarcaAuto.ImagenMarca = (string)negocioBD.Guardador["IM"];
                    listaAutos.Add(auxiliar);
                }

                return listaAutos;
            }
            catch (Exception)
            {

                throw;
            }    
        }

        public void NombrePiloto(ComboBox combo)
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            try
            {
                negocioBD.SQLQuery("select Nombre from Pilotos");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    string nombre;
                    nombre = (string)negocioBD.Guardador["Nombre"];
                    combo.Items.Add(nombre);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void NombrePista(ComboBox combo)
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            try
            {
                negocioBD.SQLQuery("select nombre from Pistas");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    string nombre;
                    nombre = (string)negocioBD.Guardador["nombre"];
                    combo.Items.Add(nombre);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void NombreAuto(ComboBox combo)
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            try
            {
                negocioBD.SQLQuery("select nombre from Autos");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    string nombre;
                    nombre = (string)negocioBD.Guardador["nombre"];
                    combo.Items.Add(nombre);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Historial> DevolverHistorial() 
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            List<Historial> listaHistorial = new List<Historial>();
            try
            {
                negocioBD.SQLQuery("select Circuito, DriverA, DriverB, PilotoGanador, AutoA, AutoB, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID ID from Historial");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Historial auxiliar = new Historial();
                    auxiliar.Circuito = (string)negocioBD.Guardador["Circuito"];
                    auxiliar.PilotoA = (string)negocioBD.Guardador["DriverA"];
                    auxiliar.PilotoB = (string)negocioBD.Guardador["DriverB"];
                    auxiliar.Ganador = (string)negocioBD.Guardador["PilotoGanador"];
                    auxiliar.Ganador = (string)negocioBD.Guardador["PilotoGanador"];
                    auxiliar.AutoA = (string)negocioBD.Guardador["AutoA"];
                    auxiliar.AutoB = (string)negocioBD.Guardador["AutoB"];
                    auxiliar.Modalidad = (string)negocioBD.Guardador["Modalidad"];
                    auxiliar.Promocion = (string)negocioBD.Guardador["Promocion"];
                    auxiliar.Tiempo = (string)negocioBD.Guardador["Tiempo"];
                    auxiliar.Clase = (string)negocioBD.Guardador["Clase"];
                    auxiliar.Clima = (string)negocioBD.Guardador["Clima"];
                    auxiliar.Id = (int)negocioBD.Guardador["ID"];
                    listaHistorial.Add(auxiliar);
                }
                return listaHistorial;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void InsertarRegistro(Historial aux)
        {
            FuncionesNegocio negociobd = new FuncionesNegocio();
            try
            {
                negociobd.SQLQuery("Insert Into Historial (Circuito, DriverA, DriverB, PilotoGanador, PilotoPerdedor, AutoA, AutoB, Tiempo, Clase, Clima, Modalidad, Promocion) values (@Circuito ,@DriverA, @DriverB, @PilotoGanador, @PilotoPerdedor, @AutoA, @AutoB, @Tiempo,@Clase,@Clima,@Modalidad, @Promocion)");
                negociobd.SetearParametros("@Circuito", aux.Circuito);
                negociobd.SetearParametros("@DriverA", aux.PilotoA);
                negociobd.SetearParametros("@DriverB", aux.PilotoB);
                negociobd.SetearParametros("@PilotoGanador",aux.Ganador);
                negociobd.SetearParametros("@PilotoPerdedor", aux.Perdedor);
                negociobd.SetearParametros("@AutoA", aux.AutoA);
                negociobd.SetearParametros("@AutoB", aux.AutoB);
                negociobd.SetearParametros("@Tiempo", aux.Tiempo);
                negociobd.SetearParametros("@Clase", aux.Clase);
                negociobd.SetearParametros("@Clima", aux.Clima);
                negociobd.SetearParametros("@Modalidad", aux.Modalidad);
                negociobd.SetearParametros("@Promocion", aux.Promocion);
                negociobd.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                negociobd.CerrarConexion();
            }
        }
        
        public void EliminarRegistro(int id)
        {
            FuncionesNegocio eliminar = new FuncionesNegocio();
            try
            {
                eliminar.SQLQuery("delete from Historial where HistorialID = @ID");
                eliminar.SetearParametros("@ID", id);
                eliminar.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarEstadisticas(string Ganador, string Perdedor)
        {
            FuncionesNegocio negocioActualizaStats = new FuncionesNegocio();
            int Derrotas=0;
            int Victorias=0;
            try
            {
                negocioActualizaStats.SQLQuery("select nombre, Victorias, PorcentajeCarrerasGanadas, Derrotas from Pilotos where Nombre = @Win");
                negocioActualizaStats.SetearParametros("@Win", Ganador);
                negocioActualizaStats.LecturaBase();
                if (negocioActualizaStats.Guardador.Read())
                {
                    Victorias = (int)negocioActualizaStats.Guardador["Victorias"] + 1;
                    Derrotas = (int)negocioActualizaStats.Guardador["Derrotas"];
                }
                negocioActualizaStats.SQLQuery("Update Pilotos set Victorias = " + Victorias + "where Nombre =  @Win");
                negocioActualizaStats.Guardador.Close();
                negocioActualizaStats.EjecutarAccion();
                int Total = Victorias + Derrotas;
                float porcentaje = (float)Victorias / Total * 100;
                negocioActualizaStats.SetearParametros("@Float", porcentaje);
                negocioActualizaStats.SQLQuery("Update Pilotos set PorcentajeCarrerasGanadas = @Float where Nombre =  @Win");
                negocioActualizaStats.EjecutarAccion();

                negocioActualizaStats.Guardador.Close();
                negocioActualizaStats.SQLQuery("select nombre, Victorias, PorcentajeCarrerasGanadas, Derrotas from Pilotos where Nombre = @Lose");
                negocioActualizaStats.SetearParametros("@Lose", Perdedor);
                negocioActualizaStats.LecturaBase();
                if (negocioActualizaStats.Guardador.Read())
                {
                    Victorias = (int)negocioActualizaStats.Guardador["Victorias"];
                    Derrotas = (int)negocioActualizaStats.Guardador["Derrotas"]+1;
                }
                negocioActualizaStats.SQLQuery("Update Pilotos set Derrotas = " + Derrotas + "where Nombre =  @Lose");
                negocioActualizaStats.Guardador.Close();
                negocioActualizaStats.EjecutarAccion();
                int TotalCarreras = Victorias + Derrotas;
                float porcentajePerdedor = (float)Victorias / TotalCarreras * 100;
                negocioActualizaStats.SetearParametros("@FloatLoser", porcentajePerdedor);
                negocioActualizaStats.SQLQuery("Update Pilotos set PorcentajeCarrerasGanadas = @FloatLoser where Nombre =  @Lose");
                negocioActualizaStats.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Historial> FiltrarDatosHistorial(string campo, string criterio, string texto)
        {
            List<Historial> listaFiltradaHistorial = new List<Historial>();
            FuncionesNegocio negocioFiltros = new FuncionesNegocio();
            string inyeccion="";
            try
            {
                switch (criterio)
                {
                    case "Empieza Por":
                        inyeccion = "SELECT * FROM (SELECT Circuito, DriverA AS Piloto, DriverB AS Rival, PilotoGanador AS Ganador, PilotoPerdedor AS Perdedor, AutoA AS AutoPiloto, AutoB AS AutoRival, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID AS ID FROM Historial) AS Subquery where " +  campo + " Like '" + texto +"%'";
                        break;
                    case "Contiene":
                        inyeccion = "SELECT * FROM (SELECT Circuito, DriverA AS Piloto, DriverB AS Rival, PilotoGanador AS Ganador, PilotoPerdedor AS Perdedor, AutoA AS AutoPiloto, AutoB AS AutoRival, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID AS ID FROM Historial) AS Subquery where " + campo + " Like '%" + texto + "%'";
                        break;
                    case "Termina Por":
                        inyeccion = "SELECT * FROM (SELECT Circuito, DriverA AS Piloto, DriverB AS Rival, PilotoGanador AS Ganador, PilotoPerdedor AS Perdedor, AutoA AS AutoPiloto, AutoB AS AutoRival, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID AS ID FROM Historial) AS Subquery where " + campo + " Like '%" + texto + "'";
                        break; 
                }
                negocioFiltros.SQLQuery(inyeccion);
                negocioFiltros.LecturaBase();
                while (negocioFiltros.Guardador.Read())
                {
                    Historial auxiliar = new Historial();
                    auxiliar.Circuito = (string)negocioFiltros.Guardador["Circuito"];
                    auxiliar.PilotoA = (string)negocioFiltros.Guardador["Piloto"];
                    auxiliar.PilotoB = (string)negocioFiltros.Guardador["Rival"];
                    auxiliar.Ganador = (string)negocioFiltros.Guardador["Ganador"];
                    auxiliar.Ganador = (string)negocioFiltros.Guardador["Perdedor"];
                    auxiliar.AutoA = (string)negocioFiltros.Guardador["AutoPiloto"];
                    auxiliar.AutoB = (string)negocioFiltros.Guardador["AutoRival"];
                    auxiliar.Modalidad = (string)negocioFiltros.Guardador["Modalidad"];
                    auxiliar.Promocion = (string)negocioFiltros.Guardador["Promocion"];
                    auxiliar.Tiempo = (string)negocioFiltros.Guardador["Tiempo"];
                    auxiliar.Clase = (string)negocioFiltros.Guardador["Clase"];
                    auxiliar.Clima = (string)negocioFiltros.Guardador["Clima"];
                    auxiliar.Id = (int)negocioFiltros.Guardador["ID"];
                    listaFiltradaHistorial.Add(auxiliar);
                }
                return listaFiltradaHistorial;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Fecha DevolverFecha()
        {
            try
            {
                Fecha aux = new Fecha();
                FuncionesNegocio negocioFecha = new FuncionesNegocio();
                negocioFecha.SQLQuery("SELECT IdFecha, FechaManager from Fecha");
                negocioFecha.LecturaBase();
                if (negocioFecha.Guardador.Read())
                {
                    aux.Id = (int)negocioFecha.Guardador["IdFecha"];
                    aux.FechaManager = (DateTime)negocioFecha.Guardador["FechaManager"];
                }
                return aux;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DateTime UpdatearFecha(int dias)
        {
            FuncionesNegocio negocioUpdateFecha = new FuncionesNegocio();
            string inyeccion;
            switch (dias)
            {
                case 1:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 1, FechaManager)";
                    break;
                case 2:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 2, FechaManager)";
                    break;
                case 3:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 3, FechaManager)";
                    break;
                case 5:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 5, FechaManager)";
                    break;
                case 6:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 14, FechaManager)";
                    break;
                default:
                    inyeccion = "UPDATE Fecha SET FechaManager = DATEADD(day, 0, FechaManager)";
                    break;
            }
            negocioUpdateFecha.SQLQuery(inyeccion);
            negocioUpdateFecha.EjecutarAccion();

            negocioUpdateFecha.SQLQuery("SELECT IdFecha, FechaManager from Fecha");
            negocioUpdateFecha.LecturaBase();
            DateTime aux = DateTime.Now;
            if (negocioUpdateFecha.Guardador.Read())
            {
                aux = (DateTime)negocioUpdateFecha.Guardador["FechaManager"];
            }
            return aux;
        }

        public List<Alquiler> DevolverAlquiler(bool EstadoAlquiler, int numeroAlquiler = 0)
        {
            List<Alquiler> listaAlquiler = new List<Alquiler>();
            FuncionesNegocio negocioBaseAlquiler = new FuncionesNegocio();
            List<int> listaNumerosRandoms = new List<int>();
            int listado = 0;
            try
            {
                if (EstadoAlquiler)
                {
                    //numeroAlquiler = 1;
                    negocioBaseAlquiler.SQLQuery("SELECT NumeroRegistro from alquileres where NumeroRegistro != @Alquilado");
                    negocioBaseAlquiler.SetearParametros("@Alquilado", numeroAlquiler);
                    negocioBaseAlquiler.LecturaBase();
                    while (negocioBaseAlquiler.Guardador.Read())
                    {
                        listado++;
                    }
                    listado++;
                    negocioBaseAlquiler.Guardador.Close();
                    listaNumerosRandoms = RandomNumeros(EstadoAlquiler, listado, numeroAlquiler);
                }
                if (numeroAlquiler != 0)
                {
                    negocioBaseAlquiler.SQLQuery("SELECT NumeroRegistro, Precio, Dormitorios, SalasDeEstar, Garajes, Duchas, NombreAlquiler, ImagenAlquiler, Estado from alquileres where NumeroRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @Seis)");
                    negocioBaseAlquiler.SetearParametros("@Uno", listaNumerosRandoms[0]);
                    negocioBaseAlquiler.SetearParametros("@Dos", listaNumerosRandoms[1]);
                    negocioBaseAlquiler.SetearParametros("@Tres", listaNumerosRandoms[2]);
                    negocioBaseAlquiler.SetearParametros("@Cuatro", listaNumerosRandoms[3]);
                    negocioBaseAlquiler.SetearParametros("@Cinco", listaNumerosRandoms[4]);
                    negocioBaseAlquiler.SetearParametros("@Seis", listaNumerosRandoms[5]);
                    negocioBaseAlquiler.LecturaBase();
                    while (negocioBaseAlquiler.Guardador.Read())
                    {
                        Alquiler aux = new Alquiler();
                        aux.NumeroRegistro = (int)negocioBaseAlquiler.Guardador["NumeroRegistro"];
                        aux.CantidadDormitorios = (int)negocioBaseAlquiler.Guardador["Dormitorios"];
                        aux.CantidadDuchas = (int)negocioBaseAlquiler.Guardador["Duchas"];
                        aux.CantidadGarajes = (int)negocioBaseAlquiler.Guardador["Garajes"];
                        aux.CantidadSalasEstar = (int)negocioBaseAlquiler.Guardador["SalasDeEstar"];
                        aux.PrecioDepartamento = (int)negocioBaseAlquiler.Guardador["Precio"];
                        aux.Estado = (bool)negocioBaseAlquiler.Guardador["Estado"];
                        aux.NombreAlquiler = (string)negocioBaseAlquiler.Guardador["NombreAlquiler"];
                        aux.ImagenAlquiler = (string)negocioBaseAlquiler.Guardador["ImagenAlquiler"];
                        listaAlquiler.Add(aux);
                    }
                }
                return listaAlquiler;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<int> RandomNumeros(bool EstadoAlquiler, int lista, int numeroAlquiler=0)
        {
            List<int> listaNumeros = new List<int>();
            Random numerosRandom = new Random();
            if (EstadoAlquiler)
            {
                listaNumeros.Add(numeroAlquiler);
                int x = 0;
                int y=0;
                int[] listaRepetidos = new int[5];
                bool Norepetido = true;
                for (int i = 0; i < 5; i++)
                {
                    listaRepetidos[i] = -1;
                }
                while (x!=5)
                { 
                    y = (int)numerosRandom.Next(1, lista);
                    
                    if ( y!=numeroAlquiler && numeroAlquiler!=0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (y== listaRepetidos[i])
                            {
                                Norepetido = false;
                                break;
                            }
                        }
                        if (Norepetido)
                        {
                            listaRepetidos[x] = y;
                            listaNumeros.Add(y);
                            x++;
                        }
                        else
                        {
                            Norepetido = true;
                        }
                        

                    }
                    
                } 
            }
            return listaNumeros;
        }
    }
}
