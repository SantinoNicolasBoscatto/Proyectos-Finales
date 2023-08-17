using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
