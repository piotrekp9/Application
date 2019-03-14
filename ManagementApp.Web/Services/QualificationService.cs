using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly ApplicationDbContext context;

        public QualificationService(ApplicationDbContext context) => this.context = context;

        public void AddQualification(Qualification Qualification)
        {
            if (Qualification == null) throw new ArgumentException("Cannot add empty protocol object!");

            context.Qualifications.Add(Qualification);
            context.SaveChanges();
        }

        public void DeleteQualification(int qualificationId)
        {
            var qualificationToDelete = context.Qualifications.Find(qualificationId);

            if (qualificationToDelete == null) throw new ArgumentException($"There is no Protocol of ID:{qualificationId}");

            context.Qualifications.Remove(qualificationToDelete);

            context.SaveChanges();
        }

        public Qualification GetQualificationById(int qualificationId)
        {
            return context.Qualifications
                .Include(qualification => qualification.EmployeesQualifications)
                    .ThenInclude(eq => eq.Employee)
                .FirstOrDefault(qualification => qualification.Id == qualificationId);
        }

        public IEnumerable<Qualification> GetQualifications()
        {
            return context.Qualifications
                .Include(qualification => qualification.EmployeesQualifications)
                .ToList();
        }

        public void UpdateQualification(Qualification qualification)
        {
            var qualificationToUpdate = context.Qualifications.Find(qualification.Id);

            if (qualificationToUpdate == null) throw new ArgumentException($"Cannot update protocol of ID:{qualification.Id}");

            qualificationToUpdate.Name = qualification.Name;
            qualificationToUpdate.Description = qualification.Description;
            qualificationToUpdate.QualificationType = qualification.QualificationType;

            context.SaveChanges();
        }
    }
}
