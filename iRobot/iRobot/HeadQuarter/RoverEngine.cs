using iRobot.Enums;
using iRobot.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRobot.HeadQuarter
{
    public class RoverEngine : ICommand
    {
        private readonly IRoverManager RoverManager;
        private string CommandText { get; }

        public RoverEngine(IRoverManager roverManger, string command)
        {
            RoverManager = roverManger;
            CommandText = command;
        }
        /// <summary>
        /// Executes user command and if it is valid rover moves to given direction.
        /// </summary>
        /// <param name="rover">Current active rover.</param>
        /// <param name="command">Given command text by the NASA user.</param>
        private void ExecuteCommand(IRover rover, string command)
        {
            foreach (var cmd in command)
            {
                if (!IsValidCommand(cmd.ToString()))
                {
                    throw new ArgumentException($"Invalid command: {cmd}!");
                }
                rover.Move((Movement)Enum.Parse(typeof(Movement), cmd.ToString()));
            }
            if (RoverManager.GetRoverList().Count > 1 && RoverManager.GetRoverList()[0].GetRoverCoordinates().Equals(RoverManager.GetRoverList()[1].GetRoverCoordinates()))
            {
                throw new ArgumentException("Mars rovers cannot be at the same coordinates. Since rovers may crush each other!");
            }
        }

        /// <summary>
        /// Executes given command by the NASA user.
        /// </summary>
        public void Execute()
        {
            var activeRover = RoverManager.GetCurrentRover();
            ExecuteCommand(activeRover, CommandText.ToUpper());
        }

        /// <summary>
        /// Is command valid? This method checks validation.
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        private bool IsValidCommand(string movement)
        {
            return Enum.TryParse(movement, out Movement m);
        }

    }
}
