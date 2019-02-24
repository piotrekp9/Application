using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ManagementApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService) => this.orderService = orderService;

        [HttpGet]
        public IActionResult Index() => View(OrderMapper.MapManyToViewModel(orderService.GetOrders()));

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            try
            {
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
            try
            {
                return View(orderService.GetOrderById(orderId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(OrderViewModel order)
        {
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

        [HttpDelete]
        public IActionResult Delete(int orderId)
        {
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