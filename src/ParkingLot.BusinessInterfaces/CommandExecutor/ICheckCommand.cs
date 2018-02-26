namespace ParkingLot.BusinessInterfaces
{
    public interface ICheckCommand
    {
        bool AreEqual(string userInputCommand, string commad);
    }
}