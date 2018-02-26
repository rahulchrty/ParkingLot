using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Validations
{
    [TestClass]
    public class ValidateVeicleDetailsTest
    {
        private IValidateVeicleDetails _validateVeicleDetails;
        [TestInitialize]
        public void SetUp()
        {
            _validateVeicleDetails = new ValidateVeicleDetails();
        }
        [TestMethod]
        public void GivenRegistrationNumberAndColor_Then_GetEmptyString()
        {
            //Given: RegistrationNumber as 'KA-01-HH-1234'
            //And: Color as 'Red'
            VehicleDetailsModel vehivleDetail = new VehicleDetailsModel
            {
                Color = "Red",
                RegistrationNumber = "KA-01-HH-1234"
            };
            //When: I call ValidateVeicleDetails object
            string result = _validateVeicleDetails.Validate(vehivleDetail);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void When_VihicleDetailsNotProvided_Then_Get_ErrorMessage()
        {
            //Given: 
            VehicleDetailsModel vehivleDetail = null;
            //When: I call ValidateVeicleDetails object
            string result = _validateVeicleDetails.Validate(vehivleDetail);
            //Then: I get 'Please provide all require details'
            string expected = "Please provide all require details";
            Assert.AreEqual(expected, result);
        }
    }
}