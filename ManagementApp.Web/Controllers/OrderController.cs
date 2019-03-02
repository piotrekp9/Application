using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService) => this.orderService = orderService;

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var orders = OrderMapper.MapManyToViewModel(orderService.GetOrders());
            if (string.IsNullOrEmpty(filter)) return View(orders);

            return View(orders.Where(order =>
            order.Title.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                orderService.AddOrder(OrderMapper.MapToDomainModel(order));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int orderId)
        {
            if (orderId < 1) return BadRequest();
            try
            {
                return View(orderService.GetOrderById(orderId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(OrderViewModel order)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                orderService.UpdateOrder(OrderMapper.MapToDomainModel(order));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Delete(int orderId)
        {
            if (orderId < 1) return BadRequest();
            try
            {
                orderService.DeleteOrder(orderId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}