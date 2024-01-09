using System;
using System.Collections.Generic;

namespace ModeloDeDominio
{
    public class Articulo
    {
        
        public int Id { get; set; }
        public string CodigoDeArticulo { get; set; }
        public string NombreDeArticulo { get; set; }
        public string DescripcionDeArticulo { get; set; }
        public string ImagenDelProducto { get; set; }
        public decimal PrecioDelProducto { get; set; }
        public Marca MarcaDelProducto { get; set; }
        public Categoria CategoriaDelProducto { get; set; }
        
        //Este Constructor es para que cada vez que lo llame la marca y categoria tengan su objeto.
        //En este caso es una relacion de Composicion
        public Articulo()
        {
            MarcaDelProducto = new Marca();
            CategoriaDelProducto = new Categoria();
        }
    }
}
