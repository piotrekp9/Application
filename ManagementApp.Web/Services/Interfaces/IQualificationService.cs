using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IQualificationService
    {
        IEnumerable<Qualification> GetQualifications();
        Qualification GetQualificationById(int qualificationId);
        void DeleteQualification(int qualificationId);
        void AddQualification(Qualification qualification);
        void UpdateQualification(Qualification qualification);
    }
}
