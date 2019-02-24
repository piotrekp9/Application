using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ManagementApp.Web.Controllers
{
    public class ProtocolController : Controller
    {
        private IProtocolService protocolService;

        public ProtocolController(IProtocolService protocolService) => this.protocolService = protocolService;

        [HttpGet]
        public IActionResult Index() => View(ProtocolMapper.MapManyToViewModel(protocolService.GetProtocols()));

        [HttpPost]
        public IActionResult Create(ProtocolViewModel protocol)
        {
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
