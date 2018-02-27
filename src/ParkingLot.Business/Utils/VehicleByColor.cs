using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using System.Linq;

namespace ParkingLot.Business
{
    public class VehicleByColor : IVehicleByColor
    {
        public string[] GetRegistrationNumbers(VehicleDetailsModel[] vehicleDetails, string color)
        {
            string[] vehicleNumber;
            vehicleNumber = (from vehicle in vehicleDetails
                             where color.ToLower().Trim().Equals(vehicle.Color.ToLower().Trim())
                             select vehicle.RegistrationNumber).ToArray();
            return vehicleNumber;
        }
    }
}
