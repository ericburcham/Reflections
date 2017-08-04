using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Reflections
{
    public static class AssemblyExtensions
    {
        private static readonly ThreadsafeCache<Tuple<Assembly, Type>, object> GetAttributeCache = new ThreadsafeCache<Tuple<Assembly, Type>, object>();

        private static readonly ThreadsafeCache<Tuple<Assembly, Type>, object> GetAttributesCache = new ThreadsafeCache<Tuple<Assembly, Type>, object>();

        public static T GetAttribute<T>(this Assembly assembly) where T : Attribute
        {
            var tuple = Tuple.Create(assembly, typeof(T));
            object result;

            if (GetAttributeCache.TryGetValue(tuple, out result))
            {
                return result != null ? (T)result : null;
            }

            result = assembly.GetCustomAttributes<T>().SingleOrDefault();

            GetAttributeCache.TryAdd(tuple, result);

            return (T)result;
        }

        public static IEnumerable<T> GetAttributes<T>(this Assembly assembly) where T : Attribute
        {
            var tuple = Tuple.Create(assembly, typeof(T));
            object result;

            if (GetAttributesCache.TryGetValue(tuple, out result))
            {
                return (IEnumerable<T>) result;
            }

            result = assembly.GetCustomAttributes<T>();

            GetAttributesCache.TryAdd(tuple, result);

            return (IEnumerable<T>) result;
        }

        public static T GetAttribute<T>(this Assembly assembly, Func<T, bool> predicate) where T : Attribute
        {
            return assembly.GetCustomAttributes<T>().SingleOrDefault(predicate);
        }

        public static IEnumerable<T> GetAttributes<T>(this Assembly assembly, Func<T, bool> predicate) where T : Attribute
        {
            return assembly.GetCustomAttributes<T>().Where(predicate);
        }
    }
}
