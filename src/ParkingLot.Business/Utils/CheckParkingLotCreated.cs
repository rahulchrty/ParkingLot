using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
namespace ParkingLot.Business
{
    public class CheckParkingLotCreated : ICheckParkingLotCreated
    {
        private IParkingLotRepository _parkingLotRepository;
        public CheckParkingLotCreated(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }
        public bool IsCreated()
        {
            bool isCreated = false;
            VehicleDetailsModel[] storage = _parkingLotRepository.GetParkingDetails();
            if (storage != null)
            {
                isCreated = true;
            }
            return isCreated;
        }
    }
}
