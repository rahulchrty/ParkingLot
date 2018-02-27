namespace ParkingLot.BusinessInterfaces
{
    public interface IVehicleByColorSuccessMessage
    {
        string BuildMessage(string[] registrationNumbers);
    }
}
