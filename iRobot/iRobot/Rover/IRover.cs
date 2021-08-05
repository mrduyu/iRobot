using iRobot.Enums;
namespace iRobot.Rover
{
    public interface IRover
    {
        public void Move(Movement movement);
        public string GetLocationAsString();
        public string GetRoverCoordinates();
    }
}
