using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class Leave : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private ISlotToEmpty _slotToEmpty;
        private IValidateSlotNumberToEmpty _validateSlotNumberToEmpty;
        private IParkingLotRepository _parkingRepository;
        private ILeaveSuccessMessage _leaveSuccessMessage;
        public Leave(ICheckCommand checkCommand,
                    ISlotToEmpty slotToEmpty,
                    IValidateSlotNumberToEmpty validateSlotNumberToEmpty,
                    IParkingLotRepository parkingRepository,
                    ILeaveSuccessMessage leaveSuccessMessage)
        {
            _checkCommand = checkCommand;
            _slotToEmpty = slotToEmpty;
            _validateSlotNumberToEmpty = validateSlotNumberToEmpty;
            _parkingRepository = parkingRepository;
            _leaveSuccessMessage = leaveSuccessMessage;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "leave");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                int slotNumber = _slotToEmpty.GetNumber(command);
                message = _validateSlotNumberToEmpty.ValidateSlotNumber(slotNumber);
                if (string.IsNullOrEmpty(message))
                {
                    _parkingRepository.EmptyASlot(slotNumber);
                    message = _leaveSuccessMessage.CreateMessage(slotNumber);
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
