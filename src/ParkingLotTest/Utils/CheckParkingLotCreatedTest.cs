using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.RepositoryInterfaces;
using Moq;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class CheckParkingLotCreatedTest
    {
        private Mock<IParkingLotRepository> _mockParkingLotRepository;
        private ICheckParkingLotCreated checkParkingLotCreated;
        [TestInitialize]
        public void SetUp()
        {
            _mockParkingLotRepository = new Mock<IParkingLotRepository>();
            checkParkingLotCreated = new CheckParkingLotCreated(_mockParkingLotRepository.Object);
        }
        [TestMethod]
        public void SlotNotCreatedThenGetFalse()
        {
            //Given:

            //When: I call CheckParkingLotCreated object
            _mockParkingLotRepository.Setup(x => x.GetParkingDetails()).Returns((VehicleDetailsModel[])null);
            bool result = checkParkingLotCreated.IsCreated();
            //Then: I get false;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void SlotCreatedThenGetTrue()
        {
            //Given:

            //When: I call CheckParkingLotCreated object
            VehicleDetailsModel[] storage = new VehicleDetailsModel[2];
            _mockParkingLotRepository.Setup(x => x.GetParkingDetails()).Returns(storage);
            bool result = checkParkingLotCreated.IsCreated();
            //Then: I get true
            Assert.IsTrue(result);
        }
    }
}
