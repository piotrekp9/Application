using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel.Protocol;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class ProtocolController : Controller
    {
        private readonly IProtocolService protocolService;
        private readonly IEmployeeService employeeService;
        private readonly IOrderService orderService;

        public ProtocolController(IProtocolService protocolService, IEmployeeService employeeService, IOrderService orderService)
        {
            this.protocolService = protocolService;
            this.employeeService = employeeService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var protocols = ProtocolMapper.MapManyToViewModel(protocolService.GetProtocols());
            if (string.IsNullOrEmpty(filter)) return View(protocols);

            return View(protocols.Where(protocol =>
                protocol.Name.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var mappedEmployees = EmployeeMapper.MapManyToViewModel(employeeService.GetEmployees());
            var mappedOrders = OrderMapper.MapManyToViewModel(orderService.GetOrders());

            return View(new ProtocolCreateViewModel(mappedEmployees, mappedOrders));
        }

        [HttpPost]
        public IActionResult Create(ProtocolViewModel protocol)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                protocolService.AddProtocol(ProtocolMapper.MapToDomainModel(protocol));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id < 1) return BadRequest();

            try
            {
                var protocol = protocolService.GetProtocolById(id);
                var mappedProtocol = ProtocolMapper.MapToViewModel(protocol, EmployeeMapper.MapToViewModel(protocol.Employee), OrderMapper.MapToViewModel(protocol.Order));
                var details = new ProtocolDetailsViewModel(EmployeeMapper.MapManyToViewModel(employeeService.GetEmployees()), OrderMapper.MapManyToViewModel(orderService.GetOrders()), mappedProtocol);

                return View(details);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(ProtocolViewModel protocol)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                protocolService.UpdateProtocol(ProtocolMapper.MapToDomainModel(protocol));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();

            try
            {
                protocolService.DeleteProtocol(id);
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
