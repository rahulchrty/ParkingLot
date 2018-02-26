using ParkingLot.Business;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Repository;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand _command = new Command();
            ICheckCommand _checkCommand = new CheckCommand(_command);
            ISlot _slot = new Slot();
            IParkingLotRepository _parkingRepository = new ParkingLotRepository();
            ICommandExecutorSelector createParkingLot = new CreateParkingLot(_checkCommand, _slot, _parkingRepository);
            IValidateVeicleDetails _validateVeicleDetails = new ValidateVeicleDetails();
            IParkingVehicle _parkingVehicle = new ParkingVehicle();
            IParkSuccessMessage _parkSuccessMessage = new ParkSuccessMessage();
            ICommandExecutorSelector park = new Park(_checkCommand, _validateVeicleDetails, _parkingVehicle, _parkingRepository, _parkSuccessMessage);
            ICommandExecutorSelector[] _selectors = { createParkingLot, park };
            ICommandExecutorProvier provider = new CommandExecutorProvider(_selectors);
            for (;;)
            {
                string userInputCommand = Console.ReadLine();
                ICommandExecutor executor = provider.InitExecutor(userInputCommand);
                string result = executor.ExecuteCommand(userInputCommand);
                Console.WriteLine(result);
            }
        }
    }
}