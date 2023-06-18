using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class Repair
    {
        private static decimal WorkingHourPrice => 125m;

        [Key]
        public Guid Id { get; set; }
        public Car Car { get; set; }
        [MaxLength]
        public string? ProblemDescriptionByClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Kilometerage { get; set; }
        public bool IncludeOilService { get; set; }
        [Column(TypeName = "money")]
        public int WorkingHours { get; set; }
        public List<Part> Parts {get; set;}
        public decimal? Price => Parts?.Sum(p => p.SummaryPrice) + (WorkingHours) ?? 0 * WorkingHourPrice;
        public string? ProblemShortDescripton => ProblemDescriptionByClient.Length > 30 ? ProblemDescriptionByClient?.Substring(0, 20) + "..." : ProblemDescriptionByClient;

        /// <summary>
        /// Constructor for EF
        /// </summary>
        private Repair(){ }

        public Repair(Guid id, Car car, int kilometerage, bool includeOilService,  string? problemDescriptionByClient, DateTime startDate, DateTime endDate, int workingHours)
        {
            Id = id;
            ProblemDescriptionByClient = problemDescriptionByClient;
            StartDate = startDate;
            EndDate = endDate;
            WorkingHours = workingHours;
            Car = car;
            Parts = new List<Part>();
            Kilometerage = kilometerage;
            IncludeOilService = includeOilService;
        }
    }
}
