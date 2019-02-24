using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ManagementApp.Web.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;

        public ClientController(IClientService clientService) => this.clientService = clientService;

        [HttpGet]
        public IActionResult Index() => View(ClientMapper.MapManyToViewModel(clientService.GetClients()));

        [HttpPost]
        public IActionResult Create(ClientViewModel client)
        {
            try
            {
                clientService.AddClient(ClientMapper.MapToDomainModel(client));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int clientId)
        {
            try
            {
                return View(clientService.GetClientById(clientId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(ClientViewModel client)
        {
            try
            {
                clientService.UpdateClient(ClientMapper.MapToDomainModel(client));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int clientId)
        {
            try
            {
                clientService.DeleteClient(clientId);
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
