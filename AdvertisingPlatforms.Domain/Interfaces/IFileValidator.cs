namespace AdvertisingPlatforms.Domain.Interfaces
{
    /// <summary>
    /// Inteface for file validate.
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Inteface for validation data from file.
        /// </summary>
        /// <param name="data">Data for validation.</param>
        /// <returns>True for valid data, false for invalid data.</returns>
        bool IsValid(string? data);
    }
}
