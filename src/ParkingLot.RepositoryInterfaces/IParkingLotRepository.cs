using ParkingLot.Model;

namespace ParkingLot.RepositoryInterfaces
{
    public interface IParkingLotRepository
    {
        void CreateParkingSlots(int numberOfSlots);
        int ParkVehicle(VehicleDetailsModel vehicleDetail, int index);
        int GetEmptySlotIndex();
    }
}