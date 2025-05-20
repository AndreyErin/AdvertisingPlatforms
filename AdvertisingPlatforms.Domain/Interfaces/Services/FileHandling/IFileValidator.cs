namespace AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling
{

    /// <summary>
    /// Interface foe validating file.
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Validation check.
        /// </summary>
        /// <param name="data">Data for validation.</param>
        /// <returns>(True + null) or (false + error).</returns>
        (bool result, string? error) IsValidAdvertisingData(string? data);
    }
}
