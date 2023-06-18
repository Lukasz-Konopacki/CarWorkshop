using CarWorkshop.DbContexts;
using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CarWorkshop.Services
{
    public interface IClientService
    {
        public List<Client> GetAllClients();
        public Client? GetClientById(Guid id);
        public Client AddClient(string firstName, string lastName, string pesel, string contactNumber, 
                              string nipNumber, string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber);
        public void DeleteClient(Client client);
    }

    public class ClientService : IClientService
    {
        private readonly DatabaseContext _dbContexts;

        public ClientService(DatabaseContext dbContexts)
        {
            _dbContexts = dbContexts;
        }

        public Client AddClient(string firstName, string lastName, string pesel, string contactNumber, string nipNumber, string city, string street, string postalCode, string country, string buildingNumber, string? flatNumber)
        {
            Client newClient = new Client(Guid.NewGuid(), firstName, lastName, pesel, contactNumber, nipNumber, new Address(Guid.NewGuid(), city, street, postalCode, country, buildingNumber, flatNumber));
            _dbContexts.Clients.Add(newClient);
            _dbContexts.SaveChanges();

            return newClient;
        }

        public void DeleteClient(Client client)
        {
           _dbContexts.Clients.Remove(client);
            _dbContexts.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return _dbContexts.Clients.Include(client => client.Address).ToList();
        }

        public Client? GetClientById(Guid id)
        {
            return _dbContexts.Clients.Include(client => client.Address).Include(client => client.Cars).SingleOrDefault(x => x.Id == id);
        }
    }
}
