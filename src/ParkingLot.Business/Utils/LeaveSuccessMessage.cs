using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class LeaveSuccessMessage : ILeaveSuccessMessage
    {
        public string CreateMessage(int slotIndex)
        {
            string message = string.Empty;
            int slotNumber = slotIndex + 1;
            message = "Slot number " + slotNumber + " is free";
            return message;
        }
    }
}
