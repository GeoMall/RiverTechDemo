using System;
using System.Collections.Generic;
using System.Text;

namespace RiverTechDemo
{
    public class UserModel
    {
        public UserModel(int id, string name, string username, string email, string website, string phone, UserAddressModel address, UserCompanyModel company)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Website = website;
            Phone = phone;
            Address = address;
            Company = company;
        }

        public int Id { get; set;}
        public string Name { get; set;}
        public string Username { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public UserAddressModel Address { get; set; }
        public UserCompanyModel Company { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Username == model.Username &&
                   Email == model.Email &&
                   Website == model.Website &&
                   Phone == model.Phone &&
                   EqualityComparer<UserAddressModel>.Default.Equals(Address, model.Address) &&
                   EqualityComparer<UserCompanyModel>.Default.Equals(Company, model.Company);
        }
    }

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

    public class UserCompanyModel
    {
        public UserCompanyModel(string name, string catchPhrase, string bs)
        {
            Name = name;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }

        public String Name { get; set; }
        public String CatchPhrase { get; set; }
        public String Bs { get; set; }
    }
}
