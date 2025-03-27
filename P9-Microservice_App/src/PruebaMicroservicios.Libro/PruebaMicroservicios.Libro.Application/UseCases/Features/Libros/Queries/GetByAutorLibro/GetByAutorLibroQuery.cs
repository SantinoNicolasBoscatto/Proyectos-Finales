using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro
{
    public class GetByAutorLibroQuery : IRequest<List<GetByAutorLibroResponseDTO>?  >
    {
        public string? AutorId { get; set; }
    }
}
