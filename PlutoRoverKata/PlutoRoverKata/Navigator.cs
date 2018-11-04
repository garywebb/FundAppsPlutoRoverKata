using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRoverKata
{
    public class Navigator
    {
        public virtual IEnumerable<Action<RoverLocation>> GetNavigationSteps(
            List<Command> commands, Heading currentHeading)
        {
            foreach (var command in commands)
            {
                yield return GetNavigationStep(command, currentHeading);
            }
        }

        private Action<RoverLocation> GetNavigationStep(Command command, Heading currentHeading)
        {
            if (currentHeading == Heading.North && command == Command.Forward ||
                currentHeading == Heading.South && command == Command.Backward)
            {
                return location => location.Y += 1;
            }
            if (currentHeading == Heading.South && command == Command.Forward ||
                currentHeading == Heading.North && command == Command.Backward)
            {
                return location => location.Y -= 1;
            }
            if (currentHeading == Heading.East && command == Command.Forward ||
                currentHeading == Heading.West && command == Command.Backward)
            {
                return location => location.X += 1;
            }
            if (currentHeading == Heading.West && command == Command.Forward ||
                currentHeading == Heading.East && command == Command.Backward)
            {
                return location => location.X -= 1;
            }
            if (command == Command.Right)
            {
                //I think we can do some clever modulo maths to change heading here,
                //but I've run out of time to implement it
                return location =>
                {
                    location.Heading = location.Heading == Heading.West
                        ? Heading.North
                        : location.Heading += 1;
                };
            }
            if (command == Command.Left)
            {
                //I think we can do some clever modulo maths to change heading here,
                //but I've run out of time to implement it
                return location =>
                {
                    location.Heading = location.Heading == Heading.North
                        ? Heading.West
                        : location.Heading -= 1;
                };
            }

            throw new ArgumentOutOfRangeException(nameof(command));
        }
    }
}
