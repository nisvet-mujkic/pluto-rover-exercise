using PlumGuide.RoverManagement.Contracts.Entities;
using System;

namespace PlumGuide.RoverManagement.Application.Entities
{
    public class Coordinates: ICoordinates
    {
        public static readonly Coordinates Zero = new(0, 0);

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Coordinates coordinates &&
                   X == coordinates.X &&
                   Y == coordinates.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}