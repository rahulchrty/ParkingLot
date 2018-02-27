using System.Collections.Generic;

namespace ParkingLot.BusinessInterfaces
{
    public interface ISlotByColorMessage
    {
        string BuildMessage(List<int> slotList);
    }
}
