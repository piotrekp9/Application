﻿using System.Collections.Generic;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;

namespace ManagementApp.Web.Mappers
{
    public class OrderMapper
    {
        public static OrderViewModel MapToViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                Description = order.Description,
                AcutalFinishDate = order.AcutalFinishDate,
                OrderPriority = order.OrderPriority,
                OrderStatus = order.OrderStatus,
                PlannedFinishDate = order.PlannedFinishDate,
                StartDate = order.StartDate,
                Title = order.Title
            };
        }

        internal static IEnumerable<OrderViewModel> MapManyToViewModel(IEnumerable<Order> orders)
        {
            var list = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                list.Add(MapToViewModel(order));
            }

            return list;
        }

        public static Order MapToDomainModel(OrderViewModel viewModel)
        {
            return new Order()
            {
                Title = viewModel.Title,
                StartDate = viewModel.StartDate,
                AcutalFinishDate = viewModel.AcutalFinishDate,
                Description = viewModel.Description,
                OrderStatus = viewModel.OrderStatus,
                OrderPriority = viewModel.OrderPriority,
                PlannedFinishDate = viewModel.PlannedFinishDate,
            };
        }
    }
}
