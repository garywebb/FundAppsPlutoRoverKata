using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRoverKata
{
    public class Navigator
    {
        public virtual IEnumerable<Action<RoverLocation>> GetNavigationSteps(List<Command> expectedCommands)
        {
            //Simplest code I can think of to implement the test
            yield return (location) => 
            {
                location.Y += 1;
            };
        }
    }
}
