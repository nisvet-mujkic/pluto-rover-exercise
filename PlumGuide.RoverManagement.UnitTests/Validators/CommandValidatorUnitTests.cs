using PlumGuide.RoverManagement.Application.Validators;
using PlumGuide.RoverManagement.Contracts.Validators;
using Shouldly;
using Xunit;

namespace PlumGuide.RoverManagement.UnitTests.Validators
{
    public class CommandValidatorUnitTests
    {
        private readonly IValidator _commandValidator;

        public CommandValidatorUnitTests()
        {
            _commandValidator = new CommandValidator();
        }

        [Theory]
        [InlineData("FBRL", true)]
        [InlineData("FFRFMF", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        public void Validate(string command, bool isValid)
        {
            var validationResult = _commandValidator.Validate(command);

            validationResult.ShouldBe(isValid);
        }
    }
}