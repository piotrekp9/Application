namespace ManagementApp.Web.ViewModel
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? REGON { get; set; }
        public int NIP { get; set; }
        public int? PESEL { get; set; }
    }
}
