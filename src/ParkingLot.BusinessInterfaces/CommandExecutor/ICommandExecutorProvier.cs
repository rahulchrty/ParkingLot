namespace ParkingLot.BusinessInterfaces
{
    public interface ICommandExecutorProvier
    {
        ICommandExecutor InitExecutor(string command);
    }
}
