using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;

namespace ParkingLot.Business
{
    public class ParkingVehicle : IParkingVehicle
    {
        public VehicleDetailsModel GetDetail(string command)
        {
            VehicleDetailsModel vehicleDetail = null;
            if (!string.IsNullOrEmpty(command))
            {
                string[] vehicleData = command.Trim().Split(' ');
                if (vehicleData.Length == 3)
                {
                    vehicleDetail = new VehicleDetailsModel
                    {
                        RegistrationNumber = vehicleData[1],
                        Color = vehicleData[2]
                    };
                }
            }
            return vehicleDetail;
        }
    }
}