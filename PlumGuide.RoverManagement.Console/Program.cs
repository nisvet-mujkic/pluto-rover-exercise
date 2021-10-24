
using PlumGuide.RoverManagement.Application.Controllers;
using PlumGuide.RoverManagement.Application.Entities;
using PlumGuide.RoverManagement.Application.Factories;
using PlumGuide.RoverManagement.Application.Runners;
using PlumGuide.RoverManagement.Application.Validators;
using PlumGuide.RoverManagement.Contracts.Controllers;
using PlumGuide.RoverManagement.Contracts.Entities;
using PlumGuide.RoverManagement.Contracts.Runners;
using PlumGuide.RoverManagement.Contracts.Validators;
using System.Linq;

namespace PlumGuide.RoverManagement.Console
{
    class Program
    {
        static IController _controller;
        static ICommandRunner _commandRunner;
        static IPlanet _planet;
        static IValidator _commandValidator;

        static void Main(string[] args)
        {
            _planet = new Pluto(xAxisSize: 100, yAxisSize: 100);
            _planet.SetObstacleAt(new Coordinates(x: 0, y: 2));
            _planet.SetObstacleAt(new Coordinates(x: 2, y: 2));

            _controller = new RoverController(_planet);
            _commandRunner = new CommandRunner(_controller, new CommandFactory());
            _commandValidator = new CommandValidator();

            System.Console.WriteLine($"Welcome to Pluto. " +
                $"It is represented like a {_planet.XAxisSize}x{_planet.YAxisSize} grid " +
                $"with {_planet.Obstacles.Count} obstacles.");

            var command = string.Empty;

            while (true)
            {
                System.Console.WriteLine("Enter command (type 'quit' or 'exit' to end the mission): ");
                command = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                if (command == "quit" || command == "exit")
                {
                    System.Console.WriteLine(">>> Ending mission... Sending rover back to Earth. <<<");
                    break;
                }

                if (!_commandValidator.Validate(command))
                {
                    System.Console.WriteLine("Please enter valid command!");
                    continue;
                }

                var path = _commandRunner.Run(command);
                var position = path.LastOrDefault();

                System.Console.WriteLine($"Rover is on position {position}");
                System.Console.WriteLine();
            }
        }
    }
}