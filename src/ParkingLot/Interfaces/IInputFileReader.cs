using System.Collections.Generic;

namespace ParkingLot.Interfaces
{
    public interface IInputFileReader
    {
        IEnumerable<string> ReadFile(string path);
    }
}
