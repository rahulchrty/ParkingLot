using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class Park : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private IValidateVeicleDetails _validateVeicleDetails;
        private IParkingVehicle _parkingVehicle;
        private IParkingLotRepository _parkingRepository;
        private IParkSuccessMessage _parkSuccessMessage;
        public Park(ICheckCommand checkCommand,
                    IValidateVeicleDetails validateVeicleDetails,
                    IParkingVehicle parkingVehicle,
                    IParkingLotRepository parkingRepository,
                    IParkSuccessMessage parkSuccessMessage)
        {
            _checkCommand = checkCommand;
            _validateVeicleDetails = validateVeicleDetails;
            _parkingVehicle = parkingVehicle;
            _parkingRepository = parkingRepository;
            _parkSuccessMessage = parkSuccessMessage;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "park");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            int slotNumber = 0;
            try
            {
                VehicleDetailsModel vehicleDetail = _parkingVehicle.GetDetail(command);
                message = _validateVeicleDetails.Validate(vehicleDetail);
                if (string.IsNullOrEmpty(message))
                {
                    int slotIndex = _parkingRepository.GetEmptySlotIndex();
                    if (slotIndex > -1)
                    {
                        slotNumber = _parkingRepository.ParkVehicle(vehicleDetail, slotIndex);
                        message = _parkSuccessMessage.CreateMessage(slotNumber);
                    }
                    else
                    {
                        message = "All slots are full";
                    }
                }
                return message;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
