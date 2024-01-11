using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDominio;

namespace NegocioConDB
{
    public class NegocioProductos
    {
        //La funcion listar en general se centra en devolver una Lista De X Objeto, para esto llamamos al Accesso central de
        //BD, al SQLquery para darle la correcta inyeccion, y al ejecutar lectura, luego haremos que mientras encuentre 
        //objetos en el guardador cree un objeto auxiliar y almacene los datos del guardador en las variables de nuestro objeto
        //y luego agregarlo en una lista que al final devolveremos.
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> ListaDeArticulos = new List<Articulo>();
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("select Codigo, Nombre, A.Descripcion Descripcion, C.Descripcion Categoria, M.Descripcion Marca, ImagenUrl, A.id Id, Precio Plata From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria AND M.Id = A.IdMarca");
                AccesoBaseDeDatos.EjecutarLecturaBD();
                while (AccesoBaseDeDatos.Guardador.Read())
                {
                    Articulo auxiliar = new Articulo();
                    auxiliar.Id = (int)AccesoBaseDeDatos.Guardador["Id"];
                    auxiliar.CodigoDeArticulo = (string)AccesoBaseDeDatos.Guardador["Codigo"];
                    auxiliar.NombreDeArticulo = (string)AccesoBaseDeDatos.Guardador["Nombre"];
                    auxiliar.DescripcionDeArticulo = (string)AccesoBaseDeDatos.Guardador["Descripcion"];
                    auxiliar.ImagenDelProducto = (string)AccesoBaseDeDatos.Guardador["ImagenUrl"];
                    auxiliar.CategoriaDelProducto.NombreCategoria = (string)AccesoBaseDeDatos.Guardador["Categoria"];
                    auxiliar.MarcaDelProducto.NombreMarca = (string)AccesoBaseDeDatos.Guardador["Marca"];
                    auxiliar.PrecioDelProducto = (decimal)AccesoBaseDeDatos.Guardador["Plata"];
                    ListaDeArticulos.Add(auxiliar);
                }
                return ListaDeArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> listaDeCategorias = new List<Categoria>();
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("select Descripcion, Id from CATEGORIAS");
                AccesoBaseDeDatos.EjecutarLecturaBD();
                while (AccesoBaseDeDatos.Guardador.Read())
                {
                    Categoria auxiliarCategoria = new Categoria();
                    auxiliarCategoria.IdCategoria = (int)AccesoBaseDeDatos.Guardador["Id"];
                    auxiliarCategoria.NombreCategoria = (string)AccesoBaseDeDatos.Guardador["Descripcion"];
                    listaDeCategorias.Add(auxiliarCategoria);
                }
                return listaDeCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }
        public List<Marca> ListarMarcas()
        {
            List<Marca> listaDeMarcas = new List<Marca>();
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("select Descripcion, Id from MARCAS");
                AccesoBaseDeDatos.EjecutarLecturaBD();
                while (AccesoBaseDeDatos.Guardador.Read())
                {
                    Marca auxiliarMarca = new Marca();
                    auxiliarMarca.IdMarca = (int)AccesoBaseDeDatos.Guardador["Id"];
                    auxiliarMarca.NombreMarca = (string)AccesoBaseDeDatos.Guardador["Descripcion"];
                    listaDeMarcas.Add(auxiliarMarca);
                }
                return listaDeMarcas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }

        //En este Metodo llamamos al acceso a BD, le colocamos la inyeccion correspondiente pero los valores los colocaremos con el 
        //arroba, ya que se valor se lo pondremos con la funcion setear parametros
        //En esta funcion lo que hacemos es pasarle el nombre del parametro y el valor, que lo traeremos de un objeto Articulo,
        //que viene desde el FORMS2. Una vez Seteados los parametros ejecutamos la accion contra la BD
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                AccesoBaseDeDatos.SetearParametros("@Codigo", nuevoArticulo.CodigoDeArticulo);
                AccesoBaseDeDatos.SetearParametros("@Nombre", nuevoArticulo.NombreDeArticulo);
                AccesoBaseDeDatos.SetearParametros("@Descripcion", nuevoArticulo.DescripcionDeArticulo);
                 AccesoBaseDeDatos.SetearParametros("@IdMarca", nuevoArticulo.MarcaDelProducto.IdMarca);
                AccesoBaseDeDatos.SetearParametros("@IdCategoria", nuevoArticulo.CategoriaDelProducto.IdCategoria);
                AccesoBaseDeDatos.SetearParametros("@ImagenUrl", nuevoArticulo.ImagenDelProducto);
                AccesoBaseDeDatos.SetearParametros("@Precio", nuevoArticulo.PrecioDelProducto);
                AccesoBaseDeDatos.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }
        public void AgregarMarca(string nuevamarca)
        {
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("insert into MARCAS (Descripcion) values (@Descripcion)");
                AccesoBaseDeDatos.SetearParametros("@Descripcion", nuevamarca); 
                AccesoBaseDeDatos.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }
        public void AgregarCategoria(string nuevaCategoria)
        {
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                AccesoBaseDeDatos.SQLquery("insert into CATEGORIAS (Descripcion) values (@Descripcion)");
                AccesoBaseDeDatos.SetearParametros("@Descripcion", nuevaCategoria);
                AccesoBaseDeDatos.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }
        //Funcionamiento similar a Agregar solo que con la inyeccion UPDATE
        public void Modificar(Articulo Modificar)
        {
            AccesoCentralBD BasedeDatos = new AccesoCentralBD();
            try
            {
                BasedeDatos.SQLquery(("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio Where Id = @Id"));
                BasedeDatos.SetearParametros("@Codigo", Modificar.CodigoDeArticulo);
                BasedeDatos.SetearParametros("@Nombre", Modificar.NombreDeArticulo);
                BasedeDatos.SetearParametros("@Descripcion", Modificar.DescripcionDeArticulo);
                BasedeDatos.SetearParametros("@IdMarca", Modificar.MarcaDelProducto.IdMarca);
                BasedeDatos.SetearParametros("@IdCategoria", Modificar.CategoriaDelProducto.IdCategoria);
                BasedeDatos.SetearParametros("@ImagenUrl", Modificar.ImagenDelProducto);
                BasedeDatos.SetearParametros("@Precio", Modificar.PrecioDelProducto);
                BasedeDatos.SetearParametros("@Id", Modificar.Id);
                BasedeDatos.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BasedeDatos.CerrarConexion();
            }
        }

        //Sigue la logica de los anteriores, solo que en este caso solo con el ID nos permite eliminar el articulo.
        public void EliminarArticulo(int id)
        {
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            { 
                AccesoBaseDeDatos.SQLquery("Delete From ARTICULOS where Id = @id");
                AccesoBaseDeDatos.SetearParametros("@id", id);
                AccesoBaseDeDatos.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBaseDeDatos.CerrarConexion();
            }
        }

        //Tiene el funcionamiento de las listas anteriores, con la diferencia de que mediante un Switch verificas los 
        //parametros de campo y criterio, segun los opciones seleccionadas se modificara ligeramente la inyeccion que ejecutaremos
        //en el SQLquery
        public List<Articulo> ListaFiltrada(string campo, string criterio, string textoFiltrado)
        {
            List<Articulo> listaArticulosFiltrada = new List<Articulo>();
            AccesoCentralBD AccesoBaseDeDatos = new AccesoCentralBD();
            try
            {
                string inyeccion = "select Codigo, Nombre, A.Descripcion Entrada, C.Descripcion Categoria, M.Descripcion Marca, ImagenUrl, A.Id Id, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria AND M.Id = A.IdMarca AND ";
                switch (campo)
                {
                    case "1": //Nombre
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion = inyeccion += "Nombre like '" + textoFiltrado + "%'";
                                break;
                            case "Termina Por":
                                inyeccion = inyeccion += "Nombre like'%" + textoFiltrado + "'";
                                break;
                            default:
                                inyeccion = inyeccion += "Nombre like'%" + textoFiltrado + "%'";
                                break;
                        }
                        break;
                    case "2": //Descripcion
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion = inyeccion += "A.Descripcion like '" + textoFiltrado + "%'";
                                break;
                            case "Termina Por":
                                inyeccion = inyeccion += "A.Descripcion like'%" + textoFiltrado + "'";
                                break;
                            default:
                                inyeccion = inyeccion += "A.Descripcion like'%" + textoFiltrado + "%'";
                                break;
                        }
                        break;
                    case "3": //Marca
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion = inyeccion += "M.Descripcion like '" + textoFiltrado + "%'";
                                break;
                            case "Termina Por":
                                inyeccion = inyeccion += "M.Descripcion like'%" + textoFiltrado + "'"; 
                                break;
                            default:
                                inyeccion = inyeccion += "M.Descripcion like'%" + textoFiltrado + "%'";
                                break;
                        }
                        break;
                    case "4": //Categoria
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion = inyeccion += "C.Descripcion like '" + textoFiltrado + "%'";
                                break;
                            case "Termina Por":
                                inyeccion = inyeccion += "C.Descripcion like'%" + textoFiltrado + "'";
                                break;
                            default:
                                inyeccion = inyeccion += "C.Descripcion like'%" + textoFiltrado + "%'";
                                break;
                        }
                        break;
                    case "5": //Precio
                        switch (criterio)
                        {
                            case "Es Mayor a":
                                inyeccion = inyeccion += "Precio >" + textoFiltrado;
                                break;
                            case "Es Menor a":
                                inyeccion = inyeccion += "Precio <" + textoFiltrado;
                                break;
                            case "Es Igual a":
                                inyeccion = inyeccion += "Precio =" + textoFiltrado;
                                break;
                            default:
                                inyeccion = inyeccion += "Precio =" + textoFiltrado;
                                break;
                        }
                        break;
                    
                }//Fin del switch
                AccesoBaseDeDatos.SQLquery(inyeccion);
                AccesoBaseDeDatos.EjecutarLecturaBD();
                while (AccesoBaseDeDatos.Guardador.Read())
                {
                    Articulo auxiliar = new Articulo();
                    auxiliar.Id = (int)AccesoBaseDeDatos.Guardador["Id"];
                    auxiliar.CodigoDeArticulo = (string)AccesoBaseDeDatos.Guardador["Codigo"];
                    auxiliar.NombreDeArticulo = (string)AccesoBaseDeDatos.Guardador["Nombre"];
                    auxiliar.DescripcionDeArticulo = (string)AccesoBaseDeDatos.Guardador["Entrada"];
                    auxiliar.ImagenDelProducto = (string)AccesoBaseDeDatos.Guardador["ImagenUrl"];
                    auxiliar.CategoriaDelProducto.NombreCategoria = (string)AccesoBaseDeDatos.Guardador["Categoria"];
                    auxiliar.MarcaDelProducto.NombreMarca = (string)AccesoBaseDeDatos.Guardador["Marca"];
                    auxiliar.PrecioDelProducto = (decimal)AccesoBaseDeDatos.Guardador["Precio"];
                    listaArticulosFiltrada.Add(auxiliar);
                }
                return listaArticulosFiltrada;      
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Articulo ListaPorID(int id)
        {
            AccesoCentralBD accesoCentral = new AccesoCentralBD();
            Articulo aux = new Articulo();
            accesoCentral.SQLqueryStoreProcedure("ListaID");
            accesoCentral.SetearParametros("@MyId", id);
            accesoCentral.EjecutarLecturaBD();
            if (accesoCentral.Guardador.Read())
            {
                aux.CodigoDeArticulo = (string)accesoCentral.Guardador["Codigo"];
                aux.NombreDeArticulo = (string)accesoCentral.Guardador["Nombre"];
                aux.DescripcionDeArticulo = (string)accesoCentral.Guardador["Entrada"];
                aux.CategoriaDelProducto.IdCategoria = (int)accesoCentral.Guardador["Cate"];
                aux.MarcaDelProducto.IdMarca = (int)accesoCentral.Guardador["Mar"];
                aux.ImagenDelProducto = (string)accesoCentral.Guardador["ImagenUrl"];
                aux.PrecioDelProducto = (decimal)accesoCentral.Guardador["Precio"];
            }
            return aux;
        }

        public void AgregarFavoritos(int IdUser, int IdArticulo)
        {
            try
            {
                AccesoCentralBD acceso = new AccesoCentralBD();
                acceso.SQLqueryStoreProcedure("AddFav");
                acceso.SetearParametros("@IdUsuario", IdUser);
                acceso.SetearParametros("@IdArticulo", IdArticulo);
                acceso.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BorrarFavoritos(int IdUser, int IdArticulo)
        {
            try
            {
                AccesoCentralBD acceso = new AccesoCentralBD();
                acceso.SQLqueryStoreProcedure("RemoveFav");
                acceso.SetearParametros("@IdUsuario", IdUser);
                acceso.SetearParametros("@IdArticulo", IdArticulo);
                acceso.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DevolverFav(int IdUser, int IdArticulo)
        {
            try
            {
                AccesoCentralBD acceso = new AccesoCentralBD();
                acceso.SQLqueryStoreProcedure("VerFavorito");
                acceso.SetearParametros("@IdUsuario", IdUser);
                acceso.SetearParametros("@IdArticulo", IdArticulo);
                acceso.EjecutarLecturaBD();
                if (acceso.Guardador.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> ListaFav(int UserId)
        {
            try
            {
                AccesoCentralBD acceso = new AccesoCentralBD();
                List<Articulo> listaArticulos = new List<Articulo>();
                acceso.SQLqueryStoreProcedure("ListaFav");
                acceso.SetearParametros("@IdUsuario", UserId);
                acceso.EjecutarLecturaBD();
                while (acceso.Guardador.Read())
                {
                    Articulo aux = new Articulo();
                    aux.NombreDeArticulo = (string)acceso.Guardador["Nombre"];
                    aux.ImagenDelProducto = (string)acceso.Guardador["ImagenUrl"];
                    aux.CodigoDeArticulo = (string)acceso.Guardador["Codigo"];
                    aux.CategoriaDelProducto.NombreCategoria = (string)acceso.Guardador["Cat"];
                    aux.MarcaDelProducto.NombreMarca = (string)acceso.Guardador["Mar"];
                    aux.DescripcionDeArticulo = (string)acceso.Guardador["Descri"];
                    aux.Id = (int)acceso.Guardador["MyID"];
                    aux.PrecioDelProducto = (decimal)acceso.Guardador["Precio"];
                    listaArticulos.Add(aux);
                }
                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
