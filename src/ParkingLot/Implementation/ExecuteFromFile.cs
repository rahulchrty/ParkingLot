using ParkingLot.BusinessInterfaces;
using ParkingLot.Interfaces;
using System.Collections.Generic;
using System.Text;
using System;

namespace ParkingLot.Implementation
{
    public class ExecuteFromFile : IExecuteFromFile
    {
        private ICommandExecutorProvier _provider;
        private IValidateFileType _validateFileType;
        private IInputFileReader _fileReader;
        public ExecuteFromFile(ICommandExecutorProvier provider,
                                IValidateFileType validateFileType,
                                IInputFileReader fileReader)
        {
            _provider = provider;
            _validateFileType = validateFileType;
            _fileReader = fileReader;
        }
        public string Execute(string path)
        {
            StringBuilder messages = new StringBuilder();
            try
            {
                bool isValid = _validateFileType.IsValid(path);
                if (isValid)
                {
                    IEnumerable<string> commands = _fileReader.ReadFile(path);
                    if (commands != null)
                    {
                        foreach (string command in commands)
                        {
                            ICommandExecutor executpr = _provider.InitExecutor(command);
                            string message = executpr.ExecuteCommand(command);
                            messages.AppendLine(message);
                        }
                    }
                    else
                    {
                        messages.Append("Invalid file path");
                    }
                }
                else
                {
                    messages.Append("Invalid file type");
                }
                return messages.ToString();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
