﻿using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;

        public ClientController(IClientService clientService) => this.clientService = clientService;

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var clients = ClientMapper.MapManyToViewModel(clientService.GetClients());
            if (string.IsNullOrEmpty(filter)) return View(clients);

            return View(clients.Where(client => client.Name.Contains(filter)).ToList());
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(ClientViewModel client)
        {
            if (!ModelState.IsValid) return View(client);
            try
            {
                clientService.AddClient(ClientMapper.MapToDomainModel(client));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Error();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                var client = clientService.GetClientById(id);
                var mappedClient = ClientMapper.MapToViewModel(client, client.Orders, client.Invoices);
                return View(mappedClient);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(ClientViewModel client)
        {
            if (!ModelState.IsValid) return View(client);
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                clientService.DeleteClient(id);
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
