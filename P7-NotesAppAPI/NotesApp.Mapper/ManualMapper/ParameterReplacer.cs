using NotesApp.Models.Domain;
using System.Linq.Expressions;
using System.Reflection;


namespace NotesApp.Mapper.ManualMapper
{
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _sourceParameter;
        private readonly ParameterExpression _targetParameter;

        public ParameterReplacer(ParameterExpression sourceParameter, ParameterExpression targetParameter)
        {
            _sourceParameter = sourceParameter;
            _targetParameter = targetParameter;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member is PropertyInfo propertyInfo)
            {
                var targetProperty = typeof(NoteModel).GetProperty(propertyInfo.Name);
                if (targetProperty == null)
                {
                    throw new ArgumentException($"Property '{propertyInfo.Name}' is not defined for type '{typeof(NoteModel).Name}'");
                }

                var targetMember = Expression.Property(_targetParameter, targetProperty);
                return base.VisitMember(targetMember);
            }

            return base.VisitMember(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _sourceParameter ? _targetParameter : base.VisitParameter(node);
        }
    }
}
