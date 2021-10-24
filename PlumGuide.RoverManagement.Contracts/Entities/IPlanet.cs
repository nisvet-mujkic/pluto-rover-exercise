using System.Collections.Generic;

namespace PlumGuide.RoverManagement.Contracts.Entities
{
    public interface IPlanet
    {
        int XAxisSize { get; }

        int YAxisSize { get; }

        IReadOnlyCollection<ICoordinates> Obstacles { get; }

        bool SetObstacleAt(ICoordinates coordinates);

        bool CheckColision(ICoordinates coordinates);

        bool CheckBorders(ICoordinates coordinates);
    }
}