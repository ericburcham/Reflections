using System;
using System.Reflection;

namespace Reflections
{
    public static class MethodInfoExtensions
    {
        public static bool IsNotOverride(this MethodInfo element)
        {
            return !IsOverride(element);
        }

        public static bool IsOverride(this MethodInfo element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element", "methodInfo may not be null.");
            }

            var declaringType = element.DeclaringType;
            var baseDefinitionType = element.GetBaseDefinition().DeclaringType;
            return declaringType != baseDefinitionType;
        }
    }
}