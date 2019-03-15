using System.Collections.Generic;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Order;
using ManagementApp.Web.ViewModel.Protocol;

namespace ManagementApp.Web.Mappers
{
    public class ProtocolMapper
    {
        public static ProtocolViewModel MapToViewModel(Protocol protocol)
        {
            return new ProtocolViewModel()
            {
                Id = protocol.Id,
                Description = protocol.Description,
                Name = protocol.Name,
                DateOfIssue = protocol.DateOfIssue,
                IsSuccessfull = protocol.IsSuccessfull,
                Proclamation = protocol.Proclamation,
                ProtocolType = protocol.ProtocolType,
                Weather = protocol.Weather,
            };
        }

        public static ProtocolViewModel MapToViewModel(Protocol protocol, EmployeeViewModel employee, OrderViewModel order)
        {
            return new ProtocolViewModel()
            {
                Id = protocol.Id,
                Description = protocol.Description,
                Name = protocol.Name,
                DateOfIssue = protocol.DateOfIssue,
                IsSuccessfull = protocol.IsSuccessfull,
                Proclamation = protocol.Proclamation,
                ProtocolType = protocol.ProtocolType,
                Weather = protocol.Weather,
                Employee = employee,
                Order = order
            };
        }

        public static IEnumerable<ProtocolViewModel> MapManyToViewModel(IEnumerable<Protocol> protocols)
        {
            var list = new List<ProtocolViewModel>();

            foreach (var protocol in protocols)
            {
                list.Add(MapToViewModel(protocol));
            }

            return list;
        }

        public static Protocol MapToDomainModel(ProtocolViewModel viewModel)
        {
            return new Protocol()
            {
                Weather = viewModel.Weather,
                Description = viewModel.Description,
                DateOfIssue = viewModel.DateOfIssue,
                IsSuccessfull = viewModel.IsSuccessfull,
                Name = viewModel.Name,
                Proclamation = viewModel.Proclamation,
                ProtocolType = viewModel.ProtocolType,
            };
        }
    }
}
