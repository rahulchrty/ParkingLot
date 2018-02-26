using ParkingLot.Model;

namespace ParkingLot.BusinessInterfaces
{
    public interface IParkingVehicle
    {
        VehicleDetailsModel GetDetail(string command);
    }
}
