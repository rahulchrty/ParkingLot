using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;

namespace ParkingLot.Business
{
    public class ValidateVeicleDetails : IValidateVeicleDetails
    {
        public string Validate(VehicleDetailsModel vehivleDetail)
        {
            string message = string.Empty;
            if (vehivleDetail == null)
            {
                message = "Invalid vehicle details";
            }
            return message;
        }
    }
}