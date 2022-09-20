namespace DataAccess.Models
{
    public class Header
    {
        public Header(
            int version,
            string name,
            ulong date,
            int records,
            uint offsetRanges,
            uint offsetCities,
            uint offsetLocations)
        {
            Version = version;
            Name = name;
            Date = date;
            Records = records;
            OffsetRanges = offsetRanges;
            OffsetCities = offsetCities;
            OffsetLocations = offsetLocations;
        }

        public ulong Date { get; }
        public string Name { get; }
        public uint OffsetCities { get; }
        public uint OffsetLocations { get; }
        public uint OffsetRanges { get; }
        public int Records { get; }
        public int Version { get; }
    }
}