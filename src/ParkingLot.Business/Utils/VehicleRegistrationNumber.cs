using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class VehicleRegistrationNumber : IVehicleRegistrationNumber
    {
        public string GetNumber(string userInputCommand)
        {
            string registrationNumber = string.Empty;
            if (!string.IsNullOrEmpty(userInputCommand))
            {
                if (userInputCommand.Trim().IndexOf(' ') > -1)
                {
                    registrationNumber = userInputCommand.Trim().Split(' ')[1];
                }
            }
            return registrationNumber;
        }
    }
}
