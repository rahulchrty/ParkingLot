using ParkingLot.BusinessInterfaces;
using System.Collections.Generic;

namespace ParkingLot.Business
{
    public class SlotByColorMessage : ISlotByColorMessage
    {
        public string BuildMessage(List<int> slotList)
        {
            string slots = string.Empty;
            for (int i = 0; i < slotList.Count; i++)
            {
                slots += slotList[i];
                if (i < slotList.Count - 1)
                {
                    slots += ", ";
                }
            }
            return slots;
        }
    }
}
