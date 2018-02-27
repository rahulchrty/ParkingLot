using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLot.BusinessInterfaces
{
    public interface ISlotByColor
    {
        List<int> GetSlotNumbers(VehicleDetailsModel[] vehicleDetails, string color);
    }
}
