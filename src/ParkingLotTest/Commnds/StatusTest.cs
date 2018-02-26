using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;
using System.Text;

namespace ParkingLotTest.Commnds
{
    [TestClass]
    public class StatusTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private Mock<IStatusOutput> _mockStatusOutput;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _mockStatusOutput = new Mock<IStatusOutput>();
            _commandExecutorSelector = new Status(_mockCheckCommand.Object, _mockParkingRepository.Object, _mockStatusOutput.Object);
        }
        [TestMethod]
        public void ExecuteCommand()
        {
            //Given: command as 'status'
            string command = "status";
            //When: I call Status object
            VehicleDetailsModel[] parlingDetails = new VehicleDetailsModel[1];
            parlingDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1111",
                Color = "Black"
            };
            _mockParkingRepository.Setup(x => x.GetParkingDetails()).Returns(parlingDetails);
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Slot No.   Registration No   Colour");
            expected.AppendLine("1   KA-01-HH-1111   Black");
            _mockStatusOutput.Setup(x => x.Build(It.IsAny<VehicleDetailsModel[]>())).Returns(expected.ToString());
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then: method GetParkingDetails and Build executes
            _mockParkingRepository.Verify(x => x.GetParkingDetails());
            _mockStatusOutput.Verify(x => x.Build(It.IsAny<VehicleDetailsModel[]>()));
        }
    }
}
