using iRobot.Enums;
using System.Collections.Generic;

namespace iRobot.Rover
{
    public interface IRoverManager
    {
        void SendNewRover(int x, int y, Direction direction);
        Rover GetCurrentRover();
        List<Rover> GetRoverList();
    }
}
