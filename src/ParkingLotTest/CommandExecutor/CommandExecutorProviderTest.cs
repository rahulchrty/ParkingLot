using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.CommandExecutor
{
    [TestClass]
    public class CommandExecutorProviderTest
    {
        private ICommandExecutorSelector[] _selectors;
        private ICommandExecutorProvier _provider;
        [TestInitialize]
        public void SetUp()
        {
            _selectors = new ICommandExecutorSelector[1];
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_ThenReturnATypeOfICommandExecutor()
        {
            //Given:
            string command = "create_parking_lot";
            //When: I call CommandExecutorProvier object
            _selectors = new ICommandExecutorSelector[1];
            _selectors[0] = new ExecuteSelectorHijack(true);
            _provider = new CommandExecutorProvider(_selectors);
            var result = _provider.InitExecutor(command);
            //Then: I get a type of ICommandExecutor
            Assert.IsInstanceOfType(result, typeof(ICommandExecutor));
        }
        [TestMethod]
        public void GivenCommandAs_EmptyString_ThenReturnNull()
        {
            //Given:
            string command = "";
            //When: I call CommandExecutorProvier object
            _selectors = new ICommandExecutorSelector[1];
            _selectors[0] = new ExecuteSelectorHijack(false);
            _provider = new CommandExecutorProvider(_selectors);
            var result = _provider.InitExecutor(command);
            //Then: I get a type of ICommandExecutor
            Assert.IsNull(result);
        }
    }
}
