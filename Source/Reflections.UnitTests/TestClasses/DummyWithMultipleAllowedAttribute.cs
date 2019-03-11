using System;

namespace Reflections.UnitTests.TestClasses
{
    /// <summary>
    ///     A dummy attribute class for decorating things to test resolution of Attribute presence.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal class DummyWithMultipleAllowedAttribute : Attribute
    {
        public DummyWithMultipleAllowedAttribute()
        {
        }

        public DummyWithMultipleAllowedAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}