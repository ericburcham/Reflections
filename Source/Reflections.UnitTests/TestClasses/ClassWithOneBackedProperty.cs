namespace Reflections.UnitTests.TestClasses
{
    internal class ClassWithOneBackedProperty
    {
        private string _declaredProperty;

        // ReSharper disable once ConvertToAutoProperty
        public string DeclaredProperty
        {
            get
            {
                return _declaredProperty;
            }
            set
            {
                _declaredProperty = value;
            }
        }
    }
}