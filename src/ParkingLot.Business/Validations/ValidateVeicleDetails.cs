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
                message = "Please provide all require details";
            }
            return message;
        }
    }
}
