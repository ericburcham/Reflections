using System;
using System.Collections.Generic;

using Funky;

namespace Reflections
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAssemblyTypes(this Type type)
        {
            return GetAssemblyTypesMemoized(type);
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

        public static bool IsNotOfType<T>(this Type type)
        {
            return !IsOfType<T>(type);
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
            return IsOfTypeMemoized(type, typeof(T));
        }

        private static readonly Func<Type, Type[]> GetAssemblyTypesMemoized = ((Func<Type, Type[]>)(type => type.Assembly.GetTypes())).Memoize(true);

        private static readonly Func<Type, bool> IsGenericMemoized = ((Func<Type, bool>)(type => type.IsGenericType)).Memoize();

        private static readonly Func<Type, Type, bool> IsOfTypeMemoized = ((Func<Type, Type, bool>)((extendedType, typeParameterType) => typeParameterType.IsAssignableFrom(extendedType))).Memoize(true);
    }
}