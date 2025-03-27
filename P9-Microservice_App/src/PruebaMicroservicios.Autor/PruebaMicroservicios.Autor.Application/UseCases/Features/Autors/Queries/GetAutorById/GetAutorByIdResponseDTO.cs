using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById
{
    public class GetAutorByIdResponseDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime Born { get; set; }
        public List<string>? Books { get; set; }
    }
}
