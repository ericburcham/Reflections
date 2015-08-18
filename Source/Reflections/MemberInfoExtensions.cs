using System;
using System.Linq;
using System.Reflection;

namespace Reflections
{
    public static class MemberInfoExtensions
    {
        public static bool DoesNotHaveAttribute<T>(this MemberInfo element, bool inherit = false) where T : Attribute
        {
            return !HasAttribute<T>(element, inherit);
        }

        public static bool HasAttribute<T>(this MemberInfo element, bool inherit = false) where T : Attribute
        {
            return element.GetCustomAttributes<T>(inherit).Any();
        }

        public static bool IsInherited(this MemberInfo element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element", "methodInfo may not be null.");
            }

            var reflectedType = element.ReflectedType;
            var declaringType = element.DeclaringType;
            return reflectedType != declaringType;
        }

        public static bool IsNotInherited(this MemberInfo element)
        {
            return !IsInherited(element);
        }
    }
}