using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class RegistrationNumbersForCarsWithColour : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private IVehicleColor _vehicleColor;
        private IParkingLotRepository _parkingRepository;
        private IVehicleByColor _vehicleByColor;
        private IVehicleByColorSuccessMessage _vehicleByColorSuccessMessage;
        public RegistrationNumbersForCarsWithColour(ICheckCommand checkCommand,
                        IVehicleColor vehicleColor,
                        IParkingLotRepository parkingRepository,
                        IVehicleByColor vehicleByColor,
                        IVehicleByColorSuccessMessage vehicleByColorSuccessMessage)
        {
            _checkCommand = checkCommand;
            _vehicleColor = vehicleColor;
            _parkingRepository = parkingRepository;
            _vehicleByColor = vehicleByColor;
            _vehicleByColorSuccessMessage = vehicleByColorSuccessMessage;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "registration_numbers_for_cars_with_colour");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                string color = _vehicleColor.GetColor(command);
                VehicleDetailsModel[] vehicleDetails = _parkingRepository.GetParkingDetails();
                string[] registrationNumber = _vehicleByColor.GetRegistrationNumbers(vehicleDetails, color);
                if (registrationNumber.Length > 0)
                {
                    message = _vehicleByColorSuccessMessage.BuildMessage(registrationNumber);
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
