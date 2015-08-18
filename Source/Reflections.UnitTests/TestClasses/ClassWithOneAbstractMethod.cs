namespace Reflections.UnitTests.TestClasses
{
    internal abstract class ClassWithOneAbstractMethod
    {
        public abstract string AbstractMethod();
    }

    class ClassWithOneOverridenAbstrctMethod : ClassWithOneAbstractMethod
    {
        public override string AbstractMethod()
        {
            return string.Empty;
        }
    }
}