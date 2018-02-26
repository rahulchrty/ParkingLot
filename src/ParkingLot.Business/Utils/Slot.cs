using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class Slot : ISlot
    {
        public int GetSlotSize(string command)
        {
            int slotSize = 0;
            if (!string.IsNullOrEmpty(command))
            {
                if (command.IndexOf(' ') > -1)
                {
                    string slot = command.Split(' ')[1];
                    bool isValidSlot = int.TryParse(slot, out slotSize);
                }
            }
            return slotSize;
        }
    }
}