namespace ParkingLot.BusinessInterfaces
{
    public interface ICommandExecutorSelector : ICommandExecutor
    {
        bool IsRequireCommandExecutor(string inputString);
    }
}