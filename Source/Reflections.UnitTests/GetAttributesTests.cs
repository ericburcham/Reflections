using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class GetAttributesTests
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
        public void GetAttributesReturnsEmptyWhenCallingAssemblyDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttributes<UnusedDummyAttribute>();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetAttributesReturnsEmptyWhenCallingTypeDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttributes<UnusedDummyAttribute>();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetAttributesReturnsEnumerableContainingRequestedAttributeWhenCallingTypeHasTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttributes<DummyAttribute>();

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void
            GetAttributesReturnsEnumerableContainingMultipleRequestedAttributesCallingTypeHasMoreThanOneRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttributes<DummyWithMultipleAllowedAttribute>();

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(2);
        }

        [Test]
        public void
            GetAttributesReturnsEnumerableContainingMultipleRequestedAttributeWhenCallingAssemblyHasMoreThanOneRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttributes<DummyWithMultipleAllowedAttribute>();

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(2);
        }

        [Test]
        public void
            GetAttributesReturnsEnumerableContainingRequestedAttributeWhenCallingAssemblyHasTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttributes<DummyAttribute>();

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void GetAttributesWithPredicateReturnsEmptyWhenCallingTypeDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttributes<DummyAttribute>(attribute => attribute.Message == "IDoNotMatch");

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingMultipleRequestedAttributesWhenCallingTypeHasMoreThanOneMatchingRequestedAttribute()
        {
            // Act
            var result =
                _testType.GetAttributes<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(2);
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingMultipleRequestedAttributeWhenCallingAssemblyHasMoreThanOneMatchingRequestedAttribute()
        {
            // Act
            var result =
                _testAssembly.GetAttributes<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message != null);

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(2);
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingRequestedAttributeWhenCallingAssemblyHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate()
        {
            // Act
            var result =
                _testAssembly.GetAttributes<DummyWithMultipleAllowedAttribute>(attribute =>
                    attribute.Message == "Dummy1");

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingRequestedAttributeWhenCallingAssemblyHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttributes<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingRequestedAttributeWhenCallingTypeHasMoreThanOneRequestedAttributeButOnlyOneMatchesThePredicate()
        {
            // Act
            var result =
                _testType.GetAttributes<DummyWithMultipleAllowedAttribute>(attribute => attribute.Message == "Dummy1");

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1);
        }

        [Test]
        public void
            GetAttributesWithPredicateReturnsEnumerableContainingRequestedAttributeWhenCallingTypeHasOneMatchingRequestedAttribute()
        {
            // Act
            var result = _testType.GetAttribute<DummyAttribute>(attribute => attribute.Message == "Dummy");

            // Assert
            result.Should().BeOfType<DummyAttribute>();
        }

        [Test]
        public void GetAttributesWithPredicateReturnsNullWhenCallingAssemblyDoesNotHaveTheRequestedAttribute()
        {
            // Act
            var result = _testAssembly.GetAttributes<DummyAttribute>(attribute => attribute.Message == "IDoNotMatch");

            // Assert
            result.Should().BeEmpty();
        }
    }
}