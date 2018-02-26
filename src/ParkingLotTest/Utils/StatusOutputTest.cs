using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;
using System.Text;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class StatusOutputTest
    {
        private IStatusOutput _statusOutput;

        [TestInitialize]
        public void SetUp()
        {
            _statusOutput = new StatusOutput();
        }
        [TestMethod]
        public void Geven_ParkingDetailsFor1Car()
        {
            //Given:
            VehicleDetailsModel[] parlingDetails = new VehicleDetailsModel[1];
            parlingDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1111",
                Color = "Black"
            };
            //When: I call StatusOutput object
            string result = _statusOutput.Build(parlingDetails);
            //Then:
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Slot No.   Registration No   Colour");
            expected.AppendLine("1   KA-01-HH-1111   Black");
            Assert.AreEqual(expected.ToString(), result);
        }
        [TestMethod]
        public void Geven_ParkingDetailsFor2Cars()
        {
            //Given:
            VehicleDetailsModel[] parlingDetails = new VehicleDetailsModel[2];
            parlingDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1111",
                Color = "Black"
            };
            parlingDetails[1] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1112",
                Color = "Green"
            };
            //When: I call StatusOutput object
            string result = _statusOutput.Build(parlingDetails);
            //Then:
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Slot No.   Registration No   Colour");
            expected.AppendLine("1   KA-01-HH-1111   Black");
            expected.AppendLine("2   KA-01-HH-1112   Green");
            Assert.AreEqual(expected.ToString(), result);
        }
        [TestMethod]
        public void Geven_MissingCarInSlot2()
        {
            //Given:
            VehicleDetailsModel[] parlingDetails = new VehicleDetailsModel[3];
            parlingDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1111",
                Color = "Black"
            };
            parlingDetails[2] = new VehicleDetailsModel
            {
                RegistrationNumber = "KA-01-HH-1112",
                Color = "Green"
            };
            //When: I call StatusOutput object
            string result = _statusOutput.Build(parlingDetails);
            //Then:
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Slot No.   Registration No   Colour");
            expected.AppendLine("1   KA-01-HH-1111   Black");
            expected.AppendLine("3   KA-01-HH-1112   Green");
            Assert.AreEqual(expected.ToString(), result);
        }
        [TestMethod]
        public void Geven_NoCarInParkingLot()
        {
            //Given:
            VehicleDetailsModel[] parlingDetails = new VehicleDetailsModel[3];
            //When: I call StatusOutput object
            string result = _statusOutput.Build(parlingDetails);
            //Then:
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Slot No.   Registration No   Colour");
            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
