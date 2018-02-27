using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using Moq;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Commnds
{
    [TestClass]
    public class SlotNumberForRegistrationNumberTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<IVehicleRegistrationNumber> _mockVehicleRegistrationNumber;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<ISlotByRegistrationNumber> _mockSlotByRegistrationNumber;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockVehicleRegistrationNumber = new Mock<IVehicleRegistrationNumber>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockSlotByRegistrationNumber = new Mock<ISlotByRegistrationNumber>();
            _commandExecutorSelector = new SlotNumberForRegistrationNumber(_mockCheckCommand.Object, _mockVehicleRegistrationNumber.Object,
                                        _mockParkingRepository.Object, _mockSlotByRegistrationNumber.Object);
        }
        [TestMethod]
        public void RegistrationNumberFound()
        {
            //Given: Command as 'slot_number_for_registration_number KA-01-HH-3141'
            string command = "slot_number_for_registration_number KA-01-HH-3141";
            //When: I call SlotNumberForRegistrationNumber object
            _mockVehicleRegistrationNumber.Setup(x => x.GetNumber(It.IsAny<string>())).Returns("KA-01-HH-3141");
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "KA-01-HH-3141"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(vehicleDetails);
            _mockSlotByRegistrationNumber.Setup(x=>x.GetSlotNumber(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(1);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get '1'
            Assert.AreEqual("1", result);
        }
        [TestMethod]
        public void RegistrationNumberNotFound()
        {
            //Given: Command as 'slot_number_for_registration_number KA-01-HH-3141'
            string command = "slot_number_for_registration_number KA-01-HH-3141";
            //When: I call SlotNumberForRegistrationNumber object
            _mockVehicleRegistrationNumber.Setup(x => x.GetNumber(It.IsAny<string>())).Returns("KA-01-HH-3141");
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "KA-01-HH-3142"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(vehicleDetails);
            _mockSlotByRegistrationNumber.Setup(x => x.GetSlotNumber(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(-1);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get 'Not found'
            string expected = "Not found";
            Assert.AreEqual(expected, result);
        }
    }
}
