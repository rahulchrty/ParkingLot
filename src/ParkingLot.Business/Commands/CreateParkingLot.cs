using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class CreateParkingLot : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private ISlot _slot;
        private ICheckParkingLotCreated _checkParkingLotCreated;
        private IParkingLotRepository _parkingRepository;
        public CreateParkingLot(ICheckCommand checkCommand,
                                ISlot slot,
                                ICheckParkingLotCreated checkParkingLotCreated,
                                IParkingLotRepository parkingRepository)
        {
            _checkCommand = checkCommand;
            _slot = slot;
            _checkParkingLotCreated = checkParkingLotCreated;
            _parkingRepository = parkingRepository;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "create_parking_lot");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                int allocableSize = _slot.GetSlotSize(command);
                if (allocableSize > 0)
                {
                    bool isCreated = _checkParkingLotCreated.IsCreated();
                    if (!isCreated)
                    {
                        _parkingRepository.CreateParkingSlots(allocableSize);
                        message = "Created a parking lot with " + allocableSize + " slots";
                    }
                    else
                    {
                        message = "Parking lot alread created";
                    }
                }
                else
                {
                    message = "Invalid slot size";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
