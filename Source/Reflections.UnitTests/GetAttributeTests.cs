using System;
using System.Reflection;

using FluentAssertions;

using NUnit.Framework;

using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class GetAttributeTests
    {
        // Test all of these attribute usages:
        //   Assembly           DONE
        //   Module
        //   Class              DONE
        //   Struct
        //   Enum
        //   Constructor
        //   Method
        //   Property
        //   Field
        //   Event
        //   Interface
        //   Parameter
        //   Delegate
        //   ReturnValue
        //   GenericParameter
        //   All

        private Assembly _testAssembly;

        private Type _testType;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testAssembly = GetType().Assembly;
            _testType = typeof(ClassWithSeveralDummyAttributes);
        }

        [Test]
        public void GetAttributeReturnsNullWhenCallingAssemblyDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttribute<UnusedDummyAttribute>();

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetAttributeReturnsRequestedAtrributeWhenCallingAssemblyHasTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttribute<DummyAttribute>();

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void GetAttributeThrowsInvalidOperationExceptionWhenCallingAssemblyHasMoreThanOneRequestedAttribute()
        {
            // Act
            Action action = () => _testAssembly.GetAttribute<DummyWithMultipleAllowedAttribute>();

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsNullWhenCallingAssemblyDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttribute<DummyAttribute>(attribute => attribute.Message == "IDoNotMatch");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingAssemblyHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate()
        {
            // Act
            var result = _testAssembly.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message == "Dummy1");

            // Assert
            result.Should().BeOfType<DummyWithMultipleAllowedAttribute>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingAssemblyHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttribute<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void GetAttributeWithPredicateThrowsInvalidOperationExceptionWhenCallingAssemblyHasMoreThanOneMatchingRequestedAttribute()
        {
            // Act
            Action action = () => _testAssembly.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetAttributeReturnsNullWhenCallingTypeDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttribute<UnusedDummyAttribute>();

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetAttributeReturnsRequestedAtrributeWhenCallingTypeHasTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttribute<DummyAttribute>();

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void GetAttributeThrowsInvalidOperationExceptionWhenCallingTypeHasMoreThanOneRequestedAttribute()
        {
            // Act
            Action action = () => _testType.GetAttribute<DummyWithMultipleAllowedAttribute>();

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsNullWhenCallingTypeDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttribute<DummyAttribute>(attribute => attribute.Message == "IDoNotMatch");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void
            GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingTypeHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate
            ()
        {
            // Act
            var result =
                _testType.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message == "Dummy1");

            // Assert
            result.Should().BeOfType<DummyWithMultipleAllowedAttribute>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingTypeHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttribute<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void
            GetAttributeWithPredicateThrowsInvalidOperationExceptionWhenCallingTypeHasMoreThanOneMatchingRequestedAttribute
            ()
        {
            // Act
            Action action =
                () => _testType.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }
    }
}