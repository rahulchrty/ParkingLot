using ParkingLot.BusinessInterfaces;

namespace ParkingLotTest.BehaviourHijack
{
    public class MockCommandExecutor : ICommandExecutor
    {
        public string ExecuteCommand(string command)
        {
            return "Created a parking lot with 4 slots";
        }
    }
}
