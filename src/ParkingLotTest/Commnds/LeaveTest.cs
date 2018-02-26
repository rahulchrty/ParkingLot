using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using Moq;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest
{
    [TestClass]
    public class LeaveTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<ISlotToEmpty> _mockSlotToEmpty;
        private Mock<IValidateSlotNumberToEmpty> _mockValidateSlotNumberToEmpty;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<ILeaveSuccessMessage> _mockLeaveSuccessMessage;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockSlotToEmpty = new Mock<ISlotToEmpty>();
            _mockValidateSlotNumberToEmpty = new Mock<IValidateSlotNumberToEmpty>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockLeaveSuccessMessage = new Mock<ILeaveSuccessMessage>();
            _commandExecutorSelector = new Leave(_mockCheckCommand.Object, _mockSlotToEmpty.Object,
                                        _mockValidateSlotNumberToEmpty.Object, _mockParkingRepository.Object,
                                        _mockLeaveSuccessMessage.Object);
        }
        [TestMethod]
        public void Given_leave4()
        {
            //Given: command as 'leave 4'
            string command = "leave 4";
            //When: I call Leave object
            _mockSlotToEmpty.Setup(x => x.GetNumber(It.IsAny<string>())).Returns(3);
            _mockValidateSlotNumberToEmpty.Setup(x => x.ValidateSlotNumber(It.IsAny<int>())).Returns(string.Empty);
            _mockParkingRepository.Setup(x => x.EmptyASlot(It.IsAny<int>()));
            _mockLeaveSuccessMessage.Setup(x=>x.CreateMessage(It.IsAny<int>())).Returns("Slot number 4 is free");
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: EmptyASlot and CreateMessage executes
            _mockParkingRepository.Verify(x => x.EmptyASlot(It.IsAny<int>()));
            _mockLeaveSuccessMessage.Verify(x => x.CreateMessage(It.IsAny<int>()));
        }
        [TestMethod]
        public void Given_leave4_Get_Conformation_Message()
        {
            //Given: command as 'leave 4'
            string command = "leave 4";
            //When: I call Leave object
            _mockSlotToEmpty.Setup(x => x.GetNumber(It.IsAny<string>())).Returns(3);
            _mockValidateSlotNumberToEmpty.Setup(x => x.ValidateSlotNumber(It.IsAny<int>())).Returns(string.Empty);
            _mockParkingRepository.Setup(x => x.EmptyASlot(It.IsAny<int>()));
            _mockLeaveSuccessMessage.Setup(x => x.CreateMessage(It.IsAny<int>())).Returns("Slot number 4 is free");
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get 'Slot number 4 is free'
            string expected = "Slot number 4 is free";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_AnInvalidSlotNumber()
        {
            //Given: command as 'leave 10'
            string command = "leave 10";
            //When: I call Leave object
            _mockSlotToEmpty.Setup(x => x.GetNumber(It.IsAny<string>())).Returns(0);
            _mockValidateSlotNumberToEmpty.Setup(x => x.ValidateSlotNumber(It.IsAny<int>())).Returns("Invalid slot number");
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get 'Invalid slot number'
            _mockParkingRepository.Verify(x => x.EmptyASlot(It.IsAny<int>()), Times.Never());
            _mockLeaveSuccessMessage.Verify(x => x.CreateMessage(It.IsAny<int>()), Times.Never());
        }
    }
}
