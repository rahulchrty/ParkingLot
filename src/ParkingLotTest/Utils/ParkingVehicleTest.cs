using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class ParkingVehicleTest
    {
        private IParkingVehicle _parkingVehicle;
        [TestInitialize]
        public void SetUp()
        {
            _parkingVehicle = new ParkingVehicle();
        }
        [TestMethod]
        public void GivenAParkCommandWithResigtrationNumberAndColor()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get a type of VehicleDetailsModel
            Assert.IsInstanceOfType(result, typeof(VehicleDetailsModel));
        }

        [TestMethod]
        public void GivenAParkCommandWithResigtrationNumberAndColor_Then_Get_The_RegistrationNumber()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get registration number as 'KA-01-HH-1234'
            string expected = "KA-01-HH-1234";
            Assert.AreEqual(expected, result.RegistrationNumber);
        }

        [TestMethod]
        public void GivenAParkCommandWithResigtrationNumberAndColor_Then_Get_The_Coor()
        {
            //Given: command as 'park KA-01-HH-1234 White'
            string command = "park KA-01-HH-1234 White";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get Color as 'White'
            string expected = "White";
            Assert.AreEqual(expected, result.Color);
        }

        [TestMethod]
        public void GivenNoRegistrationNumber()
        {
            //Given: command as 'park White'
            string command = "park White";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get null
            Assert.IsNull(result);
        }
        [TestMethod]
        public void GivenNoColor()
        {
            //Given: command as 'park KA-01-HH-1234'
            string command = "park KA-01-HH-1234";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get null
            Assert.IsNull(result);
        }
        [TestMethod]
        public void GivenVehicleDetailsGiven()
        {
            //Given: command as 'park'
            string command = "park";
            //When: I call ParkingVehicle object
            VehicleDetailsModel result = _parkingVehicle.GetDetail(command);
            //Then: I get null
            Assert.IsNull(result);
        }
    }
}
