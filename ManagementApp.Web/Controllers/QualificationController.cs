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
        private readonly IQualificationService qualificationService;

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
        public IActionResult Details(int id)
        {
            if (id < 1) return BadRequest();

            try
            {
                var qualification = qualificationService.GetQualificationById(id);
                var mappedQualification = QualificationMapper.MapToViewModel(qualification, qualification.EmployeesQualifications);
                return View(mappedQualification);

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();

            try
            {
                qualificationService.DeleteQualification(id);
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
