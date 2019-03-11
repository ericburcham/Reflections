namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneVirtualAttributedMethod
    {
        // ReSharper disable once UnusedMember.Global
        [Dummy]
        public virtual string DeclaredMethod()
        {
            return string.Empty;
        }
    }
}