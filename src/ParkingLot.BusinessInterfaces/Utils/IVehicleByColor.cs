using ParkingLot.Model;

namespace ParkingLot.BusinessInterfaces
{
    public interface IVehicleByColor
    {
        string[] GetRegistrationNumbers(VehicleDetailsModel[] vehicleDetails, string color);
    }
}
