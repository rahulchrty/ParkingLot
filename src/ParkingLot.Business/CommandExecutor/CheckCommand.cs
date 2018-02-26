using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class CheckCommand : ICheckCommand
    {
        private ICommand _command;
        public CheckCommand(ICommand command)
        {
            _command = command;
        }
        public bool AreEqual(string userInputCommand, string command)
        {
            bool areEqual = false;
            if (!string.IsNullOrEmpty(userInputCommand) && !string.IsNullOrEmpty(command))
            {
                string userCommand = _command.GetCommand(userInputCommand);
                if (command.Equals(userCommand))
                {
                    areEqual = true;
                }
            }
            return areEqual;
        }
    }
}
