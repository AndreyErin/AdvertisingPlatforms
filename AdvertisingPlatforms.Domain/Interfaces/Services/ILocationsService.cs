﻿using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    public interface ILocationsService: IReplaceData<Location>
    {
        /// <summary>
        /// Get id location by name.
        /// </summary>
        /// <param name="location">Name of location.</param>
        /// <returns>Return location or null.</returns>
        public Location? GetByName(string name);
    }
}
