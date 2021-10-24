using PlumGuide.RoverManagement.Contracts.Commands;

namespace PlumGuide.RoverManagement.Application.Commands.Move
{
    public class MoveBackwardsCommand : IMoveCommand
    {
        public int Value => -1;
    }
}