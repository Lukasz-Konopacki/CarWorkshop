using CarWorkshop.DbContexts;
using CarWorkshop.Model;
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
        public Car GetCarById(Guid id);
        public bool AddCar(string plateNumer, string vIN, string brand, int yearOfProduce);
        public bool DeleteCar(Guid id);
    }

    public class CarService : ICarService
    {
        private readonly DatabaseContext _context;

        public  CarService(DatabaseContext context)
        {
            _context = context;
        }

        public bool AddCar(string plateNumer, string vIN, string brand, int yearOfProduce)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCar(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
