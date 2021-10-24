using PlumGuide.RoverManagement.Contracts.Commands;

namespace PlumGuide.RoverManagement.Application.Commands.Rotate
{
    public class RotateRightCommand : IRotateCommand
    {
        public int Value => 1;
    }
}