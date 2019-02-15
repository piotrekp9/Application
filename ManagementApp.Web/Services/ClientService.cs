using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Client GetClientId(int clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
