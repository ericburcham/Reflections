namespace Reflections.UnitTests.TestClasses
{
    internal class ClassOverridingOneVirtualAttributedMethod : ClassWithOneVirtualAttributedMethod
    {
        public override string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}