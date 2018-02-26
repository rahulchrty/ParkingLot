using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class MaxSlotIndex : IMaxSlotIndex
    {
        public int GetIndex(int maxSlotLength)
        {
            return maxSlotLength - 1;
        }
    }
}
