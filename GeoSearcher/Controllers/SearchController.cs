using System;
using System.Net;
using BusinessLogic;
using BusinessLogic.Models;
using GeoSearcher.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [Route("/")]
    public class SearchController : Controller
    {
        private readonly IGeoSearcher _geoSearcher;

        public SearchController(IGeoSearcher geoSearcher)
        {
            _geoSearcher = geoSearcher;
        }

        [HttpGet("/ip/location")]
        // ReSharper disable once InconsistentNaming
        public Location IP(string ip)
        {
            if (!TryParseIP(ip, out ulong parsedIp))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            return _geoSearcher.GetLocationByIP(parsedIp)?.ToApiModel();
        }

        [HttpGet("/city/locations")]
        public Location City(string city)
        {
            if (string.IsNullOrEmpty(city))
                return null;

            return _geoSearcher.GetLocationsByCity(city)?.ToApiModel();
        }

        private bool TryParseIP(string ip, out ulong parsedIp)
        {
            parsedIp = 0;
            if (!IPAddress.TryParse(ip, out IPAddress ipAddress))
            {
                return false;
            }

            parsedIp = BitConverter.ToUInt32(ipAddress.GetAddressBytes(), 0);

            return true;
        }
    }
}