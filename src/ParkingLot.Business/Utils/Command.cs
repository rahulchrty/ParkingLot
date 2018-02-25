using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class Command : ICommand
    {
        public string GetCommand(string inputString)
        {
            string command = string.Empty;
            if (!string.IsNullOrEmpty(inputString))
            {
                command = inputString.Trim().Split(' ')[0];
            }
            return command;
        }
    }
}
