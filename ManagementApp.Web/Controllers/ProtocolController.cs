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
    public class ProtocolController : Controller
    {
        private IProtocolService protocolService;

        public ProtocolController(IProtocolService protocolService) => this.protocolService = protocolService;

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var protocols = ProtocolMapper.MapManyToViewModel(protocolService.GetProtocols());
            if (string.IsNullOrEmpty(filter)) return View(protocols);

            return View(protocols.Where(protocol =>
                protocol.Name.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create() => View();

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
        public IActionResult Details(int protocolId)
        {
            if (protocolId < 1) return BadRequest();

            try
            {
                return View(protocolService.GetProtocolById(protocolId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
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

        [HttpDelete]
        public IActionResult Delete(int protocolId)
        {
            if (protocolId < 1) return BadRequest();

            try
            {
                protocolService.DeleteProtocol(protocolId);
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
