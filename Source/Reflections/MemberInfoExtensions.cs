using System;
using System.Linq;
using System.Reflection;

namespace Reflections
{
    public static class MemberInfoExtensions
    {
        public static bool DoesNotHaveAttribute<T>(this MemberInfo memberInfo, bool inherit = false) where T : Attribute
        {
            return !HasAttribute<T>(memberInfo, inherit);
        }

        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit = false) where T: Attribute
        {
            return memberInfo.GetCustomAttributes<T>(inherit).Any();
        }

        public static bool IsInherited(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo", "methodInfo may not be null.");
            }

            var reflectedType = memberInfo.ReflectedType;
            var declaringType = memberInfo.DeclaringType;
            return reflectedType != declaringType;
        }

        public static bool IsNotInherited(this MemberInfo memberInfo)
        {
            return !IsInherited(memberInfo);
        }
    }
}