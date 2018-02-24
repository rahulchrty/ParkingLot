using ParkingLot.BusinessInterfaces;
using System.Linq;

namespace ParkingLot.Business.CommandExecutor
{
    public class CommandExecutorProvier : ICommandExecutorProvier
    {
        private ICommandExecutorSelector[] _selectors;
        public CommandExecutorProvier(ICommandExecutorSelector[] selectors)
        {
            _selectors = selectors;
        }
        public ICommandExecutor InitExecutor(string command)
        {
            ICommandExecutor executor = null;
            executor = _selectors.FirstOrDefault(x => x.IsRequireCommandExecutor(command));
            return executor;
        }
    }
}
