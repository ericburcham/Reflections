namespace Reflections.UnitTests.TestClasses
{
    internal class ClassOverridingOneVirtualMethod : ClassWithOneVirtualMethod
    {
        public override string VirtualMethod()
        {
            return string.Empty;
        }
    }
}