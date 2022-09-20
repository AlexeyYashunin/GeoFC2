namespace DataAccess.Models
{
    // ReSharper disable once InconsistentNaming
    public class IPRange
    {
        public IPRange(uint ipFrom,
                       uint ipTo,
                       uint index)
        {
            IpFrom = ipFrom;
            IpTo = ipTo;
            Index = index;
        }

        public uint IpFrom { get; }
        public uint IpTo { get; }
        public uint Index { get; }
    }
}