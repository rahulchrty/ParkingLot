using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class VehicleByColorTest
    {
        private IVehicleByColor _vehicleByColor;
        [TestInitialize]
        public void SetUp()
        {
            _vehicleByColor = new VehicleByColor();
        }
        [TestMethod]
        public void One_Car_With_Color_Green_And_Given_Color_as_Green()
        {
            //Given: 1 car with registration number 'ka-01-hh-1111' and color 'green'
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            string color = "green";
            //When: I call VehicleByColor object
            string[] result = _vehicleByColor.GetRegistrationNumbers(vehicleDetails, color);
            //Then: I get a string array of length 1
            Assert.AreEqual(1, result.Length);
        }
        [TestMethod]
        public void One_Car_With_Color_Green_And_Given_Color_as_Green_Then_Get_RegistrationNumber()
        {
            //Given: 1 car with registration number 'ka-01-hh-1111' and color 'green'
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            string color = "green";
            //When: I call VehicleByColor object
            string[] result = _vehicleByColor.GetRegistrationNumbers(vehicleDetails, color);
            //Then: I get 'ka-01-hh-1111'
            string expected = "ka-01-hh-1111";
            Assert.AreEqual(expected, result[0]);
        }
        [TestMethod]
        public void Three_Cars_2With_Color_Green_And_1With_White_Given_Color_as_Green()
        {
            //Given: 1st car with registration number 'ka-01-hh-1111' and color 'green'
            //And: 2nd car with registration number 'ka-01-hh-1112' and color 'green'
            //And: 3rd car with registration number 'ka-01-hh-1113' and color 'black'
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[3];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1112"
            };
            vehicleDetails[2] = new VehicleDetailsModel
            {
                Color = "black",
                RegistrationNumber = "ka-01-hh-1113"
            };
            string color = "green";
            //When: I call VehicleByColor object
            string[] result = _vehicleByColor.GetRegistrationNumbers(vehicleDetails, color);
            //Then: I get a string array of length 2
            Assert.AreEqual(2, result.Length);
        }
        [TestMethod]
        public void Three_Cars_With_Green_And_Given_Color_as_Red()
        {
            //Given: 1st car with registration number 'ka-01-hh-1111' and color 'green'
            //And: 2nd car with registration number 'ka-01-hh-1112' and color 'green'
            //And: 3rd car with registration number 'ka-01-hh-1113' and color 'green'
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[3];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1112"
            };
            vehicleDetails[2] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1113"
            };
            string color = "red";
            //When: I call VehicleByColor object
            string[] result = _vehicleByColor.GetRegistrationNumbers(vehicleDetails, color);
            //Then: I get a string array of length 0
            Assert.AreEqual(0, result.Length);
        }
    }
}
