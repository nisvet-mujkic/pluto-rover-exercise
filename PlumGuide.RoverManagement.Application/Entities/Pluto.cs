using PlumGuide.RoverManagement.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PlumGuide.RoverManagement.Application.Entities
{
    public class Pluto : IPlanet
    {
        private readonly Dictionary<string, ICoordinates> _obstacles = new();

        public Pluto(int xAxisSize, int yAxisSize)
        {
            XAxisSize = xAxisSize;
            YAxisSize = yAxisSize;
        }
        public int XAxisSize { get; }

        public int YAxisSize { get; }

        public IReadOnlyCollection<ICoordinates> Obstacles => _obstacles.Values.ToList();

        public bool SetObstacleAt(ICoordinates coordinates)
        {
            return _obstacles.TryAdd($"{coordinates.X}{coordinates.Y}", coordinates);
        }

        public bool CheckColision(ICoordinates coordinates)
        {
            return _obstacles.ContainsKey($"{coordinates.X}{coordinates.Y}");
        }

        public bool CheckBorders(ICoordinates coordinates)
        {
            return coordinates.X > XAxisSize || coordinates.X < 0 || coordinates.Y > YAxisSize || coordinates.Y < 0;
        }
    }
}