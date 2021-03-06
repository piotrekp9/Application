﻿using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext context;

        public ClientService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddClient(Client client)
        {
            if (client == null) throw new ArgumentException("Cannot add empty Client!");

            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var clientToDelete = context.Clients.Find(clientId);

            if (clientToDelete == null) throw new ArgumentException($"There is no Client of ID:{clientToDelete.Id}, to be deleted");

            context.Remove(clientToDelete);
            context.SaveChanges();
        }

        public Client GetClientById(int clientId)
        {
            return context.Clients
                .Include(client => client.Orders)
                .Include(client => client.Invoices)
                .FirstOrDefault(client => client.Id == clientId);
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients
                .Include(client => client.Orders)
                .Include(client => client.Invoices)
                .ToList();
        }

        public void UpdateClient(Client client)
        {
            var clientToUpdate = context.Clients.Find(client.Id);

            if (clientToUpdate == null) throw new ArgumentException($"Cannot update Client of ID:{client.Id}");

            clientToUpdate.Name = client.Name;
            clientToUpdate.NIP = client.NIP;
            clientToUpdate.PESEL = client.PESEL;
            clientToUpdate.REGON = client.REGON;
            clientToUpdate.City = client.City;
            clientToUpdate.Email = client.Email;
            clientToUpdate.Street = client.Street;
            clientToUpdate.PostalCode = client.PostalCode;
            clientToUpdate.PhoneNumber = client.PhoneNumber;

            context.SaveChanges();
        }
    }
}
