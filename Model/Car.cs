using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Car
    {
        [Key, MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(7)]
        public string PlateNumer { get; set; }
        public string Brand { get; set; }
        public int YearOfProduce { get; set; }
        public Guid ClientId { get; set; }
        public List<Repair> Repairs { get; set; }

        public Car(string plateNumer, string vIN, string brand, int yearOfProduce, Guid clientId)
        {
            PlateNumer = plateNumer;
            VIN = vIN;
            Brand = brand;
            YearOfProduce = yearOfProduce;
            ClientId = clientId;
            Repairs = new List<Repair>();
        }

    }
}
