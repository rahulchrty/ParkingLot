using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.CommandExecutor
{
    [TestClass]
    public class ParkTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<IValidateVeicleDetails> _mockValidateVeicleDetails;
        private Mock<IParkingVehicle> _mockParkingVehicle;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<IParkSuccessMessage> _mockParkSuccessMessage;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockValidateVeicleDetails = new Mock<IValidateVeicleDetails>();
            _mockParkingVehicle = new Mock<IParkingVehicle>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockParkSuccessMessage = new Mock<IParkSuccessMessage>();
            _commandExecutorSelector = new Park(_mockCheckCommand.Object, _mockValidateVeicleDetails.Object,
                                                    _mockParkingVehicle.Object, _mockParkingRepository.Object,
                                                    _mockParkSuccessMessage.Object);
        }
        [TestMethod]
        public void ExecuteCommand()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call Park object
            VehicleDetailsModel vehivleDetail = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1234",
                Color = "White"
            };
            _mockParkingVehicle.Setup(x => x.GetDetail(It.IsAny<string>())).Returns(vehivleDetail);
            _mockValidateVeicleDetails.Setup(x => x.Validate(It.IsAny<VehicleDetailsModel>())).Returns(string.Empty);
            _mockParkingRepository.Setup(x => x.GetEmptySlotIndex()).Returns(0);
            _mockParkingRepository.Setup(x => x.ParkVehicle(It.IsAny<VehicleDetailsModel>(), It.IsAny<int>())).Returns(0);
            _mockParkSuccessMessage.Setup(x => x.CreateMessage(It.IsAny<int>())).Returns("Allocated slot number: 1");
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: Method Validate, GetDetail, GetEmptySlotIndex, ParkVehicle, CreateMessage executes once
            _mockParkingVehicle.Verify(x => x.GetDetail(It.IsAny<string>()), Times.Once());
            _mockValidateVeicleDetails.Verify(x => x.Validate(It.IsAny<VehicleDetailsModel>()), Times.Once());
            _mockParkingRepository.Verify(x => x.GetEmptySlotIndex(), Times.Once());
            _mockParkingRepository.Verify(x => x.ParkVehicle(It.IsAny<VehicleDetailsModel>(), It.IsAny<int>()), Times.Once());
            _mockParkSuccessMessage.Verify(x => x.CreateMessage(It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void GivenNoVehicleDetails()
        {
            //Given: command as 'park'
            string command = "park";
            //When: I call Park object
            VehicleDetailsModel vehivleDetail = null;
            _mockParkingVehicle.Setup(x => x.GetDetail(It.IsAny<string>())).Returns(vehivleDetail);
            _mockValidateVeicleDetails.Setup(x => x.Validate(It.IsAny<VehicleDetailsModel>())).Returns("Please provide all require details");
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: Method GetEmptySlotIndex, ParkVehicle, CreateMessage never executes
            _mockParkingRepository.Verify(x => x.GetEmptySlotIndex(), Times.Never());
            _mockParkingRepository.Verify(x => x.ParkVehicle(It.IsAny<VehicleDetailsModel>(), It.IsAny<int>()), Times.Never());
            _mockParkSuccessMessage.Verify(x => x.CreateMessage(It.IsAny<int>()), Times.Never());
        }
        [TestMethod]
        public void ExecuteCommand_When_Slot_Are_Full()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call Park object
            VehicleDetailsModel vehivleDetail = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1234",
                Color = "White"
            };
            _mockParkingVehicle.Setup(x => x.GetDetail(It.IsAny<string>())).Returns(vehivleDetail);
            _mockValidateVeicleDetails.Setup(x => x.Validate(It.IsAny<VehicleDetailsModel>())).Returns(string.Empty);
            _mockParkingRepository.Setup(x => x.GetEmptySlotIndex()).Returns(-1);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: Method Validate, GetDetail, GetEmptySlotIndex, ParkVehicle, CreateMessage executes once
            _mockParkingVehicle.Verify(x => x.GetDetail(It.IsAny<string>()), Times.Once());
            _mockValidateVeicleDetails.Verify(x => x.Validate(It.IsAny<VehicleDetailsModel>()), Times.Once());
            _mockParkingRepository.Verify(x => x.GetEmptySlotIndex(), Times.Once());
        }
        [TestMethod]
        public void ExecuteCommand_When_Slot_Are_Full_Then_Get_AllSlotsAreFull()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call Park object
            VehicleDetailsModel vehivleDetail = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1234",
                Color = "White"
            };
            _mockParkingVehicle.Setup(x => x.GetDetail(It.IsAny<string>())).Returns(vehivleDetail);
            _mockValidateVeicleDetails.Setup(x => x.Validate(It.IsAny<VehicleDetailsModel>())).Returns(string.Empty);
            _mockParkingRepository.Setup(x => x.GetEmptySlotIndex()).Returns(-1);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get 'All slots are full'
            string expected = "All slots are full";
            Assert.AreEqual(expected, result);
        }
    }
}
