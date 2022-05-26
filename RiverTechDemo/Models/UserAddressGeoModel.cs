using System;
using System.Collections.Generic;
using System.Text;

namespace RiverTechDemo.Models
{
   public class UserAddressGeoModel
    {
        public UserAddressGeoModel(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
