using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Interfaces;
using ParkingLot.Implementation;

namespace ParkingLotTest.Main
{
    [TestClass]
    public class ValidateFileTypeTest
    {
        private IValidateFileType _validateFileType;
        [TestInitialize]
        public void SetUp()
        {
            _validateFileType = new ValidateFileType();
        }
        [TestMethod]
        public void GivenFileExtensionAstxt()
        {
            //Given: path as 'd:\parking.txt'
            string path = @"d:\parking.txt";
            //When: I call ValidateFileType object
            bool result = _validateFileType.IsValid(path);
            //Then: I get true
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenFileExtensionAscsv()
        {
            //Given: path as 'd:\parking.txt'
            string path = @"d:\parking.csv";
            //When: I call ValidateFileType object
            bool result = _validateFileType.IsValid(path);
            //Then: I get false
            Assert.IsFalse(result);
        }
    }
}
