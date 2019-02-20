using ManagementApp.Web.Data.Enums;

namespace ManagementApp.Web.ViewModel
{
    public class QualificationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public QualificationType QualificationType { get; set; }
    }
}
