using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DataAccess.Models;

namespace DataAccess.DB
{
    public class FileDbManager
    {
        private readonly string _filePath;
        private GeoDb _db;

        public FileDbManager(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(nameof(filePath));
            }

            _filePath = filePath;
        }

        public GeoDb Load()
        {
            if (_db == null)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                byte[] bytes = File.ReadAllBytes(_filePath);
                stopwatch.Stop();
                Debug.WriteLine($"Db loaded in {stopwatch.ElapsedMilliseconds} ms.");

                using (var dbReader = new FileDbReader(bytes))
                {
                    Header header = dbReader.ReadHeader();
                    IReadOnlyCollection<IPRange> ranges = dbReader.ReadIpRanges(header.Records);
                    IReadOnlyCollection<Location> locations = dbReader.ReadIpLocations(header.Records);
                    uint[] indexes = dbReader.ReadSortedLocationIndexes(header.OffsetLocations, header.Records);

                    _db = new GeoDb(header,
                                    ranges,
                                    locations,
                                    indexes);
                }
            }

            return _db;
        }
    }
}