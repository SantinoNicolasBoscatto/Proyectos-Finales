using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModeloDeDominio;

namespace ClaseNegocio
{
    public class ConexionPokemonDataBase
    {
        int contadorListaPokebichos = 0;
        public List<Pokemon> ListarPokemon()
        {
            ConexionDBCentralizada ConexionCentral = new ConexionDBCentralizada();
            List<Pokemon> listaDePokemones = new List<Pokemon>();
            
            try
            {
                //ConexionCentral.SQLQuery("select Numero, Nombre, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, Ataque Ataque, Defensa,HP, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, EntradaPokedex, Sonidos from POKEMONS P, ELEMENTOS E, ELEMENTOS D where IdDebilidad = D.Id AND IdTipo = E.Id Order BY Numero");
                ConexionCentral.SQLQuery("select Numero, Nombre, UrlImagen, E.TipoImagen Tipo, F.TipoImagen TipoSecundario, D.Descripcion Debilidad, Ataque, Defensa,HP, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, EntradaPokedex, Sonidos, E.Id IdTipo, D.Id IdDebilidad, F.Id IdTipoDos, P.Id IdPoke from POKEMONS P, ELEMENTOS E, ELEMENTOS D, ELEMENTOS F where IdDebilidad = D.Id AND IdTipo = E.Id AND IdTipo2 = F.Id Order By Numero");
                ConexionCentral.EjecutarLecturaDeTabla();               
                while (ConexionCentral.GuardadorCentralDeDatosSQLAcceso.Read())
                {
                    Pokemon auxiliar = new Pokemon();
                    auxiliar.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["IdPoke"];
                    auxiliar.NumeroPokedex = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Numero"];
                    auxiliar.Nombre = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Nombre"];
                    if(!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["UrlImagen"] is DBNull))
                    auxiliar.Sprite = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["UrlImagen"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Tipo"] is DBNull))
                    {
                        auxiliar.TipoDeElemento.ImagenTipo = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Tipo"];
                        auxiliar.TipoDeElemento.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["IdTipo"];
                        //auxiliar.TipoDeElemento.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Tipo"];
                    }
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["TipoSecundario"] is DBNull))
                    {
                        auxiliar.TipoDeElemento2.ImagenTipo = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["TipoSecundario"];
                        auxiliar.TipoDeElemento2.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["IdTipoDos"];
                       // auxiliar.TipoDeElemento2.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["TipoSecundario"];
                    }
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Debilidad"] is DBNull))
                    {
                        auxiliar.Debilidad.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Debilidad"];
                        auxiliar.Debilidad.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["IdDebilidad"];

                    }
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["HP"] is DBNull))
                    {
                        auxiliar.EstadisticasBase.HP = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["HP"];
                        auxiliar.EstadisticasBase.Ataque = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Ataque"];
                        auxiliar.EstadisticasBase.Defensa = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Defensa"];
                        auxiliar.EstadisticasBase.AtaqueEspecial = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["AtaqueEspecial"];
                        auxiliar.EstadisticasBase.DefensaEspecial = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["DefensaEspecial"];
                        auxiliar.EstadisticasBase.Velocidad = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Velocidad"];
                    }
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Imagen3d"] is DBNull))
                       auxiliar.Sprite3d = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Imagen3d"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["EntradaPokedex"] is DBNull))
                        auxiliar.DescripcionDePokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["EntradaPokedex"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Sonidos"] is DBNull))
                        auxiliar.GritoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Sonidos"];
                    listaDePokemones.Add(auxiliar);
                    contadorListaPokebichos++;
                }
                return listaDePokemones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexionCentral.CerrarConexion();
            }
        }
        public void AgregarPokemon(Pokemon nuevoPokemon)
        {
            ConexionDBCentralizada ConexionBase = new ConexionDBCentralizada();
            try
            {
                ConexionBase.SQLQuery("Insert Into POKEMONS(Numero, Nombre, EntradaPokedex, Activo, IdTipo, UrlImagen, HP, Ataque, Defensa, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, Sonidos, IdTipo2, IdDebilidad) values(@Numero, @Nombre, @EntradaPokedex, 1, @IdTipo, @UrlImagen, @HP, @Ataque, @Defensa, @AtaqueEsp, @DefensaEsp, @Velocidad, @Imagen3d, @Grito, @IdTipo2, @IdDebilidad)");
                ConexionBase.SetearParametrosSQL("@Numero", nuevoPokemon.NumeroPokedex);
                ConexionBase.SetearParametrosSQL("@Nombre", nuevoPokemon.Nombre);
                ConexionBase.SetearParametrosSQL("@EntradaPokedex", nuevoPokemon.DescripcionDePokemon);
                ConexionBase.SetearParametrosSQL("@UrlImagen", nuevoPokemon.Sprite);
                ConexionBase.SetearParametrosSQL("@HP", nuevoPokemon.EstadisticasBase.HP);
                ConexionBase.SetearParametrosSQL("@Ataque", nuevoPokemon.EstadisticasBase.Ataque);
                ConexionBase.SetearParametrosSQL("@Defensa", nuevoPokemon.EstadisticasBase.Defensa);
                ConexionBase.SetearParametrosSQL("@AtaqueEsp", nuevoPokemon.EstadisticasBase.AtaqueEspecial);
                ConexionBase.SetearParametrosSQL("@DefensaEsp", nuevoPokemon.EstadisticasBase.DefensaEspecial);
                ConexionBase.SetearParametrosSQL("@Velocidad", nuevoPokemon.EstadisticasBase.Velocidad);
                ConexionBase.SetearParametrosSQL("@Imagen3d", nuevoPokemon.Sprite3d);
                ConexionBase.SetearParametrosSQL("@Grito", nuevoPokemon.GritoPokemon);
                ConexionBase.SetearParametrosSQL("@IdTipo", nuevoPokemon.TipoDeElemento.Id);
                ConexionBase.SetearParametrosSQL("@IdTipo2", nuevoPokemon.TipoDeElemento2.Id);
                ConexionBase.SetearParametrosSQL("@IdDebilidad", nuevoPokemon.Debilidad.Id);
                ConexionBase.EjecutarInsertar();
            }
            catch (Exception ex)
            {        
                throw ex;
            }
            finally
            {
                ConexionBase.CerrarConexion();
            }
        }   
        public List<Tipo> ListarTipo()
        {
            int x=0;
            ConexionDBCentralizada ConexionCentral = new ConexionDBCentralizada();   
            List<Tipo> listaDeTipo = new List<Tipo>();
            try
            {    
                ConexionCentral.SQLQuery("Select Id, Descripcion, TipoImagen from ELEMENTOS");
                ConexionCentral.EjecutarLecturaDeTabla();
                while (ConexionCentral.GuardadorCentralDeDatosSQLAcceso.Read()&& x<17)
                {
                    Tipo aux = new Tipo();
                    aux.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Id"];
                    aux.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Descripcion"];
                    listaDeTipo.Add(aux);
                    x++;
                    //aux.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["TipoImagen"];
                }
                return listaDeTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexionCentral.CerrarConexion();
            }
        }
        public List<Tipo> ListarTipoSecundario()
        {
            ConexionDBCentralizada ConexionCentral = new ConexionDBCentralizada();
            List<Tipo> listaDeTipo = new List<Tipo>();
            try
            {
                ConexionCentral.SQLQuery("Select Id, Descripcion, TipoImagen from ELEMENTOS");
                ConexionCentral.EjecutarLecturaDeTabla();
                while (ConexionCentral.GuardadorCentralDeDatosSQLAcceso.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Id"];
                    aux.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Descripcion"];
                    listaDeTipo.Add(aux);
                }
                return listaDeTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexionCentral.CerrarConexion();
            }
        }

        public void ModificarPokemon(Pokemon mod)
        {
            ConexionDBCentralizada conexionDeMod = new ConexionDBCentralizada();
            conexionDeMod.SQLQuery("Update POKEMONS set Numero = @Numero, Nombre =@Nombre, EntradaPokedex = @EntradaPokedex, UrlImagen=@UrlImagen, IdTipo=@IdTipo, IdTipo2=@IdTipo2, Ataque=@Ataque, Defensa=@Defensa,HP=@HP,AtaqueEspecial=@EspAt,DefensaEspecial = @EspDef, Velocidad = @Velocidad, IdDebilidad = @IdDebilidad, Imagen3d = @Imagen3d, Sonidos = @Sonidos where Id = @Id");
            conexionDeMod.SetearParametrosSQL("@Numero", mod.NumeroPokedex);
            conexionDeMod.SetearParametrosSQL("@Nombre", mod.Nombre);
            conexionDeMod.SetearParametrosSQL("@EntradaPokedex", mod.DescripcionDePokemon);
            conexionDeMod.SetearParametrosSQL("@UrlImagen", mod.Sprite);
            conexionDeMod.SetearParametrosSQL("@IdTipo", mod.TipoDeElemento.Id);
            conexionDeMod.SetearParametrosSQL("@IdTipo2", mod.TipoDeElemento2.Id);
            conexionDeMod.SetearParametrosSQL("@Ataque", mod.EstadisticasBase.Ataque);
            conexionDeMod.SetearParametrosSQL("@Defensa", mod.EstadisticasBase.Defensa);
            conexionDeMod.SetearParametrosSQL("@HP", mod.EstadisticasBase.HP);
            conexionDeMod.SetearParametrosSQL("@EspAt", mod.EstadisticasBase.AtaqueEspecial);
            conexionDeMod.SetearParametrosSQL("@EspDef", mod.EstadisticasBase.DefensaEspecial);
            conexionDeMod.SetearParametrosSQL("@Velocidad", mod.EstadisticasBase.Velocidad);
            conexionDeMod.SetearParametrosSQL("@IdDebilidad", mod.Debilidad.Id);
            conexionDeMod.SetearParametrosSQL("@Imagen3d",mod.Sprite3d);
            //conexionDeMod.SetearParametrosSQL("@Sonidos", mod.GritoPokemon);
            conexionDeMod.SetearParametrosSQL("@Id", mod.Id);
            conexionDeMod.EjecutarInsertar();
        }
        public int PokeBichosConta()
        {
            return contadorListaPokebichos++;
        }
    }
}
