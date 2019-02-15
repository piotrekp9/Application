using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
        void DeleteOrder(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
    }
}
