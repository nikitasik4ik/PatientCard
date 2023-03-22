using PatientCard.Areas.Identity.Data;

namespace PatientCard.Models
{
    public class DisabilitySheet
    {
        public int DisabilitySheetId { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public int? IdDoctor { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? IdDepartement { get; set; }
        public DateTime? DateOfSinging { get; set; }
        public string? Reason { get; set; }

        //public virtual Departement IdDepartementNavigation { get; set; }
        //public virtual Doctor IdDoctorNavigation { get; set; }
        //public virtual PersonalDate IdPersonNavigation { get; set; }
    }
}
