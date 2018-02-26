using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class SlotToEmptyTest
    {
        private ISlotToEmpty _slotToEmpty;
        [TestInitialize]
        public void SetUp()
        {
            _slotToEmpty = new SlotToEmpty();
        }
        [TestMethod]
        public void GivenCommandAs_leave_1_Then_Get_1()
        {
            //Given: command as 'leave 1'
            string command = "leave 1";
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get 0
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GivenCommandAs_leave_0_Then_Get_minus1()
        {
            //Given: command as 'leave 0'
            string command = "leave 0";
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GivenCommandAs_Empty_Then_Get_minus1()
        {
            //Given: command as ''
            string command = string.Empty;
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GivenCommandAs_leave_Then_Get_minus1()
        {
            //Given: command as 'leave'
            string command = "leave";
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GivenCommandAs_leave_a_Then_Get_minus1()
        {
            //Given: command as 'leave a'
            string command = "leave a";
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GivenCommandAs_leaveSpace_Then_Get_minus1()
        {
            //Given: command as 'leave '
            string command = "leave ";
            //When: I call SlotToEmpty object
            int result = _slotToEmpty.GetNumber(command);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
    }
}
