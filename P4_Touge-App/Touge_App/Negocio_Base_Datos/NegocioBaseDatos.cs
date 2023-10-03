using System;
using System.Collections.Generic;
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
                    Musica auxiliar = new Musica
                    {
                        IdMusica = (int)negocioBD.Guardador["MusicaID"],
                        NombreCancion = (string)negocioBD.Guardador["Cancion"],
                        CancionURL = (string)negocioBD.Guardador["Archivo"]
                    };
                    listaDeCanciones.Add(auxiliar); 
                }
                negocioBD.Guardador.Close();
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
                    Pistas auxiliar = new Pistas
                    {
                        NombrePista = (string)negocioBD.Guardador["Nombre"],
                        BiografiaPista = (string)negocioBD.Guardador["Biografia"],
                        Distancia = (string)negocioBD.Guardador["Distancia"],
                        Pais = (string)negocioBD.Guardador["Pais"],
                        ModalidadPreferida = (string)negocioBD.Guardador["ModalidadPreferida"],
                        Record = (string)negocioBD.Guardador["Record"],
                        Imagenes = (string)negocioBD.Guardador["Imagenes"],
                        Imagenes2 = (string)negocioBD.Guardador["Imagen2"]
                    };
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
                    Pilotos auxiliar = new Pilotos
                    {
                        NombrePiloto = (string)negocioBD.Guardador["Nombre"],
                        Apodo = (string)negocioBD.Guardador["Apodo"],
                        Equipo = (string)negocioBD.Guardador["Equipo"],
                        Ranking = (string)negocioBD.Guardador["Ranking"],
                        Victorias = (int)negocioBD.Guardador["Victorias"],
                        Derrotas = (int)negocioBD.Guardador["Derrotas"],
                        PorcentajeCarrerasGanadas = (double)negocioBD.Guardador["WinRate"],
                        Rival = (string)negocioBD.Guardador["MayorRival"],
                        Altura = (string)negocioBD.Guardador["Altura"],
                        Peso = (string)negocioBD.Guardador["Peso"],
                        Edad = (int)negocioBD.Guardador["Edad"],
                        Biografia = (string)negocioBD.Guardador["Biografia"],
                        Foto = (string)negocioBD.Guardador["FotoPiloto"],
                        Cornering = (int)negocioBD.Guardador["Cornering"],
                        Braking = (int)negocioBD.Guardador["Braking"],
                        Reflexes = (int)negocioBD.Guardador["Reflexes"],
                        TyresManagement = (int)negocioBD.Guardador["TyresManagement"],
                        Overtaking = (int)negocioBD.Guardador["Overtaking"],
                        Defending = (int)negocioBD.Guardador["Defending"],
                        RainHability = (int)negocioBD.Guardador["Rain"],
                        Concentracion = (int)negocioBD.Guardador["Concentration"],
                        ManejoPresion = (int)negocioBD.Guardador["Presure"],
                        Experiencia = (int)negocioBD.Guardador["Experience"],
                        Agresividad = (int)negocioBD.Guardador["Agressive"],
                        Pace = (int)negocioBD.Guardador["Pace"],
                        Overall = (int)negocioBD.Guardador["Overall"],
                        Nacionalidad = (string)negocioBD.Guardador["Nacionalidad"],
                        Auto = (string)negocioBD.Guardador["Auto"],
                        AutoAtras = (string)negocioBD.Guardador["AutoAtras"],
                        AutoFrontal = (string)negocioBD.Guardador["AutoDetalle"],
                        AutoDriving = (string)negocioBD.Guardador["AutoMovimiento"],
                        IdPiloto = (int)negocioBD.Guardador["PilotoID"]
                    };
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
                negocioBD.SQLQuery("select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K, m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5, Aspiracion Asp, IdealHP as IHP   from Autos a, Marca m where a.Marca = m.ID ");
                negocioBD.LecturaBase();
                while (negocioBD.Guardador.Read())
                {
                    Autos auxiliar = new Autos
                    {
                        NombreModelo = (string)negocioBD.Guardador["Nom"],
                        Anio = (int)negocioBD.Guardador["An"],
                        Traccion = (string)negocioBD.Guardador["Trac"],
                        PaisFabricacion = (string)negocioBD.Guardador["Pais"],
                        HP = (int)negocioBD.Guardador["IHP"],
                        Torque = (int)negocioBD.Guardador["Torque"],
                        Peso = (int)negocioBD.Guardador["Peso"],
                        RelacionPesoPotencia = (double)negocioBD.Guardador["PP"],
                        TopSpeed = (double)negocioBD.Guardador["TS"],
                        Categoria = (string)negocioBD.Guardador["Cat"],
                        Kilometraje = (double)negocioBD.Guardador["K"],
                        ImagenAuto = (string)negocioBD.Guardador["f1"],
                        ImagenAutoSecundaria = (string)negocioBD.Guardador["f2"],
                        ImagenAutoTres = (string)negocioBD.Guardador["f3"],
                        ImagenAutoCuatro = (string)negocioBD.Guardador["f4"],
                        ImagenAutoCinco = (string)negocioBD.Guardador["f5"],
                        Aspiracion = (string)negocioBD.Guardador["Asp"]
                    };
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
                    Historial auxiliar = new Historial
                    {
                        Circuito = (string)negocioBD.Guardador["Circuito"],
                        PilotoA = (string)negocioBD.Guardador["DriverA"],
                        PilotoB = (string)negocioBD.Guardador["DriverB"],
                        Ganador = (string)negocioBD.Guardador["PilotoGanador"]
                    };
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
                    Historial auxiliar = new Historial
                    {
                        Circuito = (string)negocioFiltros.Guardador["Circuito"],
                        PilotoA = (string)negocioFiltros.Guardador["Piloto"],
                        PilotoB = (string)negocioFiltros.Guardador["Rival"],
                        Ganador = (string)negocioFiltros.Guardador["Ganador"],
                        Perdedor = (string)negocioFiltros.Guardador["Perdedor"],
                        AutoA = (string)negocioFiltros.Guardador["AutoPiloto"],
                        AutoB = (string)negocioFiltros.Guardador["AutoRival"],
                        Modalidad = (string)negocioFiltros.Guardador["Modalidad"],
                        Promocion = (string)negocioFiltros.Guardador["Promocion"],
                        Tiempo = (string)negocioFiltros.Guardador["Tiempo"],
                        Clase = (string)negocioFiltros.Guardador["Clase"],
                        Clima = (string)negocioFiltros.Guardador["Clima"],
                        Id = (int)negocioFiltros.Guardador["ID"]
                        //Revisar
                    };
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
                    negocioBaseAlquiler.SQLQuery("SELECT NumeroRegistro from alquileres where NumeroRegistro != @Alquilado");
                    negocioBaseAlquiler.SetearParametros("@Alquilado", numeroAlquiler);
                    negocioBaseAlquiler.LecturaBase();
                    while (negocioBaseAlquiler.Guardador.Read())
                    {
                        listado++;
                    }
                    listado++;
                    negocioBaseAlquiler.Guardador.Close();
                    listaNumerosRandoms = RandomNumeros(listado, numeroAlquiler);
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
                        Alquiler aux = new Alquiler
                        {
                            NumeroRegistro = (int)negocioBaseAlquiler.Guardador["NumeroRegistro"],
                            CantidadDormitorios = (int)negocioBaseAlquiler.Guardador["Dormitorios"],
                            CantidadDuchas = (int)negocioBaseAlquiler.Guardador["Duchas"],
                            CantidadGarajes = (int)negocioBaseAlquiler.Guardador["Garajes"],
                            CantidadSalasEstar = (int)negocioBaseAlquiler.Guardador["SalasDeEstar"],
                            PrecioDepartamento = (int)negocioBaseAlquiler.Guardador["Precio"],
                            Estado = (bool)negocioBaseAlquiler.Guardador["Estado"],
                            NombreAlquiler = (string)negocioBaseAlquiler.Guardador["NombreAlquiler"],
                            ImagenAlquiler = (string)negocioBaseAlquiler.Guardador["ImagenAlquiler"]
                        };
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

        public List<int> RandomNumeros(int lista, int numeroAlquiler=0)
        {
            List<int> listaNumeros = new List<int>();
            Random numerosRandom = new Random();
            listaNumeros.Add(numeroAlquiler);
            int x = 0;
            int y;
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

            return listaNumeros;
        }

        public int DevolverDinero()
        {
            FuncionesNegocio negocioMoney = new FuncionesNegocio();
            int dinero = 0;
            try
            {
                negocioMoney.SQLQuery("select Dinero from Economia");
                negocioMoney.LecturaBase();
                if (negocioMoney.Guardador.Read())
                {
                    dinero = (int)negocioMoney.Guardador["Dinero"];
                }
                return dinero;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int PagoAlquiler(int Id)
        {
            FuncionesNegocio negocioMoney = new FuncionesNegocio();
            try
            {
                negocioMoney.SQLQuery("select Precio from Alquileres where NumeroRegistro = @MyId");
                negocioMoney.SetearParametros("@MyId", Id);
                negocioMoney.LecturaBase();
                int pago = 0;
                if (negocioMoney.Guardador.Read())
                {
                    pago = (int)negocioMoney.Guardador["Precio"];
                }
                return pago;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarDinero(int Dinero)
        {
            FuncionesNegocio negocioDinero = new FuncionesNegocio();
            try
            {
                negocioDinero.SQLQuery("UPDATE Economia SET Dinero = @Dinero");
                negocioDinero.SetearParametros("@Dinero", Dinero);
                negocioDinero.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int LeerCasaAlquilada()
        {
            FuncionesNegocio negocioAlquiler = new FuncionesNegocio();
            try
            {
                negocioAlquiler.SQLQuery("select CasaAlquilada from AlquilerManager");
                negocioAlquiler.LecturaBase();
                int devolver = 0;
                if (negocioAlquiler.Guardador.Read())
                {
                    devolver = (int)negocioAlquiler.Guardador["CasaAlquilada"];
                }
                return devolver;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool LeerBanderaAlquiler()
        {
            FuncionesNegocio negocioAlquiler = new FuncionesNegocio();
            try
            {
                negocioAlquiler.SQLQuery("select alquilando from AlquilerManager");
                negocioAlquiler.LecturaBase();
                bool devolver = false;
                if (negocioAlquiler.Guardador.Read())
                {
                    devolver = (bool)negocioAlquiler.Guardador["alquilando"];
                }
                return devolver;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ActualizarCasaAlquilada(int CasaAlquilada)
        {
            FuncionesNegocio negocioAlquiler = new FuncionesNegocio();
            try
            {
                negocioAlquiler.SQLQuery("UPDATE AlquilerManager SET CasaAlquilada = @CasaParametro");
                negocioAlquiler.SetearParametros("@CasaParametro", CasaAlquilada);
                negocioAlquiler.EjecutarAccion();
                return CasaAlquilada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizarAlquilando(bool alquilando)
        {
            FuncionesNegocio negocioDinero = new FuncionesNegocio();
            try
            {
                negocioDinero.SQLQuery("UPDATE AlquilerManager SET alquilando = @Estado");
                negocioDinero.SetearParametros("@Estado", alquilando);
                negocioDinero.EjecutarAccion();
                return alquilando;
            }
            catch (Exception)
            {

                throw;
            }
        }

        readonly List<int> bolsaEnterosRopa = new List<int>(); //Revisar
        public List<Ropa> DevolverRopa()
        {
            List<Ropa> listaRopa = new List<Ropa>();
            FuncionesNegocio negocioRopa = new FuncionesNegocio();
            List<int> ropaId;
            int auxiliar;    
            try
            {
                negocioRopa.SQLQuery("select NumeroDeRegistro, Comprado from Ropa where Comprado !=0");
                negocioRopa.LecturaBase();
                while (negocioRopa.Guardador.Read())
                {
                    auxiliar = (int)negocioRopa.Guardador["NumeroDeRegistro"];
                    bolsaEnterosRopa.Add(auxiliar);
                }
                negocioRopa.Guardador.Close();
                ropaId = PoolObjetos(bolsaEnterosRopa.Count, bolsaEnterosRopa);
                if (ropaId.Count>=16)
                {
                    negocioRopa.SetearParametros("@Uno", ropaId[0]);
                    negocioRopa.SetearParametros("@Dos", ropaId[1]);
                    negocioRopa.SetearParametros("@Tres", ropaId[2]);
                    negocioRopa.SetearParametros("@Cuatro", ropaId[3]);
                    negocioRopa.SetearParametros("@Cinco", ropaId[4]);
                    negocioRopa.SetearParametros("@6", ropaId[5]);
                    negocioRopa.SetearParametros("@7", ropaId[6]);
                    negocioRopa.SetearParametros("@8", ropaId[7]);
                    negocioRopa.SetearParametros("@9", ropaId[8]);
                    negocioRopa.SetearParametros("@10", ropaId[9]);
                    negocioRopa.SetearParametros("@11", ropaId[10]);
                    negocioRopa.SetearParametros("@12", ropaId[11]);
                    negocioRopa.SetearParametros("@13", ropaId[12]);
                    negocioRopa.SetearParametros("@14", ropaId[13]);
                    negocioRopa.SetearParametros("@15", ropaId[14]);
                    negocioRopa.SetearParametros("@16", ropaId[15]);
                    negocioRopa.SQLQuery("select NumeroDeRegistro, NombreRopa, ImagenRopa, Precio, Comprado from Ropa where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)");
                    negocioRopa.LecturaBase();
                    while (negocioRopa.Guardador.Read())
                    {
                        Ropa aux = new Ropa
                        {
                            Id = (int)negocioRopa.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioRopa.Guardador["Precio"],
                            NombreRopa = (string)negocioRopa.Guardador["NombreRopa"],
                            Imagen = (string)negocioRopa.Guardador["ImagenRopa"],
                            Comprado = (bool)negocioRopa.Guardador["Comprado"]
                        };
                        listaRopa.Add(aux);
                    }
                }
                else if (ropaId.Count>=8)
                {
                    negocioRopa.SetearParametros("@Uno", ropaId[0]);
                    negocioRopa.SetearParametros("@Dos", ropaId[1]);
                    negocioRopa.SetearParametros("@Tres", ropaId[2]);
                    negocioRopa.SetearParametros("@Cuatro", ropaId[3]);
                    negocioRopa.SetearParametros("@Cinco", ropaId[4]);
                    negocioRopa.SetearParametros("@6", ropaId[5]);
                    negocioRopa.SetearParametros("@7", ropaId[6]);
                    negocioRopa.SetearParametros("@8", ropaId[7]);
                    negocioRopa.SQLQuery("select NumeroDeRegistro, NombreRopa, ImagenRopa, Precio, Comprado from Ropa where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8)");
                    negocioRopa.LecturaBase();
                    while (negocioRopa.Guardador.Read())
                    {
                        Ropa aux = new Ropa
                        {
                            Id = (int)negocioRopa.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioRopa.Guardador["Precio"],
                            NombreRopa = (string)negocioRopa.Guardador["NombreRopa"],
                            Imagen = (string)negocioRopa.Guardador["ImagenRopa"],
                            Comprado = (bool)negocioRopa.Guardador["Comprado"]
                        };
                        listaRopa.Add(aux);
                    }
                }
                return listaRopa;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<int> PoolObjetos(int tamanioBolsa, List<int> bolsaObjetos)
        {
            List<int> listaNumeros = new List<int>();
            Random numerosRandom = new Random();
            int x = 0;
            int y;
            while (x != 16 && tamanioBolsa>0)
            {
                y = (int)numerosRandom.Next(0, tamanioBolsa);
                listaNumeros.Add(bolsaObjetos[y]);
                bolsaObjetos.Remove(bolsaObjetos[y]);
                tamanioBolsa = bolsaObjetos.Count;
                x++;
            }
            return listaNumeros;
        }

        readonly List<int> bolsaEnterosMuebles = new List<int>(); //Asignacion
        public List<Mueble> DevolverMuebles()
        {
            List<Mueble> listaMueble = new List<Mueble>();
            FuncionesNegocio negocioMueble = new FuncionesNegocio();
            List<int> muebleId;
            int auxiliar; //AsignacionCorreccion
            try
            {
                negocioMueble.SQLQuery("select NumeroDeRegistro, Comprado from Muebles where Comprado !=0");
                negocioMueble.LecturaBase();
                while (negocioMueble.Guardador.Read())
                {
                    auxiliar = (int)negocioMueble.Guardador["NumeroDeRegistro"];
                    bolsaEnterosMuebles.Add(auxiliar);
                }
                negocioMueble.Guardador.Close();
                muebleId = PoolObjetos(bolsaEnterosMuebles.Count, bolsaEnterosMuebles);
                if (muebleId.Count >= 16)
                {
                    negocioMueble.SetearParametros("@Uno", muebleId[0]);
                    negocioMueble.SetearParametros("@Dos", muebleId[1]);
                    negocioMueble.SetearParametros("@Tres", muebleId[2]);
                    negocioMueble.SetearParametros("@Cuatro", muebleId[3]);
                    negocioMueble.SetearParametros("@Cinco", muebleId[4]);
                    negocioMueble.SetearParametros("@6", muebleId[5]);
                    negocioMueble.SetearParametros("@7", muebleId[6]);
                    negocioMueble.SetearParametros("@8", muebleId[7]);
                    negocioMueble.SetearParametros("@9", muebleId[8]);
                    negocioMueble.SetearParametros("@10", muebleId[9]);
                    negocioMueble.SetearParametros("@11", muebleId[10]);
                    negocioMueble.SetearParametros("@12", muebleId[11]);
                    negocioMueble.SetearParametros("@13", muebleId[12]);
                    negocioMueble.SetearParametros("@14", muebleId[13]);
                    negocioMueble.SetearParametros("@15", muebleId[14]);
                    negocioMueble.SetearParametros("@16", muebleId[15]);
                    negocioMueble.SQLQuery("select NumeroDeRegistro, Precio, NombreMueble, ImagenMueble, Comprado from Muebles where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)");
                    negocioMueble.LecturaBase();
                    while (negocioMueble.Guardador.Read())
                    {
                        Mueble aux = new Mueble
                        {
                            Id = (int)negocioMueble.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioMueble.Guardador["Precio"],
                            NombreMueble = (string)negocioMueble.Guardador["NombreMueble"],
                            Imagen = (string)negocioMueble.Guardador["ImagenMueble"],
                            Comprado = (bool)negocioMueble.Guardador["Comprado"]
                        };
                        listaMueble.Add(aux);
                    }
                }
                else if (muebleId.Count >= 8)
                {
                    negocioMueble.SetearParametros("@Uno", muebleId[0]);
                    negocioMueble.SetearParametros("@Dos", muebleId[1]);
                    negocioMueble.SetearParametros("@Tres", muebleId[2]);
                    negocioMueble.SetearParametros("@Cuatro", muebleId[3]);
                    negocioMueble.SetearParametros("@Cinco", muebleId[4]);
                    negocioMueble.SetearParametros("@6", muebleId[5]);
                    negocioMueble.SetearParametros("@7", muebleId[6]);
                    negocioMueble.SetearParametros("@8", muebleId[7]);
                    negocioMueble.SQLQuery("select NumeroDeRegistro, Precio, NombreMueble, ImagenMueble, Comprado from Muebles where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8)");
                    negocioMueble.LecturaBase();
                    while (negocioMueble.Guardador.Read())
                    {
                        Mueble aux = new Mueble
                        {
                            Id = (int)negocioMueble.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioMueble.Guardador["Precio"],
                            NombreMueble = (string)negocioMueble.Guardador["NombreMueble"],
                            Imagen = (string)negocioMueble.Guardador["ImagenMueble"],
                            Comprado = (bool)negocioMueble.Guardador["Comprado"]
                        };
                        listaMueble.Add(aux);
                    }
                }
                return listaMueble;
            }
            catch (Exception)
            {

                throw;
            }
        }

        readonly List<int> bolsaEnterosElectros = new List<int>();
        public List<Electronicos> DevolverElectros()
        {
            List<Electronicos> listaElectro = new List<Electronicos>();
            FuncionesNegocio negocioElectro = new FuncionesNegocio();
            List<int> ElectroId;
            int auxiliar; //AsignacionCorreccion
            try
            {
                negocioElectro.SQLQuery("select NumeroDeRegistro, Comprado from Electronicos where Comprado !=0");
                negocioElectro.LecturaBase();
                while (negocioElectro.Guardador.Read())
                {
                    auxiliar = (int)negocioElectro.Guardador["NumeroDeRegistro"];
                    bolsaEnterosElectros.Add(auxiliar);
                }
                negocioElectro.Guardador.Close();
                ElectroId = PoolObjetos(bolsaEnterosElectros.Count, bolsaEnterosElectros);
                if (ElectroId.Count >= 16)
                {
                    negocioElectro.SetearParametros("@Uno", ElectroId[0]);
                    negocioElectro.SetearParametros("@Dos", ElectroId[1]);
                    negocioElectro.SetearParametros("@Tres", ElectroId[2]);
                    negocioElectro.SetearParametros("@Cuatro", ElectroId[3]);
                    negocioElectro.SetearParametros("@Cinco", ElectroId[4]);
                    negocioElectro.SetearParametros("@6", ElectroId[5]);
                    negocioElectro.SetearParametros("@7", ElectroId[6]);
                    negocioElectro.SetearParametros("@8", ElectroId[7]);
                    negocioElectro.SetearParametros("@9", ElectroId[8]);
                    negocioElectro.SetearParametros("@10", ElectroId[9]);
                    negocioElectro.SetearParametros("@11", ElectroId[10]);
                    negocioElectro.SetearParametros("@12", ElectroId[11]);
                    negocioElectro.SetearParametros("@13", ElectroId[12]);
                    negocioElectro.SetearParametros("@14", ElectroId[13]);
                    negocioElectro.SetearParametros("@15", ElectroId[14]);
                    negocioElectro.SetearParametros("@16", ElectroId[15]);
                    negocioElectro.SQLQuery("select NumeroDeRegistro, Precio, NombreElectronico, ImagenElectronico, Comprado from Electronicos where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)");
                    negocioElectro.LecturaBase();
                    while (negocioElectro.Guardador.Read())
                    {
                        Electronicos aux = new Electronicos
                        {
                            Id = (int)negocioElectro.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioElectro.Guardador["Precio"],
                            NombreElectronicos = (string)negocioElectro.Guardador["NombreElectronico"],
                            Imagen = (string)negocioElectro.Guardador["ImagenElectronico"],
                            Comprado = (bool)negocioElectro.Guardador["Comprado"]
                        };
                        listaElectro.Add(aux);
                    }
                }
                else if (ElectroId.Count >= 8)
                {
                    negocioElectro.SetearParametros("@Uno", ElectroId[0]);
                    negocioElectro.SetearParametros("@Dos", ElectroId[1]);
                    negocioElectro.SetearParametros("@Tres", ElectroId[2]);
                    negocioElectro.SetearParametros("@Cuatro", ElectroId[3]);
                    negocioElectro.SetearParametros("@Cinco", ElectroId[4]);
                    negocioElectro.SetearParametros("@6", ElectroId[5]);
                    negocioElectro.SetearParametros("@7", ElectroId[6]);
                    negocioElectro.SetearParametros("@8", ElectroId[7]);
                    negocioElectro.SQLQuery("select NumeroDeRegistro, Precio, NombreElectronico, ImagenElectronico, Comprado from Electronicos where NumeroDeRegistro IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8)");
                    negocioElectro.LecturaBase();
                    while (negocioElectro.Guardador.Read())
                    {
                        Electronicos aux = new Electronicos
                        {
                            Id = (int)negocioElectro.Guardador["NumeroDeRegistro"],
                            Precio = (int)negocioElectro.Guardador["Precio"],
                            NombreElectronicos = (string)negocioElectro.Guardador["NombreElectronico"],
                            Imagen = (string)negocioElectro.Guardador["ImagenElectronico"],
                            Comprado = (bool)negocioElectro.Guardador["Comprado"]
                        };
                        listaElectro.Add(aux);
                    }
                }
                return listaElectro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int PagoArticulos(int Id, int Panel) //1 Ropa, 2 Muebles, 3 Electro, 4 Comida, 5 Higiene
        {
            FuncionesNegocio negocioMoney = new FuncionesNegocio();
            string inyectarQuery;
            switch (Panel)
            {
                case 1:
                    inyectarQuery = "select Precio from Ropa where NumeroDeRegistro = @MyId";
                    break;
                case 2:
                    inyectarQuery = "select Precio from Muebles where NumeroDeRegistro = @MyId";
                    break;
                case 3:
                    inyectarQuery = "select Precio from Electronicos where NumeroDeRegistro = @MyId";
                    break;
                case 4:
                    inyectarQuery = "select Precio from Comida where NumeroDeRegistro = @MyId";
                    break;
                case 5:
                    inyectarQuery = "select Precio from Higiene where NumeroDeRegistro = @MyId";
                    break;
                default:
                    inyectarQuery = "select Precio from Comida where NumeroDeRegistro = @MyId";
                    break;
            }
            try
            {
                negocioMoney.SQLQuery(inyectarQuery);
                negocioMoney.SetearParametros("@MyId", Id);
                negocioMoney.LecturaBase();
                int pago = 0;
                if (negocioMoney.Guardador.Read())
                {
                    pago = (int)negocioMoney.Guardador["Precio"];
                }
                return pago;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeshabilitarArticulo(int id, int Panel)
        {
            FuncionesNegocio negocioMoney = new FuncionesNegocio();
            string inyectarQuery;
            switch (Panel)
            {
                case 1:
                    inyectarQuery = "update Ropa Set Comprado = 0 where NumeroDeRegistro = @MyId";
                    break;
                case 2:
                    inyectarQuery = "update Muebles Set Comprado = 0 where NumeroDeRegistro = @MyId";
                    break;
                case 3:
                    inyectarQuery = "update Electronicos Set Comprado = 0 where NumeroDeRegistro = @MyId";
                    break;
                default:
                    inyectarQuery = "select Precio from Ropa where NumeroDeRegistro = @MyId";
                    break;
            }
            try
            {
                negocioMoney.SQLQuery(inyectarQuery);
                negocioMoney.SetearParametros("@MyId", id);
                negocioMoney.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool LeerBanderaFacturas()
        {
            FuncionesNegocio negocioFacturas = new FuncionesNegocio();
            try
            {
                negocioFacturas.SQLQuery("select EstadoFactura from factura");
                negocioFacturas.LecturaBase();
                bool devolver = false;
                if (negocioFacturas.Guardador.Read())
                {
                    devolver = (bool)negocioFacturas.Guardador["EstadoFactura"];
                }
                return devolver;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizarFactura(bool factura)
        {
            FuncionesNegocio negocioDinero = new FuncionesNegocio();
            try
            {
                negocioDinero.SQLQuery("UPDATE Factura SET EstadoFactura = @Factura");
                negocioDinero.SetearParametros("@Factura", factura);
                negocioDinero.EjecutarAccion();
                return factura;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Comida> DevolverComida()
        {
            FuncionesNegocio negocioComida = new FuncionesNegocio();
            List<Comida> listaComida = new List<Comida>();
            try
            {
                negocioComida.SQLQuery("select NumeroDeRegistro, NombrePack, ImagenPack, Precio, PackComprado from Comida");
                negocioComida.LecturaBase();
                while (negocioComida.Guardador.Read())
                {
                    Comida auxComida = new Comida
                    {
                        Id = (int)negocioComida.Guardador["NumeroDeRegistro"],
                        NombrePack = (string)negocioComida.Guardador["NombrePack"],
                        Imagen = (string)negocioComida.Guardador["ImagenPack"],
                        Precio = (int)negocioComida.Guardador["Precio"],
                        Comprado = (bool)negocioComida.Guardador["PackComprado"]
                    };
                    listaComida.Add(auxComida);
                }
                return listaComida;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool LeerBanderaComida()
        {
            FuncionesNegocio negocioComida = new FuncionesNegocio();
            try
            {
                negocioComida.SQLQuery("select CompraMensual from ComidaManager");
                negocioComida.LecturaBase();
                bool devolver = false;
                if (negocioComida.Guardador.Read())
                {
                    devolver = (bool)negocioComida.Guardador["CompraMensual"];
                }
                return devolver;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizarComida(bool estado)
        {
            FuncionesNegocio negocioDinero = new FuncionesNegocio();
            try
            {
                negocioDinero.SQLQuery("UPDATE ComidaManager SET CompraMensual = @estado");
                negocioDinero.SetearParametros("@estado", estado);
                negocioDinero.EjecutarAccion();
                return estado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Higiene> DevolverHigiene()
        {
            FuncionesNegocio negocioHigiene = new FuncionesNegocio();
            List<Higiene> List = new List<Higiene>();
            try
            {
                negocioHigiene.SQLQuery("select NumeroDeRegistro, NombrePackHigiene, ImagenHigiene, Precio, Comprado from Higiene");
                negocioHigiene.LecturaBase();
                while (negocioHigiene.Guardador.Read())
                {
                    Higiene auxH = new Higiene
                    {
                        Id = (int)negocioHigiene.Guardador["NumeroDeRegistro"],
                        NombrePack = (string)negocioHigiene.Guardador["NombrePackHigiene"],
                        Imagen = (string)negocioHigiene.Guardador["ImagenHigiene"],
                        Precio = (int)negocioHigiene.Guardador["Precio"],
                        Comprado = (bool)negocioHigiene.Guardador["Comprado"]
                    };
                    List.Add(auxH);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int LeerHigieneMes()
        {
            FuncionesNegocio negocioHigiene = new FuncionesNegocio();
            int resultado=-1;
            try
            {
                negocioHigiene.SQLQuery("select Estado from HigieneManager");
                negocioHigiene.LecturaBase();
                if (negocioHigiene.Guardador.Read())
                {
                     resultado = (int)negocioHigiene.Guardador["Estado"];
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ActualizarHigieneManager(int numeroMes)
        {
            FuncionesNegocio negocioDinero = new FuncionesNegocio();
            try
            {
                negocioDinero.SQLQuery("UPDATE HigieneManager SET Estado = @Estado");
                negocioDinero.SetearParametros("@Estado", numeroMes);
                negocioDinero.EjecutarAccion();
                return numeroMes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Autos DevolverMiAuto()
        {
            FuncionesNegocio miAutoNegocio = new FuncionesNegocio();
            miAutoNegocio.SQLQuery("select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K, m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5, a.Tanque Tanq, a.Aspiracion Asp, a.IdealHp as IHP  from Autos a, Marca m where a.Marca = m.ID AND Dueno = 1 ");
            try
            {
                miAutoNegocio.LecturaBase();
                if (miAutoNegocio.Guardador.Read())
                {
                    Autos auxiliar = new Autos
                    {
                        NombreModelo = (string)miAutoNegocio.Guardador["Nom"],
                        Anio = (int)miAutoNegocio.Guardador["An"],
                        Tanque = (int)miAutoNegocio.Guardador["Tanq"],
                        Traccion = (string)miAutoNegocio.Guardador["Trac"],
                        PaisFabricacion = (string)miAutoNegocio.Guardador["Pais"],
                        HP = (int)miAutoNegocio.Guardador["HP"],
                        Torque = (int)miAutoNegocio.Guardador["Torque"],
                        Peso = (int)miAutoNegocio.Guardador["Peso"],
                        RelacionPesoPotencia = (double)miAutoNegocio.Guardador["PP"],
                        TopSpeed = (double)miAutoNegocio.Guardador["TS"],
                        Categoria = (string)miAutoNegocio.Guardador["Cat"],
                        Kilometraje = (double)miAutoNegocio.Guardador["K"],
                        ImagenAuto = (string)miAutoNegocio.Guardador["f1"],
                        ImagenAutoSecundaria = (string)miAutoNegocio.Guardador["f2"],
                        ImagenAutoTres = (string)miAutoNegocio.Guardador["f3"],
                        ImagenAutoCuatro = (string)miAutoNegocio.Guardador["f4"],
                        ImagenAutoCinco = (string)miAutoNegocio.Guardador["f5"],
                        Aspiracion = (string)miAutoNegocio.Guardador["Asp"]
                    };
                    return auxiliar;
                }
                else
                {
                    Autos error = new Autos();
                    return error;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void UpdatearComponentes(int aceite, int Motor, int ManAuto, int Gomas)
        {
            FuncionesNegocio negocioComponentes = new FuncionesNegocio();
            try
            {
                negocioComponentes.SQLQuery("UPDATE estadoAutoManager set Aceite = @Aceite");
                negocioComponentes.SetearParametros("@Aceite", aceite);
                negocioComponentes.EjecutarAccion();
                negocioComponentes.SQLQuery("UPDATE estadoAutoManager set Motor = @Motor");
                negocioComponentes.SetearParametros("@Motor", Motor);
                negocioComponentes.EjecutarAccion();
                negocioComponentes.SQLQuery("UPDATE estadoAutoManager set ManAuto = @ManAuto");
                negocioComponentes.SetearParametros("@ManAuto", ManAuto);
                negocioComponentes.EjecutarAccion();
                negocioComponentes.SQLQuery("UPDATE estadoAutoManager set gomas = @gomas");
                negocioComponentes.SetearParametros("@gomas", Gomas);
                negocioComponentes.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void UpEstadoAuto(int componente, int peso=0)
        {
            FuncionesNegocio negocioAuto = new FuncionesNegocio();
            string inyeccion = "";
            string inyeccion2 = "";
            string inyeccion3 = "";
            try
            {
                switch (componente)
                {
                    case 1:
                        inyeccion = "UPDATE MiAuto set Aceite = 0";
                        inyeccion2 = "UPDATE Autos set HP = HP*0.95 where dueno = 1";
                        break;
                    case 2:
                        inyeccion = "UPDATE MiAuto set Motor = 0";
                        inyeccion2 = "UPDATE Autos set HP = HP*0.95 where dueno = 1";
                        break;
                    case 3:
                        inyeccion = "UPDATE MiAuto set Mantenimiento = 0";
                        inyeccion2 = "UPDATE Autos set HP = HP*0.97 where dueno = 1";
                        break;
                    case 4:
                        inyeccion = "UPDATE MiAuto set Repro = 1";
                        inyeccion2 = "UPDATE Autos set HP = HP*1.1 where dueno = 1";
                        inyeccion3 = "UPDATE Autos set IdealHP = IdealHP*1.1 where dueno = 1";
                        break;
                    case 5:
                        inyeccion = "UPDATE MiAuto set Turbo = 1";
                        inyeccion2 = "UPDATE Autos set HP = HP*1.2 where dueno = 1";
                        inyeccion3 = "UPDATE Autos set IdealHP = IdealHP*1.2 where dueno = 1";
                        break;
                    case 6:
                        inyeccion = "UPDATE MiAuto set AWD = 1";
                        inyeccion2 = "UPDATE Autos set Traccion = @parametro where dueno = 1";
                        negocioAuto.SetearParametros("@parametro", "AWD");
                        break;
                    case 7:
                        inyeccion = "UPDATE MiAuto set Aceite = 1";
                        inyeccion2 = "UPDATE Autos set HP = HP*1.0535 where dueno = 1";
                        break;
                    case 8:
                        inyeccion = "UPDATE MiAuto set Motor = 1";
                        inyeccion2 = "UPDATE Autos set HP = HP*1.0535 where dueno = 1";
                        break;
                    case 9:
                        inyeccion = "UPDATE MiAuto set Mantenimiento = 1";
                        inyeccion2 = "UPDATE Autos set HP = HP*1.0335 where dueno = 1";
                        break;
                    case 10:
                        inyeccion = "UPDATE Autos set HP = IdealHp where dueno = 1";
                        break;
                    case 11:
                        inyeccion = "UPDATE Autos set Peso = @Peso where dueno = 1";
                        peso--;
                        negocioAuto.SetearParametros("@Peso", peso);
                        break;
                    default:
                        break;
                }
                negocioAuto.SQLQuery(inyeccion);
                negocioAuto.EjecutarAccion();
                if (componente!=10 && componente!= 11)
                {
                    negocioAuto.SQLQuery(inyeccion2);
                    negocioAuto.EjecutarAccion();
                }
                if (componente==4 || componente == 5)
                {
                    negocioAuto.SQLQuery(inyeccion3);
                    negocioAuto.EjecutarAccion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<int> devolverEstadoComponentes()
        {
            FuncionesNegocio negociobd = new FuncionesNegocio();
            List<int> estadoManager = new List<int>();
            negociobd.SQLQuery("select Aceite, Motor, ManAuto, Gomas From estadoAutoManager");
            negociobd.LecturaBase();
            if (negociobd.Guardador.Read())
            {
                estadoManager.Add((int)negociobd.Guardador["Aceite"]);
                estadoManager.Add((int)negociobd.Guardador["Motor"]);
                estadoManager.Add((int)negociobd.Guardador["ManAuto"]);
                estadoManager.Add((int)negociobd.Guardador["Gomas"]);
            }
            return estadoManager;
        }

        public bool DevolverEstadosAuto(int numero)
        {
            string inyeccion="";
            bool devolver=false;
            FuncionesNegocio funciondb = new FuncionesNegocio();
            switch (numero)
            {
                case 1:
                    inyeccion = "select Aceite as vari From MiAuto";
                    break;
                case 2:
                    inyeccion = "select Motor as vari From MiAuto";
                    break;
                case 3:
                    inyeccion = "select Mantenimiento as vari From MiAuto";
                    break;
                case 4:
                    inyeccion = "select Repro as vari From MiAuto";
                    break;
                case 5:
                    inyeccion = "select Turbo as vari From MiAuto";
                    break;
                case 6:
                    inyeccion = "select AWD as vari From MiAuto";
                    break;
                case 7:
                    inyeccion = "select Sucio as vari From MiAuto";
                    break;
            }
            funciondb.SQLQuery(inyeccion);
            funciondb.LecturaBase();
            if (funciondb.Guardador.Read())
            {
                devolver = (bool)funciondb.Guardador["vari"];
            }
            return devolver;
        }

        public void UpdateMiAuto (string dato, int managerUpdate)
        {
            string inyeccion = "";
            FuncionesNegocio negocioUp = new FuncionesNegocio();
            switch (managerUpdate)
            {
                case 1:
                    inyeccion = "UPDATE Autos set Aspiracion = @dato where Dueno = 1";
                    negocioUp.SetearParametros("@dato", dato);
                    break;
                case 2:
                    inyeccion = "UPDATE Autos set Traccion = @dato where Dueno = 1";
                    negocioUp.SetearParametros("@dato", dato);
                    break;
            }
            negocioUp.SQLQuery(inyeccion);
            negocioUp.EjecutarAccion();
        }

        public void UpPesoPotencia ()
        {
            FuncionesNegocio negocioKg = new FuncionesNegocio();
            int HP=0;
            int Peso =0;
            negocioKg.SQLQuery("Select Peso, HP From Autos where dueno = 1");
            negocioKg.LecturaBase();
            if (negocioKg.Guardador.Read())
            {
                HP = (int)negocioKg.Guardador["HP"];
                Peso = (int)negocioKg.Guardador["Peso"];
            }
            negocioKg.Guardador.Close();
            float resultado = (float) Peso / HP;
            negocioKg.SQLQuery("Update Autos set PesoPotencia = @Resultado where dueno = 1");
            negocioKg.SetearParametros("@Resultado", resultado);
            negocioKg.EjecutarAccion();
        }


    }
}
