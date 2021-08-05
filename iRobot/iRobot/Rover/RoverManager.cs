using iRobot.Enums;
using iRobot.Planet;
using System;
using System.Collections.Generic;

namespace iRobot.Rover
{
    public class RoverManager : IRoverManager
    {
        private readonly ISurface surface;
        private List<Rover> roverList;
        private Rover currentActiveRover;
        public RoverManager(ISurface surface)
        {
            this.surface = surface;
            roverList = new List<Rover>();
        }

        /// <summary>
        /// If a new rover needs to be sent to planet, this method deploys a new rover to given coordinates.
        /// </summary>
        /// <param name="x">New rover coordinate X</param>
        /// <param name="y">New rover coordinate Y</param>
        /// <param name="direction">New rover direction(N,S,W,E)</param>
        public void SendNewRover(int x, int y, Direction direction)
        {
            if (IsValidLocation(x, y))
            {
                var rover = new Rover(surface, x, y, direction);
                roverList.Add(rover);
                currentActiveRover = rover;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Rover location is out of bounds.");
            }
        }

        public Rover GetCurrentRover() { return currentActiveRover; }

        public List<Rover> GetRoverList() { return roverList; }

        /// <summary>
        /// Validates the location of rover that needs to be sent.
        /// </summary>
        /// <param name="x">Given coordinate X of new rover.</param>
        /// <param name="y">Given coordinate Y of new rover.</param>
        /// <returns>If it is valid location returns true, otherwise false.</returns>
        private bool IsValidLocation(int x, int y)
        {
            return (x >= 0 && x <= surface.GetSurfaceWidth()) && (y >= 0 && y <= surface.GetSurfaceHeight());
        }

    }
}
