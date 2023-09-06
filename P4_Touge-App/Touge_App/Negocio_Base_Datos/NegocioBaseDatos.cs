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

        public List<Historial> DevolverHistorial() 
        {
            FuncionesNegocio negocioBD = new FuncionesNegocio();
            List<Historial> listaHistorial = new List<Historial>();
            try
            {
                negocioBD.SQLQuery("select Circuito, DriverA, DriverB, PilotoGanador, AutoA, AutoB, Promocion, Tiempo, Clase, Clima, Modalidad from Historial");
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
    }
}
