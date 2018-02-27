using ParkingLot.Business;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Implementation;
using ParkingLot.Interfaces;
using ParkingLot.Repository;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot
{
    class Program
    {
        private ICommandExecutorProvier _provider;
        public Program()
        {
            ICommand _command = new Command();
            ICheckCommand _checkCommand = new CheckCommand(_command);
            ISlot _slot = new Slot();
            IParkingLotRepository _parkingRepository = new ParkingLotRepository();
            ICheckParkingLotCreated checkParkingLotCreated = new CheckParkingLotCreated(_parkingRepository);
            ICommandExecutorSelector createParkingLot = new CreateParkingLot(_checkCommand, _slot, checkParkingLotCreated, _parkingRepository);
            IValidateVeicleDetails _validateVeicleDetails = new ValidateVeicleDetails();
            IParkingVehicle _parkingVehicle = new ParkingVehicle();
            IParkSuccessMessage _parkSuccessMessage = new ParkSuccessMessage();
            ICommandExecutorSelector park = new Park(_checkCommand, _validateVeicleDetails, _parkingVehicle, _parkingRepository, _parkSuccessMessage);
            ISlotToEmpty _slotToEmpty = new SlotToEmpty();
            IMaxSlotIndex _maxSlotIndex = new MaxSlotIndex();
            IValidateSlotNumberToEmpty _validateSlotNumberToEmpty = new ValidateSlotNumberToEmpty(_parkingRepository, _maxSlotIndex);
            ILeaveSuccessMessage _leaveSuccessMessage = new LeaveSuccessMessage();
            ICommandExecutorSelector leave = new Leave(_checkCommand, _slotToEmpty, _validateSlotNumberToEmpty, _parkingRepository, _leaveSuccessMessage);
            IStatusOutput _statusOutput = new StatusOutput();
            ICommandExecutorSelector status = new Status(_parkingRepository, _statusOutput);
            IVehicleColor _vehicleColor = new VehicleColor();
            IVehicleByColor _vehicleByColor = new VehicleByColor();
            IVehicleByColorSuccessMessage _vehicleByColorSuccessMessage = new VehicleByColorSuccessMessage();
            ICommandExecutorSelector regNoByColor = new RegistrationNumbersForCarsWithColour(_checkCommand, _vehicleColor, _parkingRepository, _vehicleByColor, _vehicleByColorSuccessMessage);
            ISlotByColor _slotByColor = new SlotByColor();
            ISlotByColorMessage _slotByColorMessage = new SlotByColorMessage();
            ICommandExecutorSelector slotNoByColor = new SlotNumbersForCarsWithColour(_checkCommand, _vehicleColor, _parkingRepository, _slotByColor, _slotByColorMessage);
            IVehicleRegistrationNumber _vehicleRegistrationNumber = new VehicleRegistrationNumber();
            ISlotByRegistrationNumber _slotByRegistrationNumber = new SlotByRegistrationNumber();
            ICommandExecutorSelector slotByRegistration = new SlotNumberForRegistrationNumber(_checkCommand, _vehicleRegistrationNumber, _parkingRepository, _slotByRegistrationNumber);
            ICommandExecutorSelector[] _selectors = { createParkingLot, park, leave, status, regNoByColor, slotNoByColor, slotByRegistration };
            _provider = new CommandExecutorProvider(_selectors);
        }
        static void Main(string[] args)
        {
            try
            {
                Program parkingLot = new Program();
                if (args.Length == 1)
                {
                    string filePath = args[0];
                    IInputFileReader fileReader = new InputFileReader();
                    IValidateFileType validateFileType = new ValidateFileType();
                    IExecuteFromFile fileExecutor = new ExecuteFromFile(parkingLot._provider, validateFileType, fileReader);
                    string messages = fileExecutor.Execute(filePath);
                    Console.WriteLine(messages);
                }
                else if (args.Length > 1)
                {
                    Console.WriteLine("Takes only one argument");
                }
                else
                {
                    string result = string.Empty;
                    bool isLive = true;
                    while (isLive)
                    {
                        string userInputCommand = Console.ReadLine();
                        if (userInputCommand.Equals("exit"))
                        {
                            isLive = false;
                        }
                        else
                        {
                            ICommandExecutor executor = parkingLot._provider.InitExecutor(userInputCommand);
                            if (executor != null)
                            {
                                result = executor.ExecuteCommand(userInputCommand);
                            }
                            else
                            {
                                result = "Invalid Command";
                            }
                            Console.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}