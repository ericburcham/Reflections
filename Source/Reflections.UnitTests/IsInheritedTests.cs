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
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.IsInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.IsInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetMember = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetMember.IsInherited();

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotInheritedReturnsFalseForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneInheritedMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.IsNotInherited();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsNotInheritedReturnsTrueForDeclaredMethod()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.IsNotInherited();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsNotInheritedThrowsArgumentNullException()
        {
            // Arrange
            MethodInfo targetMember = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => targetMember.IsNotInherited();

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}