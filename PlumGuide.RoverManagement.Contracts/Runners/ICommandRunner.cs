using PlumGuide.RoverManagement.Contracts.Entities;
using System.Collections.Generic;

namespace PlumGuide.RoverManagement.Contracts.Runners
{
    public interface ICommandRunner
    {
        IEnumerable<IPosition> Run(string commandSequence);
    }
}