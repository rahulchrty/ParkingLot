using ParkingLot.Model;

namespace ParkingLot.BusinessInterfaces
{
    public interface ISlotByRegistrationNumber
    {
        int GetSlotNumber(VehicleDetailsModel[] vehicleDetails, string registrationNumber);
    }
}
