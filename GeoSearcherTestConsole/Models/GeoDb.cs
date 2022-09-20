#region

using System.Collections.Generic;

#endregion

namespace DataAccess.Models
{
    public class GeoDb
    {
        public GeoDb(Header header,
                     IReadOnlyCollection<IPRange> ranges,
                     IReadOnlyCollection<Location> locations,
                     IReadOnlyCollection<uint> sortedLocationIndexes)
        {
            Header = header;
            Ranges = ranges;
            Locations = locations;
            SortedLocationIndexes = sortedLocationIndexes;
        }

        public Header Header { get; }
        public IReadOnlyCollection<IPRange> Ranges { get; }
        public IReadOnlyCollection<Location> Locations { get; }
        public IReadOnlyCollection<uint> SortedLocationIndexes { get; }
    }
}