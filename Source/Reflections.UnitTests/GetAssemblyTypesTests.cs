using System;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace Reflections.UnitTests
{
    [TestFixture]
    public class GetAssemblyTypesTests
    {
        [Test]
        public void GetAssemblyTypesDoesNotReturnNull()
        {
            // Arrange
            var thisType = GetType();

            // Act
            var result = thisType.GetAssemblyTypes().ToList();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}