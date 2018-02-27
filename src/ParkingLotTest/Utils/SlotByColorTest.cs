using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;
using ParkingLot.Model;
using System.Collections.Generic;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class SlotByColorTest
    {
        private ISlotByColor _slotByColor;
        [TestInitialize]
        public void SetUp()
        {
            _slotByColor = new SlotByColor();
        }
        [TestMethod]
        public void ACarWithColorRedParkedAtSlot1_And_Given_Color_As_Red()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1111"
            };
            string color = "red";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get a list of length 1
            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void ACarWithColorRedParkedAtSlot1_And_Given_Color_As_Red_Then_Get_Slot_As_1()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[1];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1111"
            };
            string color = "red";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get slot as 1
            Assert.AreEqual(1, result[0]);
        }
        [TestMethod]
        public void TwoCarWithColorRedParkedAtSlot1and2_And_Given_Color_As_Red()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[2];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1111"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1112"
            };
            string color = "red";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get a list of length 2
            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void TwoCarWithColorGreenAndRedParkedAtSlot1and2_And_Given_Color_As_Red_Then_Get_SlotAs2()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[2];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1112"
            };
            string color = "red";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get slot as 2
            Assert.AreEqual(2, result[0]);
        }
        [TestMethod]
        public void TwoCarWithColorGreenAndRedParkedAtSlot1and2_And_Given_Color_As_Black_Then_Get_0()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[2];
            vehicleDetails[0] = new VehicleDetailsModel
            {
                Color = "green",
                RegistrationNumber = "ka-01-hh-1111"
            };
            vehicleDetails[1] = new VehicleDetailsModel
            {
                Color = "red",
                RegistrationNumber = "ka-01-hh-1112"
            };
            string color = "black";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get no slot number
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void ParkedNoCars_And_Given_Color_As_Black()
        {
            //Given:
            VehicleDetailsModel[] vehicleDetails = new VehicleDetailsModel[0];
            string color = "black";
            //When: I call SlotByColor object
            List<int> result = _slotByColor.GetSlotNumbers(vehicleDetails, color);
            //Then: I get no slot number
            Assert.AreEqual(0, result.Count);
        }
    }
}
