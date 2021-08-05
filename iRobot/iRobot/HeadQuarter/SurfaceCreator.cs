using iRobot.Planet;
using System;

namespace iRobot.HeadQuarter
{
    public class SurfaceCreator : ICommand
    {
        private ISurface Surface { get; set; }
        private string CommandText { get; set; }

        public SurfaceCreator(ISurface surface, string command)
        {
            Surface = surface;
            CommandText = command;
        }
        /// <summary>
        /// Executes the creation of planet.
        /// </summary>
        public void Execute()
        {
            SetWidthHeight(CommandText, out var width, out var height);
            Surface.Create(height, width);
        }

        /// <summary>
        /// Parses the command and sets height and width of the planet.
        /// </summary>
        /// <param name="command">Input command text from NASA user.</param>
        /// <param name="width">Width of the planet.</param>
        /// <param name="height">Height of the planet.</param>
        private void SetWidthHeight(string command, out int width, out int height)
        {
            ValidateSurfaceSize(command);
            var commandArr = command.Trim().Split(" ");
            width = int.Parse(commandArr[0]);
            height = int.Parse(commandArr[1]);
        }

        /// <summary>
        /// Validates surface creation size.
        /// </summary>
        /// <param name="command">Command line text sent by NASA user.</param>
        private void ValidateSurfaceSize(string command)
        {
            try
            {
                var commandArr = command.Trim().Split(" ");
                int width = int.Parse(commandArr[0]);
                int height = int.Parse(commandArr[1]);
                if (height == 0 && width == 0)
                {
                    throw new ArgumentException("Planet surface size cannot be 0 X 0.");
                }
                if (height < 0 || width < 0)
                {
                    throw new ArgumentException("Planet surface size cannot be negative.");
                }
            }
            catch (ArgumentException aex)
            {
                throw aex;
            }
            catch
            {
                throw new ArgumentException("Planet surface size command is not valid! Please enter a valid surface size. For example: 5 5");
            }
        }
    }
}
