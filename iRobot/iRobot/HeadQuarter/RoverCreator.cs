using iRobot.Enums;
using iRobot.Rover;
using System;

namespace iRobot.HeadQuarter
{
    public class RoverCreator : ICommand
    {
        private IRoverManager RoverManager { get; set; }
        private string CommandText { get; set; }

        public RoverCreator(IRoverManager roverManager, string command)
        {
            RoverManager = roverManager;
            CommandText = command;
        }

        /// <summary>
        /// This method executes given command.
        /// </summary>
        public void Execute()
        {
            ValidateCommand(CommandText.ToUpper(), out var x, out var y, out var direction);
            RoverManager.SendNewRover(x, y, direction);
        }

        /// <summary>
        /// This method parses and validates command and direction.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        private void ValidateCommand(string command, out int x, out int y, out Direction direction)
        {
            x = 0; y = 0; direction = Direction.E;
            try
            {
                var commandArr = command.Split(" ");
                x = int.Parse(commandArr[0]);
                y = int.Parse(commandArr[1]);
                if (!Enum.TryParse(commandArr[2], out direction))
                {
                    throw new ArgumentException($"Direction {commandArr[2]} is invalid in command line!");
                }
            }
            catch(ArgumentException aex)
            {
                throw aex;
            }
            catch
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}
