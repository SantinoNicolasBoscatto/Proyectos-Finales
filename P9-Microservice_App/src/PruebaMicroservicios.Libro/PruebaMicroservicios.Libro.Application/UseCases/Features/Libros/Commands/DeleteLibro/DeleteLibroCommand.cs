using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.DeleteLibro
{
    public class DeleteLibroCommand : IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
