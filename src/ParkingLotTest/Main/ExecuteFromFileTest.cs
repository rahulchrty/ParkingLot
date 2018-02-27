using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Interfaces;
using Moq;
using ParkingLot.Implementation;
using System.Collections.Generic;
using ParkingLotTest.BehaviourHijack;

namespace ParkingLotTest.Main
{
    [TestClass]
    public class ExecuteFromFileTest
    {
        private Mock<ICommandExecutorProvier> _mockProvider;
        private Mock<IValidateFileType> _mockValidateFileType;
        private Mock<IInputFileReader> _mockFileReader;
        private IExecuteFromFile _executeFromFile;
        [TestInitialize]
        public void SetUp()
        {
            _mockProvider = new Mock<ICommandExecutorProvier>();
            _mockValidateFileType = new Mock<IValidateFileType>();
            _mockFileReader = new Mock<IInputFileReader>();
            _executeFromFile = new ExecuteFromFile(_mockProvider.Object, _mockValidateFileType.Object, _mockFileReader.Object);
        }
        [TestMethod]
        public void Execute()
        {
            //Given: Path = "d:\parking.txt";
            string path = @"d:\parking.txt";
            //When: I call ExecuteFromFile object
            _mockValidateFileType.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            List<string> commands = new List<string>();
            commands.Add("create_parking_lot 4");
            _mockFileReader.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(commands);
            _mockProvider.Setup(x => x.InitExecutor(It.IsAny<string>())).Returns(new MockCommandExecutor());
            string result = _executeFromFile.Execute(path);
            //Then: method InitExecutor executes once
            _mockProvider.Verify(x => x.InitExecutor(It.IsAny<string>()), Times.Once());
        }
        [TestMethod]
        public void GivenInvalidFileType()
        {
            //Given: Path = "d:\parking.txt";
            string path = @"d:\parking.csv";
            //When: I call ExecuteFromFile object
            _mockValidateFileType.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);
            string result = _executeFromFile.Execute(path);
            //Then: I get 'Invalid file type'
            string expected = "Invalid file type";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InvalidFilePath()
        {
            //Given: Path = "d:\parking.txt";
            string path = @"d:\parking.txt";
            //When: I call ExecuteFromFile object
            _mockValidateFileType.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            List<string> commands = null;
            _mockFileReader.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(commands);
            string result = _executeFromFile.Execute(path);
            //Then: I get 'Invalid file path'
            string expected = "Invalid file path";
            Assert.AreEqual(expected, result);
        }
    }
}
