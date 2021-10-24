using PlumGuide.RoverManagement.Contracts.Commands;
using PlumGuide.RoverManagement.Contracts.Entities;

namespace PlumGuide.RoverManagement.Contracts.Controllers
{
    public interface IController
    {
        IPosition Execute(ICommand command);

        IPosition CurrentPosition { get; }
    }
}