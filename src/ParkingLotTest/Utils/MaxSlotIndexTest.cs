using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest
{
    [TestClass]
    public class MaxSlotIndexTest
    {
        private IMaxSlotIndex _maxSlotIndex;
        [TestInitialize]
        public void SetUp()
        {
            _maxSlotIndex = new MaxSlotIndex();
        }
        [TestMethod]
        public void GivenSlotLengthAs_1_Then_Get_0()
        {
            //Given: maxSlotLength as 1
            int maxSlotLength = 1;
            //When: I call MaxSlotIndex object
            int result = _maxSlotIndex.GetIndex(maxSlotLength);
            //Then: I get 0
            Assert.AreEqual(0, result);
        }
    }
}
