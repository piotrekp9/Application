using ManagementApp.Web.Data.Enums;
using System;

namespace ManagementApp.Web.ViewModel
{
    public class ProtocolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proclamation { get; set; }
        public bool IsSuccessfull { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Weather { get; set; }
        public ProtocolType ProtocolType { get; set; }
    }
}
