
namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// File not correct.
    /// </summary>
    public class InvalidFileExeption: Exception
    {
        public InvalidFileExeption() { }
        public InvalidFileExeption(string message) : base(message) { }                  
        public InvalidFileExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
