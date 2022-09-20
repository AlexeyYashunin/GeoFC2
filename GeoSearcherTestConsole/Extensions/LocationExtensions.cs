#region


#endregion

using DataAccess.Models;

namespace BusinessLogic.Extensions
{
    internal static class LocationExtensions
    {
        public static Location ToBusiness(this DataAccess.Models.Location location)
        {
            if (location == null)
            {
                return null;
            }

            return new Location(location.Country,
                                location.Region,
                                location.Postal,
                                location.City,
                                location.Organization,
                                location.Latitude,
                                location.Longitude);
        }
    }
}