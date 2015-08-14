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
            var targetMethod = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMethod.IsInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedMethod);
            var targetMethod = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMethod.IsInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetMethod = null;

            // Act
            Action action = () => targetMethod.IsInherited();

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotInheritedReturnsFalseForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedMethod);
            var targetMethod = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMethod.IsNotInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsNotInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetMethod = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMethod.IsNotInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsNotInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetMethod = null;

            // Act
            Action action = () => targetMethod.IsNotInherited();

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}