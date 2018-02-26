using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using Moq;
using ParkingLot.Business;

namespace ParkingLotTest.CommandExecutor
{
    [TestClass]
    public class CheckCommandTest
    {
        private Mock<ICommand> _mockCommand;
        private ICheckCommand _checkCommand;
        [TestInitialize]
        public void SetUp()
        {
            _mockCommand = new Mock<ICommand>();
            _checkCommand = new CheckCommand(_mockCommand.Object);
        }
        [TestMethod]
        public void WhenCommandsMatchesReturnTrue()
        {
            //Given: userInputCommand as 'create_parking_lot 6'
            //And: command as 'create_parking_lot'
            string userInputCommand = "create_parking_lot 6";
            string command = "create_parking_lot";
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("create_parking_lot");
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get true
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenUserInputCommandContainsCapital_Then_Return_False()
        {
            //Given: userInputCommand as 'Park KA-01-HH-1234 White'
            //And: command as 'park'
            string userInputCommand = "Park KA-01-HH-1234 White";
            string command = "park";
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("Park");
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get false
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenBothCommandsAreDifferentThenGetFlase()
        {
            //Given: userInputCommand as 'create_parking_lot 4'
            //And: command as 'park'
            string userInputCommand = "create_parking_lot 4";
            string command = "park";
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("create_parking_lot");
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get false
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenUserCommandEmptyThenGetFlase()
        {
            //Given: userInputCommand as ''
            //And: command as 'park'
            string userInputCommand = string.Empty;
            string command = "park";
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns(string.Empty);
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get false
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenCommandEmptyThenGetFlase()
        {
            //Given: userInputCommand as 'create_parking_lot 100'
            //And: command as ''
            string userInputCommand = "create_parking_lot 100";
            string command = string.Empty;
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns("create_parking_lot");
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get false
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenBothCommandEmptyThenGetFlase()
        {
            //Given: userInputCommand as ''
            //And: command as ''
            string userInputCommand = string.Empty;
            string command = string.Empty;
            //When : I call CheckCommand object
            _mockCommand.Setup(x => x.GetCommand(It.IsAny<string>())).Returns(string.Empty);
            bool result = _checkCommand.AreEqual(userInputCommand, command);
            //Then: I get false
            Assert.IsFalse(result);
        }
    }
}