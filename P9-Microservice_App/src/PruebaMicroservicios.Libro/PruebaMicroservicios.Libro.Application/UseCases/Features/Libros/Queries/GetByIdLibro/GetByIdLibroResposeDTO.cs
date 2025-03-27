using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro
{
    public class GetByIdLibroResposeDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AutorId { get; set; }
    }
}
