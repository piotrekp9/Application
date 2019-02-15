using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClientId(int clientId);
        void DeleteClient(int clientId);
        void AddClient(Client client);
        void UpdateClient(Client client);
    }
}
