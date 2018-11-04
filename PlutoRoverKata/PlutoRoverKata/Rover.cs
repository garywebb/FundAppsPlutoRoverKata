using System;
using System.Collections.Generic;
using System.Linq;

namespace PlutoRoverKata
{
    public class Rover
    {
        private readonly Navigator _navigator;

        public Rover(Navigator navigator)
        {
            _navigator = navigator;
        }

        public void Move(string command)
        {
            var commands = Parse(command).ToList();
            _navigator.Navigate(commands);
        }

        private IEnumerable<Command> Parse(string commandString)
        {
            foreach (var commandItemChar in commandString)
            {
                switch (commandItemChar)
                {
                    case 'F':
                        yield return Command.Forward;
                        break;
                    case 'B':
                        yield return Command.Backward;
                        break;
                    case 'L':
                        yield return Command.Left;
                        break;
                    case 'R':
                        yield return Command.Right;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Can not interpret command of type: {commandItemChar}");
                }
            }
        }
    }
}
