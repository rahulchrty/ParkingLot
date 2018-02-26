using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class SlotTest
    {
        private ISlot _slot;
        [TestInitialize]
        public void SetUp()
        {
            _slot = new Slot();
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_1_Then_Get_1()
        {
            //Given: command as "create_parking_lot 1"
            string command = "create_parking_lot 1";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 1
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_30000_Then_Get_30000()
        {
            //Given: command as "create_parking_lot 30000"
            string command = "create_parking_lot 30000";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 30000
            Assert.AreEqual(30000, result);
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_0_Then_Get_0()
        {
            //Given: command as "create_parking_lot 0"
            string command = "create_parking_lot 0";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 0
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_minus1_Then_Get_minus1()
        {
            //Given: command as "create_parking_lot -1"
            string command = "create_parking_lot -1";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get -1
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_A1_Then_Get_0()
        {
            //Given: command as "create_parking_lot A1"
            string command = "create_parking_lot A1";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 0
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GivenCommandAs_EmptyString_Then_Get_0()
        {
            //Given: command as emptyString
            string command = string.Empty;
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 0
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GivenCommandAs_create_parking_lot_Space_Then_Get_0()
        {
            //Given: command as "create_parking_lot  "
            string command = "create_parking_lot  ";
            //When: I call Slot object
            int result = _slot.GetSlotSize(command);
            //Then: get 0
            Assert.AreEqual(0, result);
        }
    }
}