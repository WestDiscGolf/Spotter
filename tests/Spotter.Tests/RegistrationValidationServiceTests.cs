using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Spotter.Services;
using Xunit;

namespace Spotter.Tests
{
    public class RegistrationValidationServiceTests
    {
        [Theory]
        [InlineAutoData("A-AAAAA")]
        [InlineAutoData("A-AAAA")]
        [InlineAutoData("A-AAA")]
        [InlineAutoData("A-AA")]
        [InlineAutoData("A-A")]
        [InlineAutoData("AB-AAAAA")]
        [InlineAutoData("AB-AAAA")]
        [InlineAutoData("AB-AAA")]
        [InlineAutoData("AB-AA")]
        [InlineAutoData("AB-A")]
        public async Task ValidScenarios(
            string registrationCode,
            RegistrationValidationService sut
            )
        {
            // Arrange

            // Act
            var result = await sut.ValidateAsync(registrationCode);

            // Assert
            result.IsValid.Should().BeTrue();
            result.ErrorMessage.Should().BeNullOrEmpty();
        }

        [Theory]
        [InlineAutoData(null)]
        [InlineAutoData("")]
        [InlineAutoData("A")]
        [InlineAutoData("AA")]
        [InlineAutoData("AAA")]
        [InlineAutoData("AAAA")]
        [InlineAutoData("AAAAA")]
        [InlineAutoData("AAAAAA")]
        [InlineAutoData("AA+AAAAA")]
        [InlineAutoData("AA=AAAAA")]
        [InlineAutoData("AAA-AAAAA")]
        [InlineAutoData("AAA-AAAAAA")]
        public async Task InvalidScenarios(
            string registrationCode,
            RegistrationValidationService sut
        )
        {
            // Arrange

            // Act
            var result = await sut.ValidateAsync(registrationCode);

            // Assert
            result.IsValid.Should().BeFalse();
            result.ErrorMessage.Should().NotBeNullOrWhiteSpace(); 
        }
    }
}
