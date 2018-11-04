using PlutoRoverKata;
using System;
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

        [Fact]
        public void Given_the_rover_is_at_0_0_north_When_moving_forward_once_Then_it_should_be_at_0_1_north()
        {
            SetLocation(_rover, 0, 0, Heading.North);
            _rover.Move("F");

            Assert.True(_rover.Location.X == 0);
            Assert.True(_rover.Location.Y == 1);
            Assert.True(_rover.Location.Heading == Heading.North);
        }

        private void SetLocation(Rover rover, int x, int y, Heading heading)
        {
            rover.Location.X = x;
            rover.Location.Y = y;
            rover.Location.Heading = heading;
        }
    }
}
