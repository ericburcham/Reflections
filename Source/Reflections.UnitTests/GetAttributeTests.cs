using System;
using System.Reflection;

using FluentAssertions;

using NUnit.Framework;

using Reflections.UnitTests.TestClasses;

// Assembly-level attribute applications needed for these tests.
[assembly: Dummy("Dummy")]
[assembly: DummyWithMultipleAllowed("Dummy1")]
[assembly: DummyWithMultipleAllowed("Dummy2")]

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

        private Type _testClass;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testAssembly = GetType().Assembly;
            _testClass = typeof(ClassWithSeveralDummyAttributes);
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
        public void
            GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingAssemblyHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate
            ()
        {
            // Act
            var result =
                _testAssembly.GetAttribute<DummyWithMultipleAllowedAttribute>(
                    attribute => attribute.Message == "Dummy1");

            // Assert
            result.Should().BeOfType<DummyWithMultipleAllowedAttribute>();
        }

        [Test]
        public void
            GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingAssemblyHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttribute<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void
            GetAttributeWithPredicateThrowsInvalidOperationExceptionWhenCallingAssemblyHasMoreThanOneMatchingRequestedAttribute
            ()
        {
            // Act
            Action action =
                () =>
                _testAssembly.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetAttributeReturnsNullWhenCallingClassDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testClass.GetAttribute<UnusedDummyAttribute>();

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetAttributeReturnsRequestedAtrributeWhenCallingClassHasTheRequestedAttribute()
        {
            // Act
            var result = _testClass.GetAttribute<DummyAttribute>();

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void GetAttributeThrowsInvalidOperationExceptionWhenCallingClassHasMoreThanOneRequestedAttribute()
        {
            // Act
            Action action = () => _testClass.GetAttribute<DummyWithMultipleAllowedAttribute>();

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsNullWhenCallingClassDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testClass.GetAttribute<DummyAttribute>(attribute => attribute.Message == "IDoNotMatch");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void
            GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingClassHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate
            ()
        {
            // Act
            var result =
                _testClass.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message == "Dummy1");

            // Assert
            result.Should().BeOfType<DummyWithMultipleAllowedAttribute>();
        }

        [Test]
        public void GetAttributeWithPredicateReturnsRequestedAttributeWhenCallingClassHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testClass.GetAttribute<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void
            GetAttributeWithPredicateThrowsInvalidOperationExceptionWhenCallingClassHasMoreThanOneMatchingRequestedAttribute
            ()
        {
            // Act
            Action action =
                () => _testClass.GetAttribute<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }
    }
}