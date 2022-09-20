using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DB;
using DataAccess.Models;

namespace DataAccess
{
    public class GeoRepository : IGeoRepository
    {
        private readonly GeoDb _db;

        public GeoRepository(FileDbManager dbManager)
        {
            _db = dbManager.Load();
        }

        public Location GetLocationsByIP(ulong ip)
        {
            if (!_db.Ranges.Any())
                return null;
            var first = 0;
            int last = _db.Ranges.Count-1;
            while (first <= last)
            {
                int mid = first + (last - first) / 2;
                IPRange midRange = _db.Ranges.ElementAt(mid);
                if (IsRangeContainsIP(midRange))
                    return _db.Locations.ElementAt((int)midRange.Index);
                MovePositions(midRange, mid);
            }
            return null;
            bool IsRangeContainsIP(IPRange midRange) => ip >= midRange.IpFrom && ip <= midRange.IpTo;
            void MovePositions(IPRange midRange, int mid)
            {
                if (ip < midRange.IpFrom)
                    last = mid - 1;
                else
                    first = mid + 1;
            }
        }

        public Location GetLocationsByCity(string city)
        {
            if (!_db.Locations.Any() || string.IsNullOrEmpty(city))
            {
                return null;
            }

            var first = 0;
            int last = _db.SortedLocationIndexes.Count;

            while (first <= last)
            {
                int mid = first + (last - first) / 2;
                var midIdx = _db.SortedLocationIndexes.ElementAt(mid);
                //this cast is ok in current requirements
                var midLoc = _db.Locations.ElementAt((int)midIdx);

                if (string.Equals(city, midLoc.City, StringComparison.Ordinal))
                {
                    return midLoc;
                }

                var comparisonResult = string.Compare(city, midLoc.City, StringComparison.Ordinal);
                if (comparisonResult < 0)
                {
                    last = mid - 1;
                }
                else
                {
                    first = mid + 1;
                }
            }

            return null;
        }

        public ulong ConvertIPToULong(string ip) => BitConverter.ToUInt32(System.Net.IPAddress.Parse(ip).GetAddressBytes(), 0);
        public string ConvertIPV4ToString(ulong ip)
        {
            List<byte> result = new List<byte>();
            result.AddRange(BitConverter.GetBytes(ip));
            result = result.GetRange(0, 4);
            string res = string.Join(".", result.Select(x => x.ToString()));
            return res;
        }
    }
}