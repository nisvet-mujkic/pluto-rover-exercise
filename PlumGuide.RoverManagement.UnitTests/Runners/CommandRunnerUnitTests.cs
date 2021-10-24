using PlumGuide.RoverManagement.Application.Controllers;
using PlumGuide.RoverManagement.Application.Entities;
using PlumGuide.RoverManagement.Application.Factories;
using PlumGuide.RoverManagement.Application.Runners;
using PlumGuide.RoverManagement.Contracts.Entities;
using PlumGuide.RoverManagement.Contracts.Runners;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PlumGuide.RoverManagement.UnitTests.Runners
{
    public class CommandRunnerUnitTests
    {
        private ICommandRunner _commandRunner;

        public CommandRunnerUnitTests()
        {
            var planet = new Pluto(xAxisSize: 100, yAxisSize: 100);
            planet.SetObstacleAt(new Coordinates(0, 3));
            planet.SetObstacleAt(new Coordinates(2, 3));
            var roverController = new RoverController(planet);
            _commandRunner = new CommandRunner(roverController, new CommandFactory());
        }

        [Theory]
        [MemberData(nameof(GetCommandSequenceMemberData))]
        public void RunnerShouldExecuteCommandSequence(string commandSequence, IPosition expectedPosition)
        {
            var path = _commandRunner.Run(commandSequence);

            var lastPosition = path.Last();

            lastPosition.ShouldBe(expectedPosition);
        }

        [Theory]
        [MemberData(nameof(GetCommandSequenceObstaclesMemberData))]
        public void RunnerShouldNotHitObstacle(string commandSequence, ICoordinates expectedCoordinates)
        {
            var path = _commandRunner.Run(commandSequence);

            var lastPosition = path.Last();

            lastPosition.Coordinates.ShouldBe(expectedCoordinates);
        }

        public static IEnumerable<object[]> GetCommandSequenceMemberData()
        {
            yield return new object[] { "FFRFF", new Position(new Coordinates(2, 2), CompassDirection.East) };
            yield return new object[] { "RFF", new Position(new Coordinates(2, 0), CompassDirection.East) };
            yield return new object[] { "RFFLFF", new Position(new Coordinates(2, 2), CompassDirection.North) };
        }

        public static IEnumerable<object[]> GetCommandSequenceObstaclesMemberData()
        {
            yield return new object[] { "FFFFF", new Coordinates(0, 2) };
            yield return new object[] { "FFFRFF", new Coordinates(2, 2) };
        }
    }
}