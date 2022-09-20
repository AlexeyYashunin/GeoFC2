#region

using BusinessLogic.Extensions;
using DataAccess;
using DataAccess.Models;

#endregion

namespace BusinessLogic
{
    public class GeoSearcher : IGeoSearcher
    {
        private readonly IGeoRepository _repository;

        public GeoSearcher(IGeoRepository repository)
        {
            _repository = repository;
        }

        public Location GetLocationByIP(ulong ip)
        {
            DataAccess.Models.Location location = _repository.GetLocationsByIP(ip);
            return location?.ToBusiness();
        }

        public Location GetLocationsByCity(string city)
        {
            var location = _repository.GetLocationsByCity(city);
            return location?.ToBusiness();
        }

        
    }
}