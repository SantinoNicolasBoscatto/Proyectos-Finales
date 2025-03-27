using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById
{
    public class GetAutorByIdQuery : IRequest<GetAutorByIdResponseDTO?>
    {
        public string? Id { get; set; }
    }
}
