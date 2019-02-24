using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ManagementApp.Web.Controllers
{
    public class QualificationController : Controller
    {
        private IQualificationService qualificationService;

        public QualificationController(IQualificationService qualificationService) => this.qualificationService = qualificationService;

        [HttpGet]
        public IActionResult Index() => View(QualificationMapper.MapManyToViewModel(qualificationService.GetQualifications()));

        [HttpPost]
        public IActionResult Create(QualificationViewModel qualifictaion)
        {
            try
            {
                qualificationService.AddQualification(QualificationMapper.MapToDomainModel(qualifictaion));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int qualificationId)
        {
            try
            {
                return View(qualificationService.GetQualificationById(qualificationId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(QualificationViewModel qualification)
        {
            try
            {
                qualificationService.UpdateQualification(QualificationMapper.MapToDomainModel(qualification));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int qualificationId)
        {
            try
            {
                qualificationService.DeleteQualification(qualificationId);
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
