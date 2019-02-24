using System;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;

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

        internal static string MapManyToViewModel(object p)
        {
            throw new NotImplementedException();
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
