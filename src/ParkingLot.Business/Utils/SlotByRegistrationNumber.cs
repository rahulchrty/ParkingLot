using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;

namespace ParkingLot.Business
{
    public class SlotByRegistrationNumber : ISlotByRegistrationNumber
    {
        public int GetSlotNumber(VehicleDetailsModel[] vehicleDetails, string registrationNumber)
        {
            int slotnumber = -1;
            for (int i = 0; i < vehicleDetails.Length && slotnumber == -1; i++)
            {
                if (registrationNumber.Trim().ToString().Equals(vehicleDetails[i].RegistrationNumber.Trim().ToString()))
                {
                    slotnumber = i + 1;
                }
            }
            return slotnumber;
        }
    }
}
