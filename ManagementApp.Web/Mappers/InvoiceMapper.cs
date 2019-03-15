using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel.Invoice;
using System.Collections.Generic;

namespace ManagementApp.Web.Mappers
{
    public class InvoiceMapper
    {
        public static InvoiceViewModel MapToViewModel(Invoice invoice)
        {
            return new InvoiceViewModel()
            {
                Id = invoice.Id,
                AccountNumber = invoice.AccountNumber,
                DateOfIssue = invoice.DateOfIssue,
                Description = invoice.Description,
                InvoiceNumber = invoice.InvoiceNumber,
                PaymentType = invoice.PaymentType,
                PaymentWithoutTax = invoice.PaymentWithoutTax,
                PaymentWithTax = invoice.PaymentWithTax,
                TaxPayment = invoice.TaxPayment,
                TaxRate = invoice.TaxRate
            };
        }

        public static InvoiceViewModel MapToViewModel(Invoice invoice, Order order, Client client)
        {
            return new InvoiceViewModel()
            {
                Id = invoice.Id,
                AccountNumber = invoice.AccountNumber,
                DateOfIssue = invoice.DateOfIssue,
                Description = invoice.Description,
                InvoiceNumber = invoice.InvoiceNumber,
                PaymentType = invoice.PaymentType,
                PaymentWithoutTax = invoice.PaymentWithoutTax,
                PaymentWithTax = invoice.PaymentWithTax,
                TaxPayment = invoice.TaxPayment,
                TaxRate = invoice.TaxRate,
                Order = OrderMapper.MapToViewModel(order),
                Client = ClientMapper.MapToViewModel(client)
            };
        }

        internal static IEnumerable<InvoiceViewModel> MapManyToViewModel(IEnumerable<Invoice> invoices)
        {
            var list = new List<InvoiceViewModel>();

            foreach (var invoice in invoices)
            {
                list.Add(MapToViewModel(invoice));
            }

            return list;
        }

        public static Invoice MapToDomainModel(InvoiceViewModel viewModel)
        {
            return new Invoice()
            {
                TaxRate = viewModel.TaxRate,
                AccountNumber = viewModel.AccountNumber,
                DateOfIssue = viewModel.DateOfIssue,
                Description = viewModel.Description,
                InvoiceNumber = viewModel.InvoiceNumber,
                PaymentType = viewModel.PaymentType,
                PaymentWithoutTax = viewModel.PaymentWithoutTax,
                PaymentWithTax = viewModel.PaymentWithTax,
                TaxPayment = viewModel.TaxPayment
            };
        }
    }
}
