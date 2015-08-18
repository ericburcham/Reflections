using System;
using System.Reflection;

namespace Reflections
{
    public static class MethodInfoExtensions
    {
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