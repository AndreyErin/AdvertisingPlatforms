
namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// The data has been read, but it is not correct.
    /// </summary>
    public class InvalidFileDataExeption: Exception
    {
        public InvalidFileDataExeption() { }
        public InvalidFileDataExeption(string message) : base(message) { }                  
        public InvalidFileDataExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
