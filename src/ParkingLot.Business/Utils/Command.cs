using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class Command : ICommand
    {
        public string GetCommand(string userInputCommand)
        {
            string command = string.Empty;
            if (!string.IsNullOrEmpty(userInputCommand))
            {
                command = userInputCommand.Trim().Split(' ')[0];
            }
            return command;
        }
    }
}