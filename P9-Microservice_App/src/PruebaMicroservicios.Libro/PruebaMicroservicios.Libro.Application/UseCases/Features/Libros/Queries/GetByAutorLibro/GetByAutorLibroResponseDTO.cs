using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro
{
    public class GetByAutorLibroResponseDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AutorId { get; set; }
    }
}
