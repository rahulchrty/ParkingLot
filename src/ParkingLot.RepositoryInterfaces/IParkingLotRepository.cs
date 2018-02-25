using ParkingLot.Model;

namespace ParkingLot.RepositoryInterfaces
{
    public interface IParkingLotRepository
    {
        void CreateParkingSlots(int numberOfSlots);
    }
}
