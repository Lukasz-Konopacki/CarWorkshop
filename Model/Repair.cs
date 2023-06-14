using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Repair
    {
        private Guid _guid;
        private string? _problemDescriptionByClient;
        private decimal? _price;
        private int _summaryWorkingHours;
        private DateTime _startDate;
        private DateTime _endDate;

        [Key]
        public Guid Id { get; set; }
        [MaxLength]
        public string? ProblemDescriptionByClient { get; set; }
        [Precision(14, 2)]
        public decimal? Price { get; set; }
        public int SummaryWorkingHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarVin { get; set; }
        public List<Part> parts {get; set;}

        public Repair(Guid id, string? problemDescriptionByClient, decimal? price, int summaryWorkingHours, DateTime startDate, DateTime endDate, string carVin)
        {
            Id = id;
            ProblemDescriptionByClient = problemDescriptionByClient;
            Price = price;
            SummaryWorkingHours = summaryWorkingHours;
            StartDate = startDate;
            EndDate = endDate;
            CarVin = carVin;
            parts = new List<Part>();
        }
    }
}
