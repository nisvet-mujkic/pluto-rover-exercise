using PlumGuide.RoverManagement.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace PlumGuide.RoverManagement.Application.Entities
{
    public class Position : IPosition
    {
        public static readonly Position Initial = new(Entities.Coordinates.Zero, Entities.CompassDirection.North);

        public Position(ICoordinates coordinates, ICompassDirection compassDirection)
        {
            Coordinates = coordinates;
            CompassDirection = compassDirection;
        }

        public ICoordinates Coordinates { get; private set; }

        public ICompassDirection CompassDirection { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   EqualityComparer<ICoordinates>.Default.Equals(Coordinates, position.Coordinates) &&
                   EqualityComparer<ICompassDirection>.Default.Equals(CompassDirection, position.CompassDirection);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Coordinates, CompassDirection);
        }

        public IPosition MoveAxis(int value)
        {
            return CompassDirection.Direction switch
            {
                Constants.CompassDirection.North => new Position(new Coordinates(Coordinates.X, Coordinates.Y + value), CompassDirection),
                Constants.CompassDirection.South => new Position(new Coordinates(Coordinates.X, Coordinates.Y - value), CompassDirection),
                Constants.CompassDirection.East => new Position(new Coordinates(Coordinates.X + value, Coordinates.Y), CompassDirection),
                Constants.CompassDirection.West => new Position(new Coordinates(Coordinates.X - value, Coordinates.Y), CompassDirection),
                _ => new Position(new Coordinates(Coordinates.X, Coordinates.Y), CompassDirection)
            };
        }

        public IPosition Rotate(int value)
        {
            return new Position(new Coordinates(Coordinates.X, Coordinates.Y), CompassDirection.ChangeDirection(value));
        }

        public override string ToString()
        {
            return $"{Coordinates} {CompassDirection}";
        }
    }
}