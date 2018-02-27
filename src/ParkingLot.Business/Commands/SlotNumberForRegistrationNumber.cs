using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class SlotNumberForRegistrationNumber : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private IVehicleRegistrationNumber _vehicleRegistrationNumber;
        private IParkingLotRepository _parkingRepository;
        private ISlotByRegistrationNumber _slotByRegistrationNumber;
        public SlotNumberForRegistrationNumber(ICheckCommand checkCommand,
                        IVehicleRegistrationNumber vehicleRegistrationNumber,
                        IParkingLotRepository parkingRepository,
                        ISlotByRegistrationNumber slotByRegistrationNumber)
        {
            _checkCommand = checkCommand;
            _vehicleRegistrationNumber = vehicleRegistrationNumber;
            _parkingRepository = parkingRepository;
            _slotByRegistrationNumber = slotByRegistrationNumber;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "slot_number_for_registration_number");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                string registrationNumber = _vehicleRegistrationNumber.GetNumber(command);
                VehicleDetailsModel[] vehicleDetails = _parkingRepository.GetParkingDetails();
                int slot = _slotByRegistrationNumber.GetSlotNumber(vehicleDetails, registrationNumber);
                if (slot > 0)
                {
                    message = slot.ToString();
                }
                else
                {
                    message = "Not found";
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
