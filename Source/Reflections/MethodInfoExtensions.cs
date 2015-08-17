using System;
using System.Reflection;

namespace Reflections
{
    public static class MethodInfoExtensions
    {
        public static bool IsInherited(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo", "methodInfo may not be null.");
            }

            var reflectedType = methodInfo.ReflectedType;
            var declaringType = methodInfo.DeclaringType;
            return reflectedType != declaringType;
        }

        public static bool IsNotInherited(this MethodInfo methodInfo)
        {
            return !IsInherited(methodInfo);
        }

        public static bool IsNotOverride(this MethodInfo methodInfo)
        {
            return !IsOverride(methodInfo);
        }

        public static bool IsOverride(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo", "methodInfo may not be null.");
            }

            var declaringType = methodInfo.DeclaringType;
            var baseDefinitionType = methodInfo.GetBaseDefinition().DeclaringType;
            return declaringType != baseDefinitionType;
        }
    }
}