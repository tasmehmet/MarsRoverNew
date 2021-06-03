using MarsRover.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Operations.Concrete
{
    public class PositionManager : IPositionService
    {
        public void StartMoving(List<int> maxPoints, Models.Position position)
        {
            foreach (var move in position.Moves)
            {
                switch (move)
                {
                    case 'M':
                        position.MoveInSameDirection();
                        break;
                    case 'L':
                        position.Rotate90Left();
                        break;
                    case 'R':
                        position.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (position.X < 0 || position.X > maxPoints[0] || position.Y < 0 || position.Y > maxPoints[1])
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }

    }
}
