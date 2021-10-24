using PlumGuide.RoverManagement.Application.Commands.Move;
using PlumGuide.RoverManagement.Application.Commands.Rotate;
using PlumGuide.RoverManagement.Application.Controllers;
using PlumGuide.RoverManagement.Application.Entities;
using PlumGuide.RoverManagement.Contracts.Entities;
using Shouldly;
using Xunit;

namespace PlumGuide.RoverManagement.UnitTests.Controllers
{
    public class RoverControllerUnitTests
    {
        private IPlanet _planet;

        public RoverControllerUnitTests()
        {
            _planet = new Pluto(xAxisSize: 100, yAxisSize: 100);
            _planet.SetObstacleAt(new Coordinates(0, 3));
            _planet.SetObstacleAt(new Coordinates(2, 0));
        }

        [Fact]
        public void RoverShouldStartFromDefaultPosition()
        {
            var controller = new RoverController(_planet);

            controller.CurrentPosition.ShouldBe(Position.Initial);
        }

        [Fact]
        public void RoverShouldMoveForwardsOnlyByOneGrid()
        {
            var controller = new RoverController(_planet);
            var expectedPosition = new Position(new Coordinates(0, 1), CompassDirection.North);

            controller.Execute(new MoveForwardsCommand());

            controller.CurrentPosition.Coordinates.ShouldBe(expectedPosition.Coordinates);
        }

        [Fact]
        public void RoverShouldKeepSameDirectionAfterMovingForward()
        {
            var controller = new RoverController(_planet);
            var expectedPosition = new Position(new Coordinates(0, 1), CompassDirection.North);

            controller.Execute(new MoveForwardsCommand());

            controller.CurrentPosition.CompassDirection.ShouldBe(expectedPosition.CompassDirection);
        }

        [Fact]
        public void RoverShouldMoveBackwards()
        {
            var controller = new RoverController(new Position(new Coordinates(4, 1), CompassDirection.East), _planet);
            var expectedPosition = new Position(new Coordinates(3, 1), CompassDirection.East);

            controller.Execute(new MoveBackwardsCommand());

            controller.CurrentPosition.Coordinates.ShouldBe(expectedPosition.Coordinates);
        }

        [Fact]
        public void RoverShouldRotateOnRight()
        {
            var controller = new RoverController(_planet);
            var expectedPosition = new Position(Coordinates.Zero, CompassDirection.East);

            controller.Execute(new RotateRightCommand());

            controller.CurrentPosition.CompassDirection.ShouldBe(expectedPosition.CompassDirection);
        }

        [Fact]
        public void RoverShouldRotateOnLeft()
        {
            var controller = new RoverController(_planet);
            var expectedPosition = new Position(Coordinates.Zero, CompassDirection.West);

            controller.Execute(new RotateLeftCommand());

            controller.CurrentPosition.CompassDirection.ShouldBe(expectedPosition.CompassDirection);
        }

        [Fact]
        public void RoverShouldNotHitTheObstacle()
        {
            var controller = new RoverController(_planet);
            var expectedPosition = new Position(new Coordinates(0, 2), CompassDirection.West);

            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new MoveForwardsCommand());

            controller.CurrentPosition.Coordinates.ShouldBe(expectedPosition.Coordinates);
        }

        [Fact]
        public void RoverShouldNotCrossPlanetBorders()
        {
            var controller = new RoverController(new Pluto(2, 2));
            var expectedPosition = new Position(new Coordinates(2, 2), CompassDirection.West);

            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new RotateRightCommand());
            controller.Execute(new MoveForwardsCommand());
            controller.Execute(new MoveForwardsCommand());

            controller.CurrentPosition.Coordinates.ShouldBe(expectedPosition.Coordinates);
        }
    }
}