using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System.Collections.Generic;

namespace ParkingLot.Repository
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private List<VehicleDetailsModel> _storage;
        public void CreateParkingSlots(int numberOfSlots)
        {
            _storage = new List<VehicleDetailsModel>(numberOfSlots);
        }
    }
}
