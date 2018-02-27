using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLotTest.Commnds
{
    [TestClass]
    public class SlotNumbersForCarsWithColourTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<IVehicleColor> _mockVehicleColor;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<ISlotByColor> _mockSlotByColor;
        private Mock<ISlotByColorMessage> _mockSlotByColorMessage;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockVehicleColor = new Mock<IVehicleColor>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockSlotByColor = new Mock<ISlotByColor>();
            _mockSlotByColorMessage = new Mock<ISlotByColorMessage>();
            _commandExecutorSelector = new SlotNumbersForCarsWithColour(_mockCheckCommand.Object, _mockVehicleColor.Object,
                                        _mockParkingRepository.Object, _mockSlotByColor.Object, _mockSlotByColorMessage.Object);
        }
        [TestMethod]
        public void ExecuteCommand()
        {
            //Given: command as "slot_numbers_for_cars_with_colour White"
            string command = "slot_numbers_for_cars_with_colour White";
            //When: I call SlotNumbersForCarsWithColour object
            _mockVehicleColor.Setup(x => x.GetColor(It.IsAny<string>())).Returns("White");
            VehicleDetailsModel[] cars = new VehicleDetailsModel[1];
            cars[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "white"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(cars);
            List<int> slotList = new List<int>();
            slotList.Add(1);
            _mockSlotByColor.Setup(x => x.GetSlotNumbers(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(slotList);
            _mockSlotByColorMessage.Setup(x => x.BuildMessage(It.IsAny<List<int>>())).Returns("1");
            _commandExecutorSelector.ExecuteCommand(command);
            //Then: method BuildMessage executes
            _mockSlotByColorMessage.Verify(x => x.BuildMessage(It.IsAny<List<int>>()));
        }
        [TestMethod]
        public void FoundNoCarParkedWithGivenColorThenMethodBuildMessageNeverExecutes()
        {
            //Given: command as "slot_numbers_for_cars_with_colour White"
            string command = "slot_numbers_for_cars_with_colour White";
            //When: I call SlotNumbersForCarsWithColour object
            _mockVehicleColor.Setup(x => x.GetColor(It.IsAny<string>())).Returns("White");
            VehicleDetailsModel[] cars = new VehicleDetailsModel[1];
            cars[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "blue"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(cars);
            List<int> slotList = new List<int>();
            _mockSlotByColor.Setup(x => x.GetSlotNumbers(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(slotList);
            _commandExecutorSelector.ExecuteCommand(command);
            //Then: method BuildMessage executes
            _mockSlotByColorMessage.Verify(x => x.BuildMessage(It.IsAny<List<int>>()), Times.Never());
        }
        [TestMethod]
        public void FoundNoCarParkedWithGivenColorThenGetNotFoundMessage()
        {
            //Given: command as "slot_numbers_for_cars_with_colour White"
            string command = "slot_numbers_for_cars_with_colour White";
            //When: I call SlotNumbersForCarsWithColour object
            _mockVehicleColor.Setup(x => x.GetColor(It.IsAny<string>())).Returns("White");
            VehicleDetailsModel[] cars = new VehicleDetailsModel[1];
            cars[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "blue"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(cars);
            List<int> slotList = new List<int>();
            _mockSlotByColor.Setup(x => x.GetSlotNumbers(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(slotList);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: I get 'Not found'
            string expected = "Not found";
            Assert.AreEqual(expected, result);
        }
    }
}
