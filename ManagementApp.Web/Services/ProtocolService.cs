using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class ProtocolService : IProtocolService
    {
        private readonly ApplicationDbContext context;

        public ProtocolService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddProtocol(Protocol protocol)
        {
            if (protocol == null) throw new ArgumentException("Cannot add empty protocol object!");

            context.Protocols.Add(protocol);
            context.SaveChanges();
        }

        public void DeleteProtocol(int protocolId)
        {
            var protocolToDelete = context.Protocols.Find(protocolId);

            if (protocolToDelete == null) throw new ArgumentException($"There is no Protocol of ID:{protocolId}");

            context.Protocols.Remove(protocolToDelete);

            context.SaveChanges();
        }

        public Protocol GetProtocolById(int protocolId)
        {
            return context.Protocols
                .Include(protocol => protocol.Employee)
                .Include(protocol => protocol.Order)
                .FirstOrDefault(protocol => protocol.Id == protocolId);
        }

        public IEnumerable<Protocol> GetProtocols()
        {
            return context.Protocols
                .Include(protocol => protocol.Employee)
                .Include(protocol => protocol.Order)
                .ToList();
        }

        public void UpdateProtocol(Protocol protocol)
        {
            var protocolToUpdate = context.Protocols.Find(protocol.Id);

            if (protocolToUpdate == null) throw new ArgumentException($"Cannot update protocol of ID:{protocol.Id}");

            protocolToUpdate.Name = protocol.Name;
            protocolToUpdate.Title = protocol.Title;
            protocolToUpdate.Description = protocol.Description;

            context.SaveChanges();
        }
    }
}
