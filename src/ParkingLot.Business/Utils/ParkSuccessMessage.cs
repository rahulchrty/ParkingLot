using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class ParkSuccessMessage : IParkSuccessMessage
    {
        public string CreateMessage(int slotIndex)
        {
            string message = string.Empty;
            int slotNumber = slotIndex + 1;
            message = "Allocated slot number: " + slotNumber;
            return message;
        }
    }
}
