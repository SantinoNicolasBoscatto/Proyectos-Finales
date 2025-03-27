using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.DeleteOrder
{
    public class DeleteAutorCommand : IRequest<bool>
    {
        public string? AutorId { get; set; }
    }
}
