using System;

using FluentAssertions;

using NUnit.Framework;

using Reflections.UnitTests.TestClasses;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class HasAttributeTests
    {
        [Test]
        public void DoesNotHaveAttributeReturnsTrueWhenAttributeIsNotApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.DoesNotHaveAttribute<DummyAttribute>();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void DoesNotHaveAttributeReturnsFalseWhenAttributeIsApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneAttributedMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.DoesNotHaveAttribute<DummyAttribute>();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasAttributeReturnsFalseWhenAttributeIsNotApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.HasAttribute<DummyAttribute>();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasAttributeReturnsTrueWhenAttributeIsApplied()
        {
            // Arrange
            var targetType = typeof(ClassWithOneAttributedMethod);
            var targetMember = targetType.GetMethod("DeclaredMethod");

            // Act
            var result = targetMember.HasAttribute<DummyAttribute>();

            // Assert
            result.Should().BeTrue();
        }
    }
}
