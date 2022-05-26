using System;
using System.Collections.Generic;
using System.Text;

namespace RiverTechDemo.Models
{
    public class UserAddressModel
    {
        public UserAddressModel(string street, string suite, string city, string zipCode, UserAddressGeoModel geo)
        {
            Street = street;
            Suite = suite;
            City = city;
            ZipCode = zipCode;
            Geo = geo;
        }

        public String Street { get; set; }
        public String Suite { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public UserAddressGeoModel Geo { get; set; }
    }
}
