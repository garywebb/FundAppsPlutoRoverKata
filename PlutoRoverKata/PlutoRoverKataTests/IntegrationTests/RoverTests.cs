using PlutoRoverKata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PlutoRoverKataTests.IntegrationTests
{
    public class RoverTests
    {
        private readonly Rover _rover;

        public RoverTests()
        {
            _rover = new Rover(new Navigator());
        }

        [Theory]
        [ClassData(typeof(RoverMovementTestData))]
        public void When_a_command_is_sent_from_NASA_Then_the_rover_is_moved_to_the_expected_location(
            int startX, int startY, Heading startHeading, 
            string command, 
            int expectedEndX, int expectedEndY, Heading expectedEndHeading)
        {
            SetLocation(_rover, startX, startY, startHeading);
            _rover.Move(command);

            Assert.True(_rover.Location.X == expectedEndX);
            Assert.True(_rover.Location.Y == expectedEndY);
            Assert.True(_rover.Location.Heading == expectedEndHeading);
        }

        private void SetLocation(Rover rover, int x, int y, Heading heading)
        {
            rover.Location.X = x;
            rover.Location.Y = y;
            rover.Location.Heading = heading;
        }
    }

    public class RoverMovementTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 0, Heading.North, "F", 0, 1, Heading.North };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
