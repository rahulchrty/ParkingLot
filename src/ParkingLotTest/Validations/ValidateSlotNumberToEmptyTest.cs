using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using Moq;
using ParkingLot.RepositoryInterfaces;

namespace ParkingLotTest.Validations
{
    [TestClass]
    public class ValidateSlotNumberToEmptyTest
    {
        private Mock<IParkingLotRepository> _mockParkingLotRepository;
        private Mock<IMaxSlotIndex> _MockMaxSlotIndex;
        private IValidateSlotNumberToEmpty _validateSlotNumberToEmpty;
        [TestInitialize]
        public void SetUp()
        {
            _mockParkingLotRepository = new Mock<IParkingLotRepository>();
            _MockMaxSlotIndex = new Mock<IMaxSlotIndex>();
            _validateSlotNumberToEmpty = new ValidateSlotNumberToEmpty(_mockParkingLotRepository.Object, _MockMaxSlotIndex.Object);
        }
        [TestMethod]
        public void Given_SlotIndex_0_Then_Get_EmptyString()
        {
            //Given: slotIndex as 0
            int slotIndex = 0;
            //When: I call ValidateSlotNumberToEmpty object
            _mockParkingLotRepository.Setup(x => x.TotalSlotAllocated()).Returns(1);
            _MockMaxSlotIndex.Setup(x => x.GetIndex(It.IsAny<int>())).Returns(0);
            string result = _validateSlotNumberToEmpty.ValidateSlotNumber(slotIndex);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void Given_SlotIndex_4_Then_Get_EmptyString()
        {
            //Given: slotIndex as 4
            int slotIndex = 4;
            //When: I call ValidateSlotNumberToEmpty object
            _mockParkingLotRepository.Setup(x => x.TotalSlotAllocated()).Returns(10);
            _MockMaxSlotIndex.Setup(x => x.GetIndex(It.IsAny<int>())).Returns(9);
            string result = _validateSlotNumberToEmpty.ValidateSlotNumber(slotIndex);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void Given_SlotIndex_minus1_Then_Get_Invalid_slot_number()
        {
            //Given: slotIndex as -1
            int slotIndex = -1;
            //When: I call ValidateSlotNumberToEmpty object
            _mockParkingLotRepository.Setup(x => x.TotalSlotAllocated()).Returns(10);
            _MockMaxSlotIndex.Setup(x => x.GetIndex(It.IsAny<int>())).Returns(9);
            string result = _validateSlotNumberToEmpty.ValidateSlotNumber(slotIndex);
            //Then: I get 'Invalid slot number'
            string expected = "Invalid slot number";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_SlotIndex_As_OutOfMaxSlot_Then_Get_ErrorMessage()
        {
            //Given: slotIndex as 10
            int slotIndex = 10;
            //When: I call ValidateSlotNumberToEmpty object
            _mockParkingLotRepository.Setup(x => x.TotalSlotAllocated()).Returns(10);
            _MockMaxSlotIndex.Setup(x => x.GetIndex(It.IsAny<int>())).Returns(9);
            string result = _validateSlotNumberToEmpty.ValidateSlotNumber(slotIndex);
            //Then: I get 'Invalid slot number'
            string expected = "Invalid slot number. Maximum possible paking is 10";
            Assert.AreEqual(expected, result);
        }
    }
}
