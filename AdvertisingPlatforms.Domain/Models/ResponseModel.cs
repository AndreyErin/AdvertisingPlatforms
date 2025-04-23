using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Models
{
    public class ResponseModel
    {
        public bool Success { get; }
        public string Message { get; }
        public AdvertisingUpdateResult? AdvertisingUpdateResult { get; }

        public ResponseModel(bool success, string message, AdvertisingUpdateResult? advertisingUpdateResult = null)
        {
            Success = success;
            Message = message;
            AdvertisingUpdateResult = advertisingUpdateResult;
        }
    }
}
