using FakeItEasy;
using PlutoRoverKata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PlutoRoverKataTests.UnitTests
{
    public class RoverTests
    {
        private readonly Rover _rover;
        private readonly Navigator _navigatorFake;

        public RoverTests()
        {
            _navigatorFake = A.Fake<Navigator>();
            _rover = new Rover(_navigatorFake);
        }

        [Theory]
        [ClassData(typeof(ParseTestData))]
        public void Move_parses_command_and_passes_results_to_Navigator(string command, Command[] expectedCommands)
        {
            _rover.Move(command);

            A.CallTo(() => _navigatorFake.GetNavigationSteps(A<List<Command>>.That.IsSameSequenceAs(expectedCommands)))
                .MustHaveHappenedOnceExactly();
        }
    }

    public class ParseTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "F", new [] { Command.Forward } };
            yield return new object[] { "B", new [] { Command.Backward } };
            yield return new object[] { "L", new [] { Command.Left } };
            yield return new object[] { "R", new [] { Command.Right } };
            yield return new object[] { "FF", new [] { Command.Forward, Command.Forward } };
            yield return new object[] { "FB", new [] { Command.Forward, Command.Backward } };
            yield return new object[] { "FL", new [] { Command.Forward, Command.Left } };
            yield return new object[] { "FR", new [] { Command.Forward, Command.Right } };
            yield return new object[] { "BF", new [] { Command.Backward, Command.Forward } };
            yield return new object[] { "BB", new [] { Command.Backward, Command.Backward } };
            yield return new object[] { "BL", new [] { Command.Backward, Command.Left } };
            yield return new object[] { "BR", new [] { Command.Backward, Command.Right } };
            yield return new object[] { "LF", new [] { Command.Left, Command.Forward } };
            yield return new object[] { "LB", new [] { Command.Left, Command.Backward } };
            yield return new object[] { "LL", new [] { Command.Left, Command.Left } };
            yield return new object[] { "LR", new [] { Command.Left, Command.Right } };
            yield return new object[] { "RF", new [] { Command.Right, Command.Forward } };
            yield return new object[] { "RB", new [] { Command.Right, Command.Backward } };
            yield return new object[] { "RL", new [] { Command.Right, Command.Left } };
            yield return new object[] { "RR", new [] { Command.Right, Command.Right } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
