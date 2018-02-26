using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLot.BusinessInterfaces
{
    public interface IStatusOutput
    {
        string Build(VehicleDetailsModel[] parlingDetails);
    }
}
