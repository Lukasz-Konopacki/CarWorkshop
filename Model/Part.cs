using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Part
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Repair Repair { get; set; }
        public decimal SummaryPrice => Price * Quantity;

        /// <summary>
        /// Constructor for EF
        /// </summary>
        private Part() { }

        public Part(Guid id, Repair repair ,string name, decimal price, int quantity)
        {
            Id = id;
            Repair = repair;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
