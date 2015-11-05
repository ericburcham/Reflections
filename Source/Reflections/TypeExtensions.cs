using System;
using System.Collections.Generic;

using Funky;

namespace Reflections
{
    public static class TypeExtensions
    {
        private static readonly Func<Type, Type[]> MemoizedGetAssemblyTypes = ((Func<Type, Type[]>)(type => type.Assembly.GetTypes())).Memoize(true);

        public static IEnumerable<Type> GetAssemblyTypes(this Type type)
        {
            return MemoizedGetAssemblyTypes(type);
        }
    }
}