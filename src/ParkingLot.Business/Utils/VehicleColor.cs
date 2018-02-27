using ParkingLot.BusinessInterfaces;

namespace ParkingLot.Business
{
    public class VehicleColor : IVehicleColor
    {
        public string GetColor(string userInputColor)
        {
            string color = string.Empty;
            if (!string.IsNullOrEmpty(userInputColor))
            {
                if (userInputColor.Trim().IndexOf(' ') > -1)
                {
                    color = userInputColor.Trim().Split(' ')[1];
                }
            }
            return color;
        }
    }
}
