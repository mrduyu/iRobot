using iRobot.Enums;
using iRobot.Planet;
using System;

namespace iRobot.Rover
{
    public class Rover : IRover
    {
        private readonly ISurface surface;
        private int X { get; set; }
        private int Y { get; set; }
        private Direction Direction { get; set; }

        public Rover(ISurface surface, int x, int y, Direction direction)
        {
            this.surface = surface;
            X = x;
            Y = y;
            Direction = direction;
        }

        /// <summary>
        /// Sends given command to current rover to move.
        /// </summary>
        /// <param name="m">Valid movements: L,R,M</param>
        public void Move(Movement m)
        {
            switch (m)
            {
                case Movement.L:
                    TurnLeft();
                    break;
                case Movement.R:
                    TurnRight();
                    break;
                case Movement.M:
                    MoveForward();
                    break;
                default:
                   throw new ArgumentException($"Invalid move command: {m.ToString()}!");
            }
        }

        /// <summary>
        /// This method calculates direction after rover turn left.
        /// </summary>
        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
                default:
                    throw new ArgumentException("Command direction is invalid!");
            }
        }

        /// <summary>
        /// This method calculates direction after rover turn left.
        /// </summary>
        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
                case Direction.E:
                    Direction = Direction.S;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentException("Command direction is invalid!");
            }
        }

        /// <summary>
        /// This method calculates direction after rover move forward.
        /// </summary>
        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.N:
                    if (Y+1 <= surface.GetSurfaceHeight())
                    {
                        Y += 1;
                    }
                    break;
                case Direction.S:
                    if (Y-1 >= 0)
                    {
                        Y-=1;
                    }
                    break;
                case Direction.E:
                    if (X+1 <= surface.GetSurfaceWidth())
                    {
                        X+=1;
                    }
                    break;
                case Direction.W:
                    if (X-1>=0)
                    {
                        X-=1;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the last location of the rover.
        /// </summary>
        /// <returns></returns>
        public string GetLocationAsString()
        {
            return $"{X} {Y} {Direction.ToString()}";
        }

        /// <summary>
        /// Gets the current rover coordinates(X-Y)
        /// </summary>
        /// <returns></returns>
        public string GetRoverCoordinates()
        {
            return $"{X}-{Y}";
        }
    }
}
