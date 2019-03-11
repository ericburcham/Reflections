using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Funky;

namespace Reflections
{
    public static class TypeExtensions
    {
        private static readonly ThreadSafeCache<Tuple<Type, Type>, object> GetAttributeCache =
            new ThreadSafeCache<Tuple<Type, Type>, object>();

        private static readonly ThreadSafeCache<Tuple<Type, Type>, object> GetAttributesCache =
            new ThreadSafeCache<Tuple<Type, Type>, object>();

        private static readonly Func<Type, Type[]> GetAssemblyTypesMemoized =
            ((Func<Type, Type[]>) (type => type.Assembly.GetTypes())).Memoize(true);

        private static readonly Func<Type, bool> IsGenericMemoized =
            ((Func<Type, bool>) (type => type.IsGenericType)).Memoize();

        private static readonly Func<Type, Type, bool> IsOfTypeMemoized =
            ((Func<Type, Type, bool>) ((typeToCheck, target) =>
            {
                if (target.IsAssignableFrom(typeToCheck))
                {
                    return true;
                }

                while (typeToCheck != null && typeToCheck != typeof(object))
                {
                    var currentType = typeToCheck.IsGenericType ? typeToCheck.GetGenericTypeDefinition() : typeToCheck;
                    if (target == currentType)
                    {
                        return true;
                    }

                    typeToCheck = typeToCheck.BaseType;
                }


                return false;
            })).Memoize(true);

        public static IEnumerable<Type> GetAssemblyTypes(this Type type)
        {
            return GetAssemblyTypesMemoized(type);
        }

        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            var tuple = Tuple.Create(type, typeof(T));
            object result;

            if (GetAttributeCache.TryGetValue(tuple, out result)) return (T) result;

            result = type.GetCustomAttributes<T>().SingleOrDefault();

            GetAttributeCache.TryAdd(tuple, result);

            return (T) result;
        }

        public static IEnumerable<T> GetAttributes<T>(this Type type) where T : Attribute
        {
            var tuple = Tuple.Create(type, typeof(T));
            object result;

            if (GetAttributesCache.TryGetValue(tuple, out result)) return (IEnumerable<T>) result;

            result = type.GetCustomAttributes<T>();

            GetAttributesCache.TryAdd(tuple, result);

            return (IEnumerable<T>) result;
        }

        public static T GetAttribute<T>(this Type type, Func<T, bool> predicate) where T : Attribute
        {
            return type.GetCustomAttributes<T>().SingleOrDefault(predicate);
        }

        public static IEnumerable<T> GetAttributes<T>(this Type type, Func<T, bool> predicate) where T : Attribute
        {
            return type.GetCustomAttributes<T>().Where(predicate);
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

        public static bool IsNotOfType<T>(this Type typeToCheck)
        {
            return IsNotOfType(typeToCheck, typeof(T));
        }

        public static bool IsNotOfType(this Type typeToCheck, Type targetType)
        {
            return !typeToCheck.IsOfType(targetType);
        }

        public static bool IsNullable(this Type type)
        {
            if (!type.IsGenericType) return false;
            return type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static bool IsOfType<T>(this Type typeToCheck)
        {
            return IsOfType(typeToCheck, typeof(T));
        }

        public static bool IsOfType(this Type typeToCheck, Type targetType)
        {
            return IsOfTypeMemoized(typeToCheck, targetType);
        }
    }
}