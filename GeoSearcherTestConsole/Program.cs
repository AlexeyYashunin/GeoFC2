using BusinessLogic;
using DataAccess;
using DataAccess.DB;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSearcherTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\venik\source\repos\GeoSearcherTest-master\geobase.dat";
            DataAccess.DB.FileDbManager fileDbManager = new FileDbManager(fileName);
            GeoRepository geoRepository = new GeoRepository(fileDbManager);
            GeoSearcher geoSearcher = new GeoSearcher(geoRepository);
            string ip = "123.234.123.234";
            Location locationByIP = geoSearcher.GetLocationByIP(3933989499);//16287938 - source, 3933989499 - my
            Location locationByCity = geoSearcher.GetLocationsByCity("cit_Gbqw4");//cit_Opyfu - source, cit_Gbqw4 - my
        }
    }
}
