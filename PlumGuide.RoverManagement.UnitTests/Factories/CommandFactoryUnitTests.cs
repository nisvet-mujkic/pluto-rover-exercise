using PlumGuide.RoverManagement.Application.Commands;
using PlumGuide.RoverManagement.Application.Commands.Move;
using PlumGuide.RoverManagement.Application.Commands.Rotate;
using PlumGuide.RoverManagement.Application.Factories;
using PlumGuide.RoverManagement.Contracts.Factories;
using Shouldly;
using System;
using Xunit;

namespace PlumGuide.RoverManagement.UnitTests.Factories
{
    public class CommandFactoryUnitTests
    {
        ICommandFactory _commandFactory;

        public CommandFactoryUnitTests()
        {
            _commandFactory = new CommandFactory();
        }

        [Theory]
        [InlineData("F", typeof(MoveForwardsCommand))]
        [InlineData("B", typeof(MoveBackwardsCommand))]
        [InlineData("R", typeof(RotateRightCommand))]
        [InlineData("L", typeof(RotateLeftCommand))]
        [InlineData("Z", typeof(DefaultCommand))]
        public void GetCommandFromFactory(string command, Type expectedCommandType)
        {
            var generatedCommand = _commandFactory.Create(command);

            generatedCommand.ShouldBeOfType(expectedCommandType);
        }
    }
}