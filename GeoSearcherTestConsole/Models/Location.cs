namespace DataAccess.Models
{
    public class Location
    {
        public Location(
            string country,
            string region,
            string postal,
            string city,
            string organization,
            float latitude,
            float longitude)
        {
            Country = country;
            Region = region;
            Postal = postal;
            City = city;
            Organization = organization;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Country { get; }
        public string Region { get; }
        public string Postal { get; }
        public string City { get; }
        public string Organization { get; }
        public float Latitude { get; }
        public float Longitude { get; }
    }
}