using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflections
{
    public static class AssemblyExtensions
    {
        private static readonly ThreadSafeCacheFoo<Tuple<Assembly, Type>, object> GetAttributeCacheFoo =
            new ThreadSafeCacheFoo<Tuple<Assembly, Type>, object>();

        private static readonly ThreadSafeCacheFoo<Tuple<Assembly, Type>, object> GetAttributesCacheFoo =
            new ThreadSafeCacheFoo<Tuple<Assembly, Type>, object>();

        public static T GetAttribute<T>(this Assembly assembly) where T : Attribute
        {
            var tuple = Tuple.Create(assembly, typeof(T));
            object result;

            if (GetAttributeCacheFoo.TryGetValue(tuple, out result)) return result != null ? (T) result : null;

            result = assembly.GetCustomAttributes<T>().SingleOrDefault();

            GetAttributeCacheFoo.TryAdd(tuple, result);

            return (T) result;
        }

        public static IEnumerable<T> GetAttributes<T>(this Assembly assembly) where T : Attribute
        {
            var tuple = Tuple.Create(assembly, typeof(T));
            object result;

            if (GetAttributesCacheFoo.TryGetValue(tuple, out result)) return (IEnumerable<T>) result;

            result = assembly.GetCustomAttributes<T>();

            GetAttributesCacheFoo.TryAdd(tuple, result);

            return (IEnumerable<T>) result;
        }

        public static T GetAttribute<T>(this Assembly assembly, Func<T, bool> predicate) where T : Attribute
        {
            return assembly.GetCustomAttributes<T>().SingleOrDefault(predicate);
        }

        public static IEnumerable<T> GetAttributes<T>(this Assembly assembly, Func<T, bool> predicate)
            where T : Attribute
        {
            return assembly.GetCustomAttributes<T>().Where(predicate);
        }
    }
}