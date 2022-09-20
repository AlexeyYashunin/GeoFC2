using BusinessLogic.Models;

namespace BusinessLogic
{
    public interface IGeoSearcher
    {
        // ReSharper disable once InconsistentNaming
        Location GetLocationByIP(ulong ip);
        Location GetLocationsByCity(string city);
    }
}