using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class Status : ICommandExecutorSelector
    {
        private ICheckCommand _checkCommand;
        private IParkingLotRepository _parkingRepository;
        private IStatusOutput _statusOutput;
        public Status(ICheckCommand checkCommand,
                        IParkingLotRepository parkingRepository,
                        IStatusOutput statusOutput)
        {
            _checkCommand = checkCommand;
            _parkingRepository = parkingRepository;
            _statusOutput = statusOutput;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            isRequiredExecutor = _checkCommand.AreEqual(userInputCommand, "status");
            return isRequiredExecutor;
        }
        public string ExecuteCommand(string command)
        {
            string message = string.Empty;
            try
            {
                VehicleDetailsModel[] parlingDetails = _parkingRepository.GetParkingDetails();
                message = _statusOutput.Build(parlingDetails);
                return message;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
