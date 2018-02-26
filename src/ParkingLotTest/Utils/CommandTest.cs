using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class CommandTest
    {
        private ICommand _command;
        [TestInitialize]
        public void SetUp()
        {
            _command = new Command();
        }
        [TestMethod]
        public void GivenCommand_create_parking_lot_5_Then_Get_create_parking_Lot()
        {
            //Given: command as 'create_parking_lot 5'
            string command = "create_parking_lot 5";
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get 'create_parking_lot'
            Assert.AreEqual("create_parking_lot", result);
        }
        [TestMethod]
        public void GivenCommand_create_parking_lot_space_Then_Get_create_parking_Lot()
        {
            //Given: command as 'create_parking_lot  '
            string command = "create_parking_lot  ";
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get 'create_parking_lot'
            Assert.AreEqual("create_parking_lot", result);
        }
        [TestMethod]
        public void GivenCommand_space_create_parking_lot_1_Then_Get_create_parking_Lot()
        {
            //Given: command as ' create_parking_lot 1'
            string command = " create_parking_lot 1";
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get 'create_parking_lot'
            Assert.AreEqual("create_parking_lot", result);
        }
        [TestMethod]
        public void GivenCommand_space_create_parking_lot_space_Then_Get_create_parking_Lot()
        {
            //Given: command as ' create_parking_lot  '
            string command = " create_parking_lot  ";
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get 'create_parking_lot'
            Assert.AreEqual("create_parking_lot", result);
        }
        [TestMethod]
        public void GivenCommand_create_parking_lot_Then_Get_create_parking_Lot()
        {
            //Given: command as 'create_parking_lot'
            string command = "create_parking_lot";
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get 'create_parking_lot'
            Assert.AreEqual("create_parking_lot", result);
        }
        [TestMethod]
        public void GivenCommand_As_EmptyString_Then_I_Get_EmptyString()
        {
            //Given: command as ''
            string command = string.Empty;
            //When: I call Command object
            string result = _command.GetCommand(command);
            //Then: I get ''
            Assert.AreEqual(string.Empty, result);
        }
    }
}