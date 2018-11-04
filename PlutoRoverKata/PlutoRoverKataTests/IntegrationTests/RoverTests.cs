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
            yield return new object[] { 0, 0, Heading.East, "F", 1, 0, Heading.East };
            yield return new object[] { 0, 1, Heading.South, "F", 0, 0, Heading.South };
            yield return new object[] { 1, 0, Heading.West, "F", 0, 0, Heading.West };
            yield return new object[] { 0, 1, Heading.North, "B", 0, 0, Heading.North };
            yield return new object[] { 1, 0, Heading.East, "B", 0, 0, Heading.East };
            yield return new object[] { 0, 0, Heading.South, "B", 0, 1, Heading.South };
            yield return new object[] { 0, 0, Heading.West, "B", 1, 0, Heading.West };

            yield return new object[] { 0, 0, Heading.North, "R", 0, 0, Heading.East };
            yield return new object[] { 0, 0, Heading.East, "R", 0, 0, Heading.South };
            yield return new object[] { 0, 0, Heading.South, "R", 0, 0, Heading.West };
            yield return new object[] { 0, 0, Heading.West, "R", 0, 0, Heading.North };
            yield return new object[] { 0, 0, Heading.North, "L", 0, 0, Heading.West };
            yield return new object[] { 0, 0, Heading.East, "L", 0, 0, Heading.North };
            yield return new object[] { 0, 0, Heading.South, "L", 0, 0, Heading.East };
            yield return new object[] { 0, 0, Heading.West, "L", 0, 0, Heading.South };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
