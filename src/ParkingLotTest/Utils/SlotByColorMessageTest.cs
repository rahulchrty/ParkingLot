using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using System.Collections.Generic;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class SlotByColorMessageTest
    {
        private ISlotByColorMessage _slotByColorMessage;
        [TestInitialize]
        public void SetUp()
        {
            _slotByColorMessage = new SlotByColorMessage();
        }
        [TestMethod]
        public void Given_SlotNumnerAs1ThenGet1()
        {
            //Given:
            List<int> slotList = new List<int>();
            slotList.Add(1);
            //When: I call SlotByColorMessage object
            string result = _slotByColorMessage.BuildMessage(slotList);
            //Then:  I get 1
            Assert.AreEqual("1", result);
        }
        [TestMethod]
        public void Given_SlotNumnerAs1And3ThenGet1Comma3()
        {
            //Given:
            List<int> slotList = new List<int>();
            slotList.Add(1);
            slotList.Add(3);
            //When: I call SlotByColorMessage object
            string result = _slotByColorMessage.BuildMessage(slotList);
            //Then:  I get '1, 3'
            Assert.AreEqual("1, 3", result);
        }
        [TestMethod]
        public void Given_NoSlotNumbers()
        {
            //Given:
            List<int> slotList = new List<int>();

            //When: I call SlotByColorMessage object
            string result = _slotByColorMessage.BuildMessage(slotList);
            //Then:  I get empty string
            Assert.AreEqual(string.Empty, result);
        }
    }
}
