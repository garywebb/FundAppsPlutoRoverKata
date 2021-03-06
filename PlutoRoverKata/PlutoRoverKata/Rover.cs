﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PlutoRoverKata
{
    /// <summary>
    /// The main interface for NASA communications. This class is responsible 
    /// for converting any inputs into actions for use by internal classes.
    /// And for converting any internal state into NASA readable responses.
    /// The class also stores the current state of the Rover.
    /// </summary>
    public class Rover
    {
        private readonly Navigator _navigator;

        public Rover(Navigator navigator)
        {
            _navigator = navigator;
            Location = new RoverLocation { X = 0, Y = 0, Heading = Heading.North };
        }

        //Exposed for testing purposes only
        public RoverLocation Location { get; private set; }

        public void Move(string command)
        {
            var commands = Parse(command).ToList();
            foreach (var navigationStep in _navigator.GetNavigationSteps(commands, currentHeading: Location.Heading))
            {
                navigationStep(Location);
            }
        }

        #region Private Methods

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

        #endregion
    }
}
