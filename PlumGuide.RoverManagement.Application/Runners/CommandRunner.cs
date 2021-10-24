using PlumGuide.RoverManagement.Contracts.Controllers;
using PlumGuide.RoverManagement.Contracts.Entities;
using PlumGuide.RoverManagement.Contracts.Factories;
using PlumGuide.RoverManagement.Contracts.Runners;
using System.Collections.Generic;

namespace PlumGuide.RoverManagement.Application.Runners
{
    public class CommandRunner : ICommandRunner
    {
        private readonly IController _controller;
        private readonly ICommandFactory _commandFactory;

        public CommandRunner(IController controller, ICommandFactory commandFactory)
        {
            _controller = controller;
            _commandFactory = commandFactory;
        }

        public IEnumerable<IPosition> Run(string commandSequence)
        {
            foreach (var command in commandSequence)
            {
                yield return _controller.Execute(_commandFactory.Create(command.ToString()));
            }
        }
    }
}