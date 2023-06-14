using CarWorkshop.DbContexts;
using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWorkshop.Services
{
    public interface IClientService
    {
        public IEnumerable<Client> GetAllClients();
        public Client? GetClientById(Guid id);
        public bool AddClient(string firstName, string lastName, string pesel, string contactNumber, 
                              string nipNumber, string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber);
        public bool DeleteClient(Guid id);
    }

    public class ClientService : IClientService
    {
        private readonly DatabaseContext _dbContexts;

        public ClientService(DatabaseContext dbContexts)
        {
            _dbContexts = dbContexts;
        }

        public bool AddClient(string firstName, string lastName, string pesel, string contactNumber, string nipNumber, 
                              string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber)
        {
            _dbContexts.Clients.Add(new Client(Guid.NewGuid(),firstName, lastName, pesel, contactNumber, nipNumber, new Address(Guid.NewGuid(),city, street, postalCode, country, buildingNumber, flatNumber)));
            _dbContexts.SaveChanges();

            return true;
        }

        public bool DeleteClient(Guid id)
        {
           _dbContexts.Clients.Remove(_dbContexts.Clients.Find(id));
            _dbContexts.SaveChanges();
            return true;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _dbContexts.Clients.Take(20).Include(client => client.Address);
        }

        public Client? GetClientById(Guid id)
        {
            return _dbContexts.Clients.SingleOrDefault(x => x.Id == id);
        }
    }
}
