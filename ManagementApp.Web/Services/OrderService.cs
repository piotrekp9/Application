using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentException("Cannot add empty order object!");

            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var orderToDelete = context.Orders.Find(orderId);

            if (orderToDelete == null) throw new ArgumentException($"There is no Order of ID:{orderId}, that could be delated");

            context.Remove(orderToDelete);

            context.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return context.Orders
                .Include(orders => orders.Client)
                .Include(orders => orders.Invoice)
                .Include(orders => orders.Protocol)
                .Include(order => order.Employee)
                .FirstOrDefault(order => order.Id == orderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders
                .Include(order => order.Client)
                .Include(order => order.Invoice)
                .Include(order => order.Protocol)
                .Include(order => order.Employee)
                .ToList();
        }

        public void UpdateOrder(Order order)
        {
            var orderToUpdate = context.Orders.Find(order.Id);

            if (orderToUpdate == null) throw new ArgumentNullException($"Cannot update order of ID:{order.Id}");

            orderToUpdate.Title = order.Title;
            orderToUpdate.Description = order.Description;
            orderToUpdate.AcutalFinishDate = order.AcutalFinishDate;
            orderToUpdate.OrderPriority = order.OrderPriority;
            orderToUpdate.OrderStatus = order.OrderStatus;
            orderToUpdate.PlannedFinishDate = order.PlannedFinishDate;
            orderToUpdate.StartDate = order.StartDate;

            context.SaveChanges();
        }
    }
}
