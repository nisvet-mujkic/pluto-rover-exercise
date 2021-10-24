using PlumGuide.RoverManagement.Application.Entities;
using PlumGuide.RoverManagement.Contracts.Commands;
using PlumGuide.RoverManagement.Contracts.Controllers;
using PlumGuide.RoverManagement.Contracts.Entities;
using System;

namespace PlumGuide.RoverManagement.Application.Controllers
{
    public class RoverController : IController
    {
        private IPosition _position;
        private IPosition _newPosition;
        private IPlanet _planet;

        public RoverController(IPlanet planet)
        {
            _position = Position.Initial;
            _planet = planet;
        }

        public RoverController(IPosition position)
        {
            _position = position;
        }

        public RoverController(IPosition position, IPlanet planet)
        {
            _position = position;
            _planet = planet;
        }

        public IPosition CurrentPosition => _position;

        public IPosition Execute(ICommand command)
        {
            if (command is IMoveCommand)
            {
                _newPosition = _position.MoveAxis(command.Value);

                if (_planet.CheckBorders(_newPosition.Coordinates))
                {
                    Console.WriteLine(">>> Can't cross planet borders! <<< ");
                    return _position;
                }

                if (_planet.CheckColision(_newPosition.Coordinates))
                {
                    Console.WriteLine(">>> Collision has been detected! <<< ");
                    _newPosition = _position;
                }

                _position = _newPosition;
            }
            else if (command is IRotateCommand)
            {
                _position = _position.Rotate(command.Value);
            }

            return _position;
        }
    }
}