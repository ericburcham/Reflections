using System;
using System.Collections.Generic;

using FluentAssertions;

using NUnit.Framework;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void ArgumentNotNullThrowsArgumentNotNullExceptionIfArgumentValueIsNull()
        {
            // Arrange
            var argument = new List<string> { "Foo" };

            // Act
            Action action = () => Guard.ArgumentNotNull(() => argument, null);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ArgumentNotNullDoesNotThrowIfArgumentValueIsNotNull()
        {
            // Arrange
            var argument = "Foo";
            var argumentValue = "Foo";

            // Act
            var result = Guard.ArgumentNotNull(() => argument, argumentValue);

            // Assert
            result.Should().Be("Foo");
        }

        [Test]
        public void ArgumentNotNullDoesNotRaiseExceptionForNonNullValue()
        {
            // Arrange
            var argument = "Foo";

            // Act
            var result = Guard.ArgumentNotNull(() => argument);

            // Assert
            result.Should().Be(argument);
        }

        [Test]
        public void ArgumentNotNullThrowsArgumentNotNullExceptionIfArgumentIsNull()
        {
            // Arrange
            string argument = null;

            // Act
            Action action = () => Guard.ArgumentNotNull(() => argument);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}