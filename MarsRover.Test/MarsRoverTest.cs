using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Operations.Abstract;
using MarsRover.Operations.Concrete;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        public IPositionService _positionService = new PositionManager();
        [Fact]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            
            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Direction = Directions.N,
                Moves = "LMLMLMLMM"
            };

            var maxPoints = new List<int>() { 5, 5 };

            _positionService.StartMoving(maxPoints, position);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestScanrio_33E_MRRMMRMRRM()
        {
            Position position = new Position()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E,
                Moves = "MMRMMRMRRM"
            };

            var maxPoints = new List<int>() { 5, 5 };

            _positionService.StartMoving(maxPoints,position);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "5 1 E";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
