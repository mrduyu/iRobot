using iRobot.HeadQuarter;
using iRobot.Planet;
using iRobot.Rover;
using System;
using System.Collections.Generic;

namespace iRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NASA Mars-Rover!");
            var surface = new Surface();
            var commandExecuter = new CommandExecuter();
            var roverManager = new RoverManager(surface);
            List<string> roverCoordinates = new List<string>();
            try
            {
                Console.WriteLine("Enter the surface size(e.g. 5 5):");
                var surfaceCreationCmd = new SurfaceCreator(surface, Console.ReadLine());
                commandExecuter.ExecuteCommand(surfaceCreationCmd);

                Console.WriteLine("Enter the first rover initial location with standing direction(e.g. 1 2 N):");
                var roverCreationCmd = new RoverCreator(roverManager, Console.ReadLine());
                commandExecuter.ExecuteCommand(roverCreationCmd);

                Console.WriteLine("Enter the first rover command line without spaces(e.g. LMLMLMLMM):");
                var roverCmd = new RoverEngine(roverManager, Console.ReadLine());
                commandExecuter.ExecuteCommand(roverCmd);
                roverCoordinates.Add(roverManager.GetCurrentRover().GetRoverCoordinates());

                Console.WriteLine("Enter the second rover initial location with standing direction(e.g. 2 2 N):");
                roverCreationCmd = new RoverCreator(roverManager, Console.ReadLine());
                commandExecuter.ExecuteCommand(roverCreationCmd);

                Console.WriteLine("Enter the second rover command line without spaces(e.g. LMRMMR):");
                roverCmd = new RoverEngine(roverManager, Console.ReadLine());
                commandExecuter.ExecuteCommand(roverCmd);
                
                foreach (var rover in roverManager.GetRoverList())
                {
                    Console.WriteLine(rover.GetLocationAsString());
                }

                Console.WriteLine("Rovers moved successfully! Hit any key to exit.");
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException aoex)
            {
                Console.WriteLine(aoex.Message);
                Console.WriteLine("Please check your inputs and start over!");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                Console.WriteLine("Please check your inputs and start over!");
            }
            catch
            {
                Console.WriteLine("Commands could not be executed on rovers.Please try again later.");
            }
        }
    }
}
