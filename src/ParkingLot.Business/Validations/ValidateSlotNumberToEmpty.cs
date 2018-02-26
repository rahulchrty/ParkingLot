using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
namespace ParkingLot.Business
{
    public class ValidateSlotNumberToEmpty : IValidateSlotNumberToEmpty
    {
        private IParkingLotRepository _parkingLotRepository;
        private IMaxSlotIndex _maxSlotIndex;
        public ValidateSlotNumberToEmpty(IParkingLotRepository parkingLotRepository,
                                        IMaxSlotIndex maxSlotIndex)
        {
            _parkingLotRepository = parkingLotRepository;
            _maxSlotIndex = maxSlotIndex;
        }
        public string ValidateSlotNumber(int slotIndex)
        {
            string message = string.Empty;
            int maxSlots = _parkingLotRepository.TotalSlotAllocated();
            int maxSlotIndex = _maxSlotIndex.GetIndex(maxSlots);
            if (slotIndex < 0)
            {
                message = "Invalid slot number";
            }
            else if (slotIndex > maxSlotIndex)
            {
                message = "Invalid slot number. Maximum possible paking is " + maxSlots;
            }
            return message;
        }
    }
}
