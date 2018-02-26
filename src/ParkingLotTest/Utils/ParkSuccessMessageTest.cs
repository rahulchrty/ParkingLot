using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class ParkSuccessMessageTest
    {
        private IParkSuccessMessage _parkSuccessMessage;
        [TestInitialize]
        public void SetUp()
        {
            _parkSuccessMessage = new ParkSuccessMessage();
        }
        [TestMethod]
        public void Given_SlotIndexAs0_Then_Get_AllocatedSlotNumberAs1()
        {
            //Given : slot index as 0
            int slotIndex = 0;
            //When: I call ParkSuccessMessage object
            string result = _parkSuccessMessage.CreateMessage(slotIndex);
            //Then: I get 
            string expected = "Allocated slot number: 1";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_SlotIndexAs10_Then_Get_AllocatedSlotNumberAs1()
        {
            //Given : slot index as 10
            int slotIndex = 10;
            //When: I call ParkSuccessMessage object
            string result = _parkSuccessMessage.CreateMessage(slotIndex);
            //Then: I get 
            string expected = "Allocated slot number: 11";
            Assert.AreEqual(expected, result);
        }
    }
}
