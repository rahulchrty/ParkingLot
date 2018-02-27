using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Business
{
    public class Status : ICommandExecutorSelector
    {
        private IParkingLotRepository _parkingRepository;
        private IStatusOutput _statusOutput;
        public Status(IParkingLotRepository parkingRepository,
                        IStatusOutput statusOutput)
        {
            _parkingRepository = parkingRepository;
            _statusOutput = statusOutput;
        }
        public bool IsRequireCommandExecutor(string userInputCommand)
        {
            bool isRequiredExecutor = false;
            if (userInputCommand.Trim().ToLower().Equals("status"))
            {
                isRequiredExecutor = true;
            }
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
