namespace AdvertisingPlatforms.Business.Exeptions
{
    /// <summary>
    /// File not correct.
    /// </summary>
    public class ConfigureReadExeption: Exception
    {
        public ConfigureReadExeption() { }
        public ConfigureReadExeption(string message) : base(message) { }                  
        public ConfigureReadExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
