namespace PlumGuide.RoverManagement.Contracts.Entities
{
    public interface ICompassDirection
    {
        int Direction { get; }

        string Name { get; }

        ICompassDirection ChangeDirection(int value);
    }
}