using System;
using System.Linq;
using System.Reflection;

using Funky;

namespace Reflections
{
    public static class MemberInfoExtensions
    {
        // Test all of these attribute usages:
        //   Assembly
        //   Module
        //   Class
        //   Struct
        //   Enum
        //   Constructor
        //   Method
        //   Property
        //   Field
        //   Event
        //   Interface
        //   Parameter
        //   Delegate
        //   ReturnValue
        //   GenericParameter
        //   All

        public static bool DoesNotHaveAttribute<T>(this MemberInfo element, bool inherit = false) where T : Attribute
        {
            return !HasAttribute<T>(element, inherit);
        }

        public static bool HasAttribute<T>(this MemberInfo element, bool inherit = false) where T : Attribute
        {
            element.ThrowIfNull();

            return HasAttributeMemoized(typeof(T), element, inherit);
        }

        public static bool IsInherited(this MemberInfo element)
        {
            element.ThrowIfNull();

            return IsInheritedMemoized(element);
        }

        public static bool IsNotInherited(this MemberInfo element)
        {
            return !IsInherited(element);
        }

        private static void ThrowIfNull(this MemberInfo element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "methodInfo may not be null.");
            }
        }

        private static readonly Func<Type, MemberInfo, bool, bool> HasAttributeMemoized =
            ((Func<Type, MemberInfo, bool, bool>)((type, element, inherit) =>
                {
                    var getCustomAttributesMethod = ReflectedMethods.MakeClosuredGetCustomAttributesMethodForType(type);
                    var getCustomAttributesMethodInvocationResults = getCustomAttributesMethod.Invoke(null, new object[] { element, inherit });
                    return ((object[])getCustomAttributesMethodInvocationResults).Any();
                })).Memoize(true);

        private static readonly Func<MemberInfo, bool> IsInheritedMemoized = ((Func<MemberInfo, bool>)(element =>
            {
                var reflectedType = element.ReflectedType;
                var declaringType = element.DeclaringType;
                return reflectedType != declaringType;
            })).Memoize(true);
    }
}