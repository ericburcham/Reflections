using FluentAssertions;

using NUnit.Framework;

using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class HasAttributeTests
    {
        [Test]
        public void DoesNotHaveAttributeReturnsFalseForOverrideOfAttributedMethodWhenInheritFlagIsTrue()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.DoesNotHaveAttribute<DummyAttribute>(true);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void DoesNotHaveAttributeReturnsFalseWhenAttributeIsApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.DoesNotHaveAttribute<DummyAttribute>();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void DoesNotHaveAttributeReturnsTrueForOverrideOfAttributedMethodWhenInheritFlagIsFalse()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.DoesNotHaveAttribute<DummyAttribute>();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void DoesNotHaveAttributeReturnsTrueWhenAttributeIsNotApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.DoesNotHaveAttribute<DummyAttribute>();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void HasAttributeReturnsFalseForOverrideOfAttributedMethodWhenInheritFlagIsFalse()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.HasAttribute<DummyAttribute>();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasAttributeReturnsFalseWhenAttributeIsNotApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.HasAttribute<DummyAttribute>();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasAttributeReturnsTrueForOverrideOfAttributedMethodWhenInheritFlagIsTrue()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.HasAttribute<DummyAttribute>(true);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void HasAttributeReturnsTrueWhenAttributeIsApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneAttributedMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.HasAttribute<DummyAttribute>();

            // Assert
            result.Should().BeTrue();
        }
    }
}
