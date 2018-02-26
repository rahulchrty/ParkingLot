using ParkingLot.BusinessInterfaces;
using ParkingLot.Model;
using System.Text;

namespace ParkingLot.Business
{
    public class StatusOutput : IStatusOutput
    {
        public string Build(VehicleDetailsModel[] parlingDetails)
        {
            StringBuilder statusBuilder = new StringBuilder();
            statusBuilder.AppendLine("Slot No.   Registration No   Colour");
            for (int i = 0; i < parlingDetails.Length; i++)
            {
                if (parlingDetails[i] != null)
                {
                    int slot = i + 1;
                    statusBuilder.AppendLine(slot + "   " + parlingDetails[i].RegistrationNumber + "   " + parlingDetails[i].Color);
                }
            }
            return statusBuilder.ToString();
        }
    }
}
