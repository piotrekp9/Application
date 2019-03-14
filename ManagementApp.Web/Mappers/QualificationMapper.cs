using System.Collections.Generic;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;
using ManagementApp.Web.ViewModel.Employee;

namespace ManagementApp.Web.Mappers
{
    public class QualificationMapper
    {
        public static QualificationViewModel MapToViewModel(Qualification qualification)
        {
            return new QualificationViewModel()
            {
                Id = qualification.Id,
                Description = qualification.Description,
                Name = qualification.Name,
                QualificationType = qualification.QualificationType
            };
        }

        public static IEnumerable<QualificationViewModel> MapManyToViewModel(IEnumerable<Qualification> qualifications)
        {
            var list = new List<QualificationViewModel>();

            foreach (var qualification in qualifications)
            {
                list.Add(MapToViewModel(qualification));
            }

            return list;
        }

        public static Qualification MapToDomainModel(QualificationViewModel viewModel)
        {
            return new Qualification()
            {
                Description = viewModel.Description,
                QualificationType = viewModel.QualificationType,
                Name = viewModel.Name,
            };
        }

        public static QualificationViewModel MapToViewModel(Qualification qualification, ICollection<EmployeesQualifications> employeesQualifications)
        {
            var mappedEmployees = new List<EmployeeViewModel>();

            foreach (var employeeQualification in employeesQualifications)
            {
                mappedEmployees.Add(EmployeeMapper.MapToViewModel(employeeQualification.Employee));
            }

            return new QualificationViewModel()
            {
                Id = qualification.Id,
                Description = qualification.Description,
                Name = qualification.Name,
                QualificationType = qualification.QualificationType,
                Employees = mappedEmployees
            };
        }
    }
}
