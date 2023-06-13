using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [MaxLength(20)]
        public string Street { get; set; }

        [MaxLength(30)]
        public string PostalCode { get; set; }

        [MaxLength(53)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string BuildingNumber { get; set; }

        [MaxLength(10)]
        public string? FlatNumber { get; set; }

        public Address(Guid id, string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber = null)
        {
            Id = id;
            City = city;
            Street = street;
            PostalCode = postalCode;
            Country = country;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }
    }
}
