using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLot.RepositoryInterfaces
{
    public interface IParkingLotRepository
    {
        void CreateParkingSlots(int numberOfSlots);
        int ParkVehicle(VehicleDetailsModel vehicleDetail, int index);
        int GetEmptySlotIndex();
        void EmptyASlot(int index);
        int TotalSlotAllocated();
        VehicleDetailsModel[] GetParkingDetails();
    }
}