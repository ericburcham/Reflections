using System;
using System.Collections.Generic;

using Funky;

namespace Reflections
{
    public static class TypeExtensions
    {
        private static readonly Func<Type, Type[]> MemoizedGetAssemblyTypes = ((Func<Type, Type[]>)(type => type.Assembly.GetTypes())).Memoize(true);

        private static readonly Func<Type, bool> IsGenericMemoized = ((Func<Type, bool>)(type => type.IsGenericType)).Memoize();

        public static IEnumerable<Type> GetAssemblyTypes(this Type type)
        {
            return MemoizedGetAssemblyTypes(type);
        }

        public static bool IsGeneric(this Type type)
        {
            return IsGenericMemoized(type);
        }

        public static bool IsNotAbstract(this Type type)
        {
            return !type.IsAbstract;
        }

        public static bool IsNotGeneric(this Type type)
        {
            return !IsGeneric(type);
        }

        public static bool IsNullable(this Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }
            return type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static bool IsOfType<T>(this Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }
    }
}