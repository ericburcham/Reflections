using System;
using System.Linq;
using System.Reflection;

namespace Reflections
{
    public static class TypeInfoExtensions
    {
        private static readonly ThreadsafeCache<Tuple<TypeInfo, Type>, object> GetAttributeCache = new ThreadsafeCache<Tuple<TypeInfo, Type>, object>();

        public static T GetAttribute<T>(this TypeInfo typeInfo) where T : Attribute
        {
            var tuple = Tuple.Create(typeInfo, typeof(T));
            object result;

            if (GetAttributeCache.TryGetValue(tuple, out result))
            {
                return (T)result;
            }

            result = typeInfo.GetCustomAttributes<T>().SingleOrDefault();

            GetAttributeCache.TryAdd(tuple, result);

            return (T)result;
        }

        public static T GetAttribute<T>(this TypeInfo typeInfo, Func<T, bool> predicate) where T : Attribute
        {
            return typeInfo.GetCustomAttributes<T>().SingleOrDefault(predicate);
        }
    }
}