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
    public class QualificationController : Controller
    {
        private IQualificationService qualificationService;

        public QualificationController(IQualificationService qualificationService) => this.qualificationService = qualificationService;

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var qualifications = QualificationMapper.MapManyToViewModel(qualificationService.GetQualifications());
            if (string.IsNullOrEmpty(filter)) return View(qualifications);

            return View(qualifications.Where(qualification => 
                qualification.Name.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(QualificationViewModel qualifictaion)
        {
            if (!ModelState.IsValid) return BadRequest();

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
            if (qualificationId < 1) return BadRequest();

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
            if (!ModelState.IsValid) return BadRequest();

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
            if (qualificationId < 1) return BadRequest();

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
