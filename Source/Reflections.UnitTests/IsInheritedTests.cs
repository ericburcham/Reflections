using System;
using System.Reflection;

using FluentAssertions;

using NUnit.Framework;

using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class IsInheritedTests
    {
        [Test]
        public void IsInheritedReturnsFalseForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassInheritingOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetElement = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetElement.IsInherited();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void IsNotInheritedReturnsFalseForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassInheritingOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsNotInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsNotInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetElement = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetElement.IsNotInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsNotInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetElement = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetElement.IsNotInherited();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}