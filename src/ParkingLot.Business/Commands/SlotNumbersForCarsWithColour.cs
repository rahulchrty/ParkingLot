using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace ParkingLot.Business
{
    public class SlotNumbersForCarsWithColour : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private IVehicleColor _vehicleColor;
        private IParkingLotRepository _parkingRepository;
        private ISlotByColor _slotByColor;
        private ISlotByColorMessage _slotByColorMessage;
        public SlotNumbersForCarsWithColour(ICheckCommand checkCommand,
                        IVehicleColor vehicleColor,
                        IParkingLotRepository parkingRepository,
                        ISlotByColor slotByColor,
                        ISlotByColorMessage slotByColorMessage)
        {
            _checkCommand = checkCommand;
            _vehicleColor = vehicleColor;
            _parkingRepository = parkingRepository;
            _slotByColor = slotByColor;
            _slotByColorMessage = slotByColorMessage;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "slot_numbers_for_cars_with_colour");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                string color = _vehicleColor.GetColor(command);
                VehicleDetailsModel[] vehicleDetails = _parkingRepository.GetParkingDetails();
                List<int> slotList = _slotByColor.GetSlotNumbers(vehicleDetails, color);
                if (slotList.Count > 0)
                {
                    message = _slotByColorMessage.BuildMessage(slotList);
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
