using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string BuildingNumber { get; set; }
        public string? FlatNumber { get; set; }

        public Address(string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber = null)
        {
            City = city;
            Street = street;
            PostalCode = postalCode;
            Country = country;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }
    }
}
