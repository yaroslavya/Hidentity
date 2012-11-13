using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Hidentity.Configuration
{
    /// <summary>
    /// Configures what property of what class should be substituted.
    /// </summary>
    public static class Configurator
    {

        //TODO: We have to remove dependency on the types T,V here. And evaluate them from the expression itself.
        //It would be more compact and easy to write. For now continuing with this one.
        public static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Expression.Type.Name;
            //return memberExpression.Member.Name;
        }

        public static void Substitute<T, V>(this Expression<Func<T, V>> expression) 
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            Type classType = memberExpression.Expression.Type;

            var item = new Substitutable() { PropertyName=memberExpression.Member.Name, TypeGuid=classType.GUID.ToString(), TypeName=classType.Name};

            SubstitutablesRegistry.Instance.Add(item);
            //TODO: add provided expression data to substitutables registry.
            //memberExpression.Expression.Type.Name;
        }

        public static List<Substitutable> SubstitutesFor(Type type)
        {
            List<Substitutable> res = SubstitutablesRegistry.Instance.Find(type.GUID.ToString());

            return res;
        }

        public static void SubstituteFor(Object model)
        {
            //TODO: late night code. Overwrite, this is just concept code.
            Type type = model.GetType();
            var propToHide = Configurator.SubstitutesFor(type)[0];

        }

        public static SubstitutablesRegistry Substitutables()
        {
            //TODO: major cleanup soon.
            Substitutable handlingType = SubstitutablesRegistry.Instance.GetHandlingType((x) => x.TypeName == "");

            return null;
        }

    }
}
