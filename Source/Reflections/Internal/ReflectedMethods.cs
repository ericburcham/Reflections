using System;
using System.Linq;
using System.Reflection;

using Funky;

namespace Reflections
{
    internal static class ReflectedMethods
    {
        public static readonly MethodInfo GetCustomAttributes =
            typeof(CustomAttributeExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(mi => mi.Name == "GetCustomAttributes")
                .Where(mi => mi.GetGenericArguments().Length == 1)
                .Where(mi => mi.GetParameters().Length == 2)
                .Where(mi => mi.GetParameters()[0].ParameterType == typeof(MemberInfo))
                .Single(mi => mi.GetParameters()[1].ParameterType == typeof(bool));

        private static readonly Func<Type, MethodInfo> ClosuredGetCustomAttributesMethod = MakeClosuredGetCustomAttributesMethod;

        private static MethodInfo MakeClosuredGetCustomAttributesMethod(Type type)
        {
            return GetCustomAttributes.MakeGenericMethod(type);
        }

        public static MethodInfo MakeClosuredGetCustomAttributesMethodForType(Type type)
        {
            return MemoizedGetCustomAttributesMethod(type);
        }

        private static readonly Func<Type, MethodInfo> MemoizedGetCustomAttributesMethod = ClosuredGetCustomAttributesMethod.Memoize(true);
    }
}