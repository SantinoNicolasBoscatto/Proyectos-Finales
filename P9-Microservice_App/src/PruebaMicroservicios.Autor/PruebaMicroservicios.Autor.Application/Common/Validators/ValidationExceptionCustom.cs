using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Autor.Application.Common.Validators
{
    public class ValidationExceptionCustom : Exception
    {
        public List<string> Errors { get; set; }

        public ValidationExceptionCustom() : base("One or more validation failures have occurred.")
        {
            Errors = [];
        }

        public ValidationExceptionCustom(IEnumerable<ValidationFailure> errors) : this()
        {
            Errors = errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
