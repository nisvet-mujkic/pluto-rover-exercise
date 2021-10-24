using PlumGuide.RoverManagement.Contracts.Commands;

namespace PlumGuide.RoverManagement.Contracts.Factories
{
    public interface ICommandFactory
    {
        ICommand Create(string command);
    }
}