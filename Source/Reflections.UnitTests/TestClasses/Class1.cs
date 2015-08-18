namespace Reflections.UnitTests.TestClasses
{
    public class ClassWithOneAttributedMethod
    {
        [Dummy]
        public string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}