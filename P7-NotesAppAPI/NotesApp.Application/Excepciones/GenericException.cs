using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Excepciones
{
    public class GenericException : Exception
    {
        public GenericException(string error) : base(error)
        {}
    }
}
