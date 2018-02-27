using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class SlotByRegistrationNumberTest
    {
        private ISlotByRegistrationNumber _slotByRegistrationNumber;
        [TestInitialize]
        public void SetUp()
        {
            _slotByRegistrationNumber = new SlotByRegistrationNumber();
        }
        [TestMethod]
        public void OneCarParkedAt1stSlotAndGivenTheRegistrationNumberThenGetSlotAs1()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "green"
            };
            string registrationNumber = "ka-01-hh-1111";
            //When: I call SlotByRegistrationNumber object
            int result = _slotByRegistrationNumber.GetSlotNumber(vehicleDetails, registrationNumber);
            //Then: I get 1
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void ThreeCarsParkedAndGivenTheRegistrationNumber()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[3];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "green"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1112",
                Color = "green"
            };
            vehicleDetails[2] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1113",
                Color = "green"
            };
            string registrationNumber = "ka-01-hh-1112";
            //When: I call SlotByRegistrationNumber object
            int result = _slotByRegistrationNumber.GetSlotNumber(vehicleDetails, registrationNumber);
            //Then: I get 2
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void SearchedRegistrationNumberNoFound()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[3];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1111",
                Color = "green"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1112",
                Color = "green"
            };
            vehicleDetails[2] = new VehicleDetailsModel
            {
                RegistrationNumber = "ka-01-hh-1113",
                Color = "green"
            };
            string registrationNumber = "ka-01-hh-1114";
            //When: I call SlotByRegistrationNumber object
            int result = _slotByRegistrationNumber.GetSlotNumber(vehicleDetails, registrationNumber);
            //Then: I get -1
            Assert.AreEqual(-1, result);
        }
    }
}
