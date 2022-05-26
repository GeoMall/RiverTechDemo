using RiverTechDemo.Models;
using System;
using System.Collections.Generic;

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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Username, Email, Website, Phone, Address, Company);
        }
    }

}
