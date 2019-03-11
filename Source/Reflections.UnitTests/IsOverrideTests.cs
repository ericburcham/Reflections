using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class IsOverrideTests
    {
        [Test]
        public void IsNotOverrideReturnsFalseForOverridenAbstractMethod()
        {
            // Arrange
            var targetType = typeof(ClassOverridingOneAbstractMethod);
            var targetElement = targetType.GetMethod("AbstractMethod");

            // Act
            var result = targetElement.IsNotOverride();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsNotOverrideReturnsFalseForOverridenMethod()
        {
            // Arrange
            var targetType = typeof(ClassOverridingOneVirtualMethod);
            var targetElement = targetType.GetMethod("VirtualMethod");

            // Act
            var result = targetElement.IsNotOverride();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsNotOverrideReturnsTrueForInheritedMethod()
        {
            // Arrange
            var targetType = typeof(ClassInheritingOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsNotOverride();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsNotOverrideReturnsTrueForVirtualMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneVirtualMethod);
            var targetElement = targetType.GetMethod("VirtualMethod");

            // Act
            var result = targetElement.IsNotOverride();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsNotOverrideThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetElement = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetElement.IsNotOverride();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void IsOverrideReturnsFalseForInheritedMethod()
        {
            // Arrange
            var targetType = typeof(ClassInheritingOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsOverride();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsOverrideReturnsFalseForVirtualMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneVirtualMethod);
            var targetElement = targetType.GetMethod("VirtualMethod");

            // Act
            var result = targetElement.IsOverride();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsOverrideReturnsTrueForOverridenAbstractMethod()
        {
            // Arrange
            var targetType = typeof(ClassOverridingOneAbstractMethod);
            var targetElement = targetType.GetMethod("AbstractMethod");

            // Act
            var result = targetElement.IsOverride();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsOverrideReturnsTrueForOverridenMethod()
        {
            // Arrange
            var targetType = typeof(ClassOverridingOneVirtualMethod);
            var targetElement = targetType.GetMethod("VirtualMethod");

            // Act
            var result = targetElement.IsOverride();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsOverrideThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetElement = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetElement.IsOverride();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}