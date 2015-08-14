using System.Reflection;

namespace Reflections
{
    public static class MethodInfoExtensions
    {
        public static bool IsInherited(this MethodInfo methodInfo)
        {
            Guard.ArgumentNotNull(() => methodInfo);

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
            Guard.ArgumentNotNull(() => methodInfo);

            var reflectedType = methodInfo.ReflectedType;
            var baseDefinitionType = methodInfo.GetBaseDefinition().DeclaringType;
            return reflectedType != baseDefinitionType;
        }
    }
}