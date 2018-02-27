using ParkingLot.Interfaces;
using System.Collections.Generic;
using System.IO;
using System;

namespace ParkingLot.Implementation
{
    public class InputFileReader : IInputFileReader
    {
        public IEnumerable<string> ReadFile(string path)
        {
            IEnumerable<string> commands = null;
            try
            {
                if (File.Exists(path))
                {
                    commands = File.ReadLines(path);
                }
                return commands;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
