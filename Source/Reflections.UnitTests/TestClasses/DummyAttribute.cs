using System;

namespace Reflections.UnitTests.TestClasses
{
    /// <summary>
    ///     A dummy attribute class for decorating things to test resolution of Attribute presence.
    /// </summary>
    internal class DummyAttribute : Attribute
    {
        public DummyAttribute()
        {
        }

        public DummyAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}