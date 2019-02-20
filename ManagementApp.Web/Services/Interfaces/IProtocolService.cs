using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IProtocolService
    {
        IEnumerable<Protocol> GetProtocols();
        Protocol GetProtocolById(int protocolId);
        void DeleteProtocol(int protocolId);
        void AddProtocol(Protocol protocol);
        void UpdateProtocol(Protocol protocol);
    }
}
