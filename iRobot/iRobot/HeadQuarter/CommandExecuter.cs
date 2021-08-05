namespace iRobot.HeadQuarter
{
    public class CommandExecuter
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
