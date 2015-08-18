namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneAttributedMethod
    {
        [Dummy]
        public virtual string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}