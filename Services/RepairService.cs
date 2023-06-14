using CarWorkshop.DbContexts;
using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Services
{
    public interface IRepairService
    {
        public IEnumerable<Repair> GetAllRepairs();
        public Repair? GetRepairById(Guid id);
        public bool DeleteRepair(Guid id);
        void AddRepair(string carVin, string? problemDescriptionByClient, decimal? price, int summaryWorkingHours, DateTime startDate, DateTime endDate, string carVIN);
        void AddPart(Guid guid, string? newPartName, decimal newPartPrice, int newPartQuantity, Guid repairId);
    }

    public class RepairService : IRepairService
    {
        private readonly DatabaseContext _context;

        public RepairService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddRepair(string carVin, string? problemDescriptionByClient, decimal? price, int summaryWorkingHours, DateTime startDate, DateTime endDate, string carVIN)
        {
            _context.Repairs.Add(new Repair(Guid.NewGuid(), problemDescriptionByClient, price, summaryWorkingHours, startDate, endDate, carVIN));
            _context.SaveChanges();
        }

        public bool DeleteRepair(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Repair> GetAllRepairs()
        {
            return _context.Repairs;
        }

        public Repair? GetRepairById(Guid id)
        {
          return  _context.Repairs.Where(r => r.Id == id).Include(b => b.parts).SingleOrDefault();
        }

        public void AddPart(Guid guid, string? newPartName, decimal newPartPrice, int newPartQuantity, Guid repaidId)
        {
            _context.Parts.Add(new Part(guid, newPartName, newPartPrice, newPartQuantity, repaidId));
            _context.SaveChanges();
        }
    }
}
