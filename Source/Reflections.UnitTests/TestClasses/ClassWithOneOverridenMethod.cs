namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneOverridenMethod : ClassWithOneVirtualMethod
    {
        public override string VirtualMethod()
        {
            return string.Empty;
        }
    }
}