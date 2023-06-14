using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Part
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid RepairId { get; set; }
        public decimal SummaryPrice => Price * Quantity;

        public Part(Guid id, string name, decimal price, int quantity, Guid repairId)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            RepairId = repairId;
        }
    }
}
