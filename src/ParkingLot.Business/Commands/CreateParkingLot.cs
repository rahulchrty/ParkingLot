using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;

namespace ParkingLot.Business
{
    public class CreateParkingLot : ICommandExecutorSelector
    {
        private ICommand _command;
        private ISlot _slot;
        private IParkingLotRepository _parkingRepository;
        public CreateParkingLot(ICommand command,
                                ISlot slot,
                                IParkingLotRepository parkingRepository)
        {
            _command = command;
            _slot = slot;
            _parkingRepository = parkingRepository;
        }
        public bool IsRequireCommandExecutor(string inputString)
        {
            bool isRequiredExecutor = false;
            string command = _command.GetCommand(inputString);
            if (command.Equals("create_parking_lot"))
            {
                isRequiredExecutor = true;
            }
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            int allocableSize = _slot.GetSlotSize(command);
            if (allocableSize > 0)
            {
                _parkingRepository.CreateParkingSlots(allocableSize);
                message = "Created a parking lot with " + allocableSize + " slots";
            }
            else
            {
                message = "Invalid slot size";
            }
            return message;
        }
    }
}
