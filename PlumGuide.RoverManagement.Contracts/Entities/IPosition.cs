namespace PlumGuide.RoverManagement.Contracts.Entities
{
    public interface IPosition
    {
        ICoordinates Coordinates { get; }

        ICompassDirection CompassDirection { get; }

        IPosition MoveAxis(int value);

        IPosition Rotate(int value);
    }
}