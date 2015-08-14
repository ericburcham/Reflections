using System;
using System.Linq.Expressions;

namespace Reflections
{
    public static class Guard
    {
        public static T ArgumentNotNull<T>(Expression<Func<T>> arg) where T : class
        {
            var value = arg.Compile().Invoke();
            if (value != null)
            {
                return value;
            }

            var body = arg.Body as MemberExpression;
            throw new ArgumentNullException(body?.Member.Name ?? "parameter");
        }

        public static T ArgumentNotNull<T>(Expression<Func<T>> arg, T value) where T : class
        {
            if (value != null)
            {
                return value;
            }

            var body = arg.Body as MemberExpression;
            throw new ArgumentNullException(body?.Member.Name ?? "parameter");
        }
    }
}