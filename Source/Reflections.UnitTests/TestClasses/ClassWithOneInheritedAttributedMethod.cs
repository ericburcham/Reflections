namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneInheritedAttributedMethod : ClassWithOneAttributedMethod
    {
        public override string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}