using System;
using System.Net.Sockets;

namespace ManagementApp.Web.Data.Models
{
    public class Protocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proclamation { get; set; }
        public bool IsSuccessfull { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Weather { get; set; }
        public ProtocolType ProtocolType { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}