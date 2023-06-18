using CarWorkshop.DbContexts;
using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xaml;

namespace CarWorkshop.Services
{
    public interface IRepairService
    {
        void AddRepair(Car car, int kilometerage, bool includeOilService, string? problemDescriptionByClient, DateTime startDate, DateTime endDate, int? workingHour);
        public void DeleteRepair(Repair repair);
        public Repair? GetRepairById(Guid id);
        public List<Repair> GetAllRepairs();
        Part AddPart(Repair repair, string newPartName, decimal newPartPrice, int newPartQuantity);
        void DeletePart(Part part);
    }

    public class RepairService : IRepairService
    {
        private readonly DatabaseContext _context;

        public RepairService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddRepair(Car car ,int kilometerage, bool includeOilService, string? problemDescriptionByClient, DateTime startDate, DateTime endDate, int? workingHours)
        {
            _context.Repairs.Add(new Repair(Guid.NewGuid(), car, kilometerage, includeOilService ,problemDescriptionByClient, startDate, endDate, workingHours ?? 0));
            _context.SaveChanges();
        }

        public void DeleteRepair(Repair repair)
        {
            _context.Repairs.Remove(repair);
            _context.SaveChanges();
        }

        public Repair? GetRepairById(Guid id)
        {
            return _context.Repairs.Include(b => b.Parts).SingleOrDefault(b => b.Id == id);
        }

        public List<Repair> GetAllRepairs()
        {
            return _context.Repairs.ToList();
        }

        public Part AddPart(Repair repair ,string newPartName, decimal newPartPrice, int newPartQuantity)
        {
            Part newPart = new Part(Guid.NewGuid(), repair, newPartName, newPartPrice, newPartQuantity);
            _context.Parts.Add(newPart);
            _context.SaveChanges();
            return newPart;
        }

        public void DeletePart(Part part)
        {
            _context.Parts.Remove(part);
            _context.SaveChanges();
        }
    }
}
