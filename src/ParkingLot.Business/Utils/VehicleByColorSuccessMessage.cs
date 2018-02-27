using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class VehicleByColorSuccessMessage : IVehicleByColorSuccessMessage
    {
        public string BuildMessage(string[] registrationNumbers)
        {
            string message = string.Empty;
            if (registrationNumbers.Length > 0)
            {
                for(int i = 0; i < registrationNumbers.Length; i++)
                {
                    message += registrationNumbers[i];
                    if (i < registrationNumbers.Length - 1)
                    {
                        message += ", ";
                    }
                }
            }
            return message;
        }
    }
}
