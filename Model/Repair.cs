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
        [Key]
        public Guid Id { get; set; }
        [MaxLength]
        public string? ProblemDescriptionByClient { get; set; }
        [Precision(14, 2)]
        public decimal? Price { get; set; }
        public int SummaryWorkingHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Repair(Guid id, string? problemDescriptionByClient, decimal? price, int summaryWorkingHours, DateTime startDate, DateTime endDate)
        {
            Id = id;
            ProblemDescriptionByClient = problemDescriptionByClient;
            Price = price;
            SummaryWorkingHours = summaryWorkingHours;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
