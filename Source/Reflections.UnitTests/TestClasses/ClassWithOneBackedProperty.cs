namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneBackedProperty
    {
        private string _declaredProperty;

        // ReSharper disable once ConvertToAutoProperty
        // ReSharper disable once UnusedMember.Global
        public string DeclaredProperty
        {
            // ReSharper disable ArrangeAccessorOwnerBody
            get { return _declaredProperty; }
            set { _declaredProperty = value; }
            // ReSharper restore ArrangeAccessorOwnerBody
        }
    }
}