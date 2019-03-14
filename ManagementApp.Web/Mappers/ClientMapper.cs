using System.Collections.Generic;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;

namespace ManagementApp.Web.Mappers
{
    public class ClientMapper
    {
        public static ClientViewModel MapToViewModel(Client client) => new ClientViewModel()
        {
            Id = client.Id,
            City = client.City,
            Email = client.Email,
            Name = client.Name,
            NIP = client.NIP,
            PESEL = client.PESEL,
            PhoneNumber = client.PhoneNumber,
            PostalCode = client.PostalCode,
            REGON = client.REGON,
            Street = client.Street
        };

        public static ClientViewModel MapToViewModel(Client client, IEnumerable<Order> orders, IEnumerable<Invoice> invoices)
        {
            var mappedOrders = OrderMapper.MapManyToViewModel(orders);
            var mappedInvoices = InvoiceMapper.MapManyToViewModel(invoices);

            return new ClientViewModel()
            {
                Id = client.Id,
                City = client.City,
                Email = client.Email,
                Name = client.Name,
                NIP = client.NIP,
                PESEL = client.PESEL,
                PhoneNumber = client.PhoneNumber,
                PostalCode = client.PostalCode,
                REGON = client.REGON,
                Street = client.Street,
                Invoices = mappedInvoices,
                Orders = mappedOrders
            };
        }

        public static IEnumerable<ClientViewModel> MapManyToViewModel(IEnumerable<Client> clients)
        {
            var list = new List<ClientViewModel>();

            foreach (var client in clients)
            {
                list.Add(MapToViewModel(client));
            }

            return list;
        }

        public static Client MapToDomainModel(ClientViewModel viewModel) => new Client()
        {
            Street = viewModel.Street,
            REGON = viewModel.REGON,
            PostalCode = viewModel.PostalCode,
            City = viewModel.City,
            Email = viewModel.Email,
            Name = viewModel.Name,
            NIP = viewModel.NIP,
            PESEL = viewModel.PESEL,
            PhoneNumber = viewModel.PhoneNumber
        };
    }
}
