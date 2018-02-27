using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using Moq;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Commnds
{
    [TestClass]
    public class RegistrationNumbersForCarsWithColourTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<IVehicleColor> _mockVehicleColor;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<IVehicleByColor> _mockVehicleByColor;
        private Mock<IVehicleByColorSuccessMessage> _mockVehicleByColorSuccessMessage;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockVehicleColor = new Mock<IVehicleColor>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockVehicleByColor = new Mock<IVehicleByColor>();
            _mockVehicleByColorSuccessMessage = new Mock<IVehicleByColorSuccessMessage>();
            _commandExecutorSelector = new RegistrationNumbersForCarsWithColour(_mockCheckCommand.Object, _mockVehicleColor.Object,
                                        _mockParkingRepository.Object, _mockVehicleByColor.Object, _mockVehicleByColorSuccessMessage.Object);
        }
        [TestMethod]
        public void ExecuteCommand()
        {
            //Given: command as "registration_numbers_for_cars_with_colour White"
            string command = "registration_numbers_for_cars_with_colour White";
            //When: I call RegistrationNumbersForCarsWithColour object
            _mockVehicleColor.Setup(x => x.GetColor(It.IsAny<string>())).Returns("White");
            VehicleDetailsModel[] cars = new VehicleDetailsModel[1];
            cars[0] = new VehicleDetailsModel { Color = "White", RegistrationNumber = "ka-01-hh-1111" };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(cars);
            string[] registrationNumber = { "ka-01-hh-1111" };
            _mockVehicleByColor.Setup(x => x.GetRegistrationNumbers(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(registrationNumber);
            _mockVehicleByColorSuccessMessage.Setup(x => x.BuildMessage(It.IsAny<string[]>())).Returns("ka-01-hh-1111");
            _commandExecutorSelector.ExecuteCommand(command);
            //Then: Method BuildMessage executes
            _mockVehicleByColorSuccessMessage.Verify(x => x.BuildMessage(It.IsAny<string[]>()));
        }
        [TestMethod]
        public void ParkedCarColorAs_Red_And_Given_Color_As_Green()
        {
            //Given: command as "registration_numbers_for_cars_with_colour White"
            string command = "registration_numbers_for_cars_with_colour green";
            //When: I call RegistrationNumbersForCarsWithColour object
            _mockVehicleColor.Setup(x => x.GetColor(It.IsAny<string>())).Returns("green");
            VehicleDetailsModel[] cars = new VehicleDetailsModel[1];
            cars[0] = new VehicleDetailsModel { Color = "red", RegistrationNumber = "ka-01-hh-1111" };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(cars);
            string[] registrationNumber = {};
            _mockVehicleByColor.Setup(x => x.GetRegistrationNumbers(It.IsAny<VehicleDetailsModel[]>(), It.IsAny<string>())).Returns(registrationNumber);
            _commandExecutorSelector.ExecuteCommand(command);
            //Then: Method BuildMessage never executes
            _mockVehicleByColorSuccessMessage.Verify(x => x.BuildMessage(It.IsAny<string[]>()), Times.Never());
        }
    }
}
