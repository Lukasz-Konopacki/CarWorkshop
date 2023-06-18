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
        public List<Car> GetAllCars();
        public Car? GetCarById(Guid Id);
        public Car AddCar(Client client, string plateNumer, string vIN, string brand, string model, int yearOfProduce);
        public void DeleteCar(Car car);
    }

    public class CarService : ICarService
    {
        private readonly DatabaseContext _context;

        public  CarService(DatabaseContext context)
        {
            _context = context;
        }

        public Car AddCar(Client client, string plateNumer, string vIN, string brand, string model ,int yearOfProduce)
        {
            Car newCar = new Car(Guid.NewGuid(), client, plateNumer, vIN, brand, model, yearOfProduce);
            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car? GetCarById(Guid Id)
        {
            return _context.Cars.Where(b => b.Id == Id)
                       .Include(b => b.Repairs)
                       .Include(b => b.Client)
                       .FirstOrDefault();
        }
    }
}
