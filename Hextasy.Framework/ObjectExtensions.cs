using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Hextasy.Framework
{
    public static class ObjectExtensions
    {
        public static string GetPropertyName<TSource, TProperty>(
            this TSource obj,
            Expression<Func<TSource, TProperty>> propertyLambda)
            where TSource : class
        {
            if(obj == null) throw new ArgumentNullException("obj");
            var type = typeof(TSource);

            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda,
                    type));

            return propInfo.Name;
        }
    }
}
