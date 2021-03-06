﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot.BusinessInterfaces;
using ParkingLot.RepositoryInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.CommandExecutor
{
    [TestClass]
    public class CreateParkingLotTest
    {
        private Mock<ICheckCommand> _mockCheckCommand;
        private Mock<ISlot> _mockSlot;
        private Mock<ICheckParkingLotCreated> _mockCheckParkingLotCreated;
        private Mock<IParkingLotRepository> _mockParkingRepository;
        private ICommandExecutorSelector _commandExecutorSelector;
        [TestInitialize]
        public void SetUp()
        {
            _mockCheckCommand = new Mock<ICheckCommand>();
            _mockSlot = new Mock<ISlot>();
            _mockCheckParkingLotCreated = new Mock<ICheckParkingLotCreated>();
            _mockParkingRepository = new Mock<IParkingLotRepository>();
            _commandExecutorSelector = new CreateParkingLot(_mockCheckCommand.Object, _mockSlot.Object, _mockCheckParkingLotCreated.Object, _mockParkingRepository.Object);
        }
        [TestMethod]
        public void GivenCommand_create_parking_lot_12_Then_Get_Created_a_parking_lot_with_12_slots()
        {
            //Given: Command as 'create_parking_lot 12'
            string command = "create_parking_lot 12";
            //When: I call CreateParkingLot object
            _mockSlot.Setup(x => x.GetSlotSize(It.IsAny<string>())).Returns(12);
            _mockCheckParkingLotCreated.Setup(x => x.IsCreated()).Returns(false);
            _mockParkingRepository.Setup(x => x.CreateParkingSlots(It.IsAny<int>()));
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then : I get 'Created a parking lot with 12 slots'
            string expected = "Created a parking lot with 12 slots";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenCommand_create_parking_lot_0_Then_Get_Invalid_slot_Size()
        {
            //Given: Command as 'create_parking_lot 0'
            string command = "create_parking_lot 0";
            //When: I call CreateParkingLot object
            _mockSlot.Setup(x => x.GetSlotSize(It.IsAny<string>())).Returns(0);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then : I get 'Invalid slot size'
            string expected = "Invalid slot size";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryToCreateParkingLotWhenAlreadyCreated()
        {
            //Given: Command as 'create_parking_lot 12'
            string command = "create_parking_lot 12";
            //When: I call CreateParkingLot object
            _mockSlot.Setup(x => x.GetSlotSize(It.IsAny<string>())).Returns(12);
            _mockCheckParkingLotCreated.Setup(x => x.IsCreated()).Returns(true);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then : I get 'Parking lot alread created'
            string expected = "Parking lot alread created";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryToCreateParkingLotWhenAlreadyCreated_ThenMethod_CreateParkingSlots_Never_Executes()
        {
            //Given: Command as 'create_parking_lot 12'
            string command = "create_parking_lot 12";
            //When: I call CreateParkingLot object
            _mockSlot.Setup(x => x.GetSlotSize(It.IsAny<string>())).Returns(12);
            _mockCheckParkingLotCreated.Setup(x => x.IsCreated()).Returns(true);
            string result = _commandExecutorSelector.ExecuteCommand(command);
            //Then : Method CreateParkingSlots never executes
            _mockParkingRepository.Verify(x => x.CreateParkingSlots(It.IsAny<int>()), Times.Never());
        }
    }
}