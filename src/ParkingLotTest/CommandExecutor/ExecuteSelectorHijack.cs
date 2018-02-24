using ParkingLot.BusinessInterfaces;

namespace ParkingLotTest.CommandExecutor
{
    public class ExecuteSelectorHijack : ICommandExecutorSelector
    {
        private bool _setIsRequireMockResult;
        public ExecuteSelectorHijack(bool setIsRequireMockResult)
        {
            _setIsRequireMockResult = setIsRequireMockResult;
        }
        public bool IsRequireCommandExecutor(string command)
        {
            return _setIsRequireMockResult;
        }
        public string ExecuteCommand(string command)
        {
            return string.Empty;
        }
    }
}
