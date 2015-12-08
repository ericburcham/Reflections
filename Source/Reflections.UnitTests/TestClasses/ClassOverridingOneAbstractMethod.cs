namespace Reflections.UnitTests.TestClasses
{
    internal class ClassOverridingOneAbstractMethod : AbstractClassWithOneAbstractMethod
    {
        public override string AbstractMethod()
        {
            return string.Empty;
        }
    }
}