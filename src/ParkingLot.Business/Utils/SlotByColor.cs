using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLot.Business
{
    public class SlotByColor : ISlotByColor
    {
        public List<int> GetSlotNumbers(VehicleDetailsModel[] vehicleDetails, string color)
        {
            List<int> slotNumbers = new List<int>();
            for (int i = 0; i < vehicleDetails.Length; i++)
            {
                if (color.Trim().ToLower().Equals(vehicleDetails[i].Color.Trim().ToLower()))
                {
                    slotNumbers.Add(i+1);
                }
            }
            return slotNumbers;
        }
    }
}
