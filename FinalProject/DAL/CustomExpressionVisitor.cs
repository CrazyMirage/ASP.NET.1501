using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CustomExpressionVisitor<From, To> : ExpressionVisitor
    {
        public ParameterExpression NewParameterExp { get; private set; }
        public IDictionary<String, String> Conformity { get; private set; }

        public CustomExpressionVisitor(ParameterExpression newParameterExp, IDictionary<String, String> conformity)
        {
            NewParameterExp = newParameterExp;
            Conformity = conformity;
        }


        public CustomExpressionVisitor(ParameterExpression newParameterExp)
        {
            NewParameterExp = newParameterExp;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return NewParameterExp;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(From))
            {
                string newMember;
                if (Conformity != null)
                {
                    if (!Conformity.TryGetValue(node.Member.Name, out newMember))
                        newMember = node.Member.Name;
                }
                else
                    newMember = node.Member.Name;

                return Expression.MakeMemberAccess(Visit(node.Expression),
                   typeof(To).GetMember(newMember).FirstOrDefault());
            }
            return base.VisitMember(node);
        }

    }
}
