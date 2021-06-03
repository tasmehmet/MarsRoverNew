using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Operations.Abstract;
using MarsRover.Operations.Concrete;
using MediatR.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Setups
            var assembly = Assembly.GetExecutingAssembly();

            var container = new Container();
            container.BuildMediator(assembly);

            container.Register<IPositionService, PositionManager>(Lifestyle.Singleton);
            container.Verify();
            var commandExecutor = container.GetInstance<IPositionService>();
            #endregion


            Console.WriteLine("Enter surface size:");
            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<Models.Position> position = new List<Models.Position>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter rover landing coordinates:");
                var startPositions = Console.ReadLine().Trim().Split(' ');
                Console.WriteLine("Enter commands:");
                var moves = Console.ReadLine().ToUpper();

                if (startPositions.Count() == 3)
                {
                    position.Add(new Position()
                    {
                        X = Convert.ToInt32(startPositions[0]),
                        Y = Convert.ToInt32(startPositions[1]),
                        Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2].ToUpper()),
                        Moves = moves
                    });
                }
            }

            try
            {
                foreach (var item in position)
                {
                    commandExecutor.StartMoving(maxPoints, item);
                    Console.WriteLine($"{item.X} {item.Y} {item.Direction.ToString()}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
