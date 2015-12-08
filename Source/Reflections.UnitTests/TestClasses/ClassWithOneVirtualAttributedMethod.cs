namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneVirtualAttributedMethod
    {
        [Dummy]
        public virtual string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}