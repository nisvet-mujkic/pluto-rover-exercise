using PlumGuide.RoverManagement.Application.Commands;
using PlumGuide.RoverManagement.Application.Commands.Move;
using PlumGuide.RoverManagement.Application.Commands.Rotate;
using PlumGuide.RoverManagement.Contracts.Commands;
using PlumGuide.RoverManagement.Contracts.Factories;
using System;
using System.Collections.Generic;

namespace PlumGuide.RoverManagement.Application.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private static readonly Dictionary<string, Type> _commands = new()
        {
            { "F", typeof(MoveForwardsCommand) },
            { "B", typeof(MoveBackwardsCommand) },
            { "R", typeof(RotateRightCommand) },
            { "L", typeof(RotateLeftCommand) }
        };

        public ICommand Create(string command)
        {
            var hasValidCommand = _commands.TryGetValue(command, out Type type);
            var commandType = hasValidCommand ? type : typeof(DefaultCommand);

            return (ICommand)Activator.CreateInstance(commandType);
        }
    }
}