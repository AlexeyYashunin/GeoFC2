#region

using DataAccess.Models;

#endregion

namespace DataAccess
{
    public interface IGeoRepository
    {
        // ReSharper disable once InconsistentNaming
        Location GetLocationsByIP(ulong ip);
        Location GetLocationsByCity(string city);
    }
}