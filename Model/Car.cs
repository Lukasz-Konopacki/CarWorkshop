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
        [Key]
        public Guid Id { get; set; }
        [MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(7)]
        public string PlateNumer { get; set; }
        [MaxLength(51)]
        public string Brand { get; set; }
        [MaxLength(51)]
        public string Model { get; set; }
        public int YearOfProduce { get; set; }
        public Client Client { get; set; }
        public List<Repair> Repairs { get; set; }

        /// <summary>
        /// Constructor for EF
        /// </summary>
        private Car(){}

        public Car(Guid id, Client client, string plateNumer, string vIN, string brand, string model,int yearOfProduce)
        {
            Id = id;
            VIN = vIN;
            PlateNumer = plateNumer;
            Brand = brand;
            Model = model;
            YearOfProduce = yearOfProduce;
            Client = client;
            Repairs = new List<Repair>();
        }

    }
}
