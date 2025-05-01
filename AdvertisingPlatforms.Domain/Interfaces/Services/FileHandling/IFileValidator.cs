namespace AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling
{

    /// <summary>
    /// Interface foe validating file.
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Checking data for validity.
        /// </summary>
        /// <param name="data">Data for vadidaty.</param>
        /// <returns>true or false</returns>
        bool IsValidAdvertisingData(string? data);
    }
}
