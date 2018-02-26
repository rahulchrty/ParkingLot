using ParkingLot.BusinessInterfaces;
using System;

namespace ParkingLot.Business
{
    public class SlotToEmpty : ISlotToEmpty
    {
        public int GetNumber(string userInputCommand)
        {
            int slotIndex = -1;
            int slot;
            if (!string.IsNullOrEmpty(userInputCommand))
            {
                if (userInputCommand.Trim().IndexOf(' ') > -1)
                {
                    string number = userInputCommand.Trim().Split(' ')[1];
                    if (Int32.TryParse(number, out slot))
                    {
                        slotIndex = slot - 1;
                    }
                }
            }
            return slotIndex;
        }
    }
}
