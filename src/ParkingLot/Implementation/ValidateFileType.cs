using ParkingLot.Interfaces;
using System.IO;

namespace ParkingLot.Implementation
{
    public class ValidateFileType : IValidateFileType
    {
        public bool IsValid(string path)
        {
            bool isRightExtension = false;
            if (!string.IsNullOrEmpty(path))
            {
                string extension = Path.GetExtension(path);
                if (extension.ToLower().Trim().Equals(".txt"))
                {
                    isRightExtension = true;
                }
            }
            return isRightExtension;
        }
    }
}
