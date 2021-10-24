using PlumGuide.RoverManagement.Contracts.Entities;

namespace PlumGuide.RoverManagement.Application.Entities
{
    public class CompassDirection : ICompassDirection
    {
        public static readonly CompassDirection North = new(1, "N");
        public static readonly CompassDirection East = new(2, "E");
        public static readonly CompassDirection South = new(3, "S");
        public static readonly CompassDirection West = new(4, "W");
        private static readonly CompassDirection[] _directions = new[] { North, East, South, West };

        private CompassDirection(int direction, string name)
        {
            Direction = direction;
            Name = name;
        }

        public int Direction { get; private set; }

        public string Name { get; private set; }

        public ICompassDirection ChangeDirection(int value)
        {
            if (Direction + value < 1)
            {
                return _directions[3];
            }
            else if (Direction + value > 4)
            {
                return _directions[0];
            }
            else
            {
                var index = Direction + value;
                return _directions[index - 1];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CompassDirection direction &&
                   Direction == direction.Direction &&
                   Name == direction.Name;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Direction, Name);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}