using CarWorkshop.DbContexts;
using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Services
{
    public interface ICarService
    {
        public IEnumerable<Car> GetAllCars();
        public Car? GetCarByVin(string vin);
        public bool AddCar(string plateNumer, string vIN, string brand, int? yearOfProduce, Guid clientId);
        public bool DeleteCar(string vin);
    }

    public class CarService : ICarService
    {
        private readonly DatabaseContext _context;

        public  CarService(DatabaseContext context)
        {
            _context = context;
        }

        public bool AddCar(string plateNumer, string vIN, string brand, int? yearOfProduce, Guid clientId)
        {
            _context.Cars.Add(new Car(plateNumer, vIN, brand, yearOfProduce ?? 0, clientId));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCar(string vin)
        {
            _context.Cars.Remove(_context.Cars.Find(vin));
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.Take(20);
        }

        public Car? GetCarByVin(string vin)
        {
            return _context.Cars.Where(b => b.VIN == vin)
                       .Include(b => b.Repairs)
                       .FirstOrDefault();
        }
    }
}
