using AdvertisingPlatforms.Domain.Interfaces;

namespace AdvertisingPlatforms.Domain.Services
{
    public class FileValidator : IFileValidator
    {
        const string splitter = ":";
        public bool IsValid(string? data)
        {
            if (data != null &&
                data?.Trim().Length >= 3 &&
                data?.Contains(splitter) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
