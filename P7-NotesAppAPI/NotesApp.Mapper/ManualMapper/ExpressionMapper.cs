using NotesApp.Domain;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Mapper.ManualMapper
{
    public static class ExpressionMapper
    {
        public static Expression<Func<NoteModel, bool>> Map(Expression<Func<Note, bool>> sourceExpression)
        {
            var parameter = Expression.Parameter(typeof(NoteModel), "noteModel");
            var body = new ParameterReplacer(sourceExpression.Parameters[0], parameter).Visit(sourceExpression.Body);
            return Expression.Lambda<Func<NoteModel, bool>>(body, parameter);
        }
    }

}
