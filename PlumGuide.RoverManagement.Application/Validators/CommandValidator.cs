using PlumGuide.RoverManagement.Contracts.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlumGuide.RoverManagement.Application.Validators
{
    public class CommandValidator : IValidator
    {
        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            var allowedCommands = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "F", "B", "L", "R" };

            if(input.Select(letter => letter.ToString()).Any(command => !allowedCommands.Contains(command)))
            {
                return false;
            }

            return true;
        }
    }
}