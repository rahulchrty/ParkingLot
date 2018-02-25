using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using Moq;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.CommandExecutor
{
    [TestClass]
    public class CreateParkingLotProviderTest
    {
        private Mock<ICommand> _mockCommand;
        private Mock<ISlot> _mockSlot;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCommand = new Mock<ICommand>();
            _mockSlot = new Mock<ISlot>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _commandExecutorSelector = new CreateParkingLot(_mockCommand.Object, _mockSlot.Object, _mockParkingRepository.Object);
        }
        [TestMethod]
        public void GivenCommand_create_parking_lot_6_Then_Get_true()
        {
            //Given: command as 'create_parking_lot 6'
            string command = "create_parking_lot 6";
            //When: I call CreateParkingLot object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("create_parking_lot");
            bool result = _commandExecutorSelector.IsRequireCommandExecutor(command);
            //Then: I get true
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenCommand_Create_Parking_Lot_6_Then_Get_false()
        {
            //Given: command as 'Create_Parking_Lot 6'
            string command = "Create_Parking_Lot 6";
            //When: I call CreateParkingLot object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("Create_Parking_Lot");
            bool result = _commandExecutorSelector.IsRequireCommandExecutor(command);
            //Then: I get false
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenCommand_park_1234_Green_Then_Get_false()
        {
            //Given: command as 'park 1234 Green'
            string command = "park 1234 Green";
            //When: I call CreateParkingLot object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("park");
            bool result = _commandExecutorSelector.IsRequireCommandExecutor(command);
            //Then: I get false
            Assert.IsFalse(result);
        }
    }
}
