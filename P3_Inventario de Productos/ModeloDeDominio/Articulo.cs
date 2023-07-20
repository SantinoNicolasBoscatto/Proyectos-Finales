using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDominio
{
    public class Articulo
    {
        
        public int Id { get; set; }
        [System.ComponentModel.DisplayName("Codigo")]
        public string CodigoDeArticulo { get; set; }
        [System.ComponentModel.DisplayName("Articulo")]
        public string NombreDeArticulo { get; set; }
        [System.ComponentModel.DisplayName("Descripcion")]
        public string DescripcionDeArticulo { get; set; }
        [System.ComponentModel.DisplayName("Marca")]
        public Marca MarcaDelProducto { get; set; }
        [System.ComponentModel.DisplayName("Categoria")]
        public Categoria CategoriaDelProducto { get; set; }
        public string ImagenDelProducto { get; set; }
        [System.ComponentModel.DisplayName("Precio")]
        public decimal PrecioDelProducto { get; set; }

        //Este Constructor es para que cada vez que lo llame la marca y categoria tengan su objeto.
        //En este caso es una relacion de Composicion
        public Articulo()
        {
            MarcaDelProducto = new Marca();
            CategoriaDelProducto = new Categoria();
        }
    }
}
