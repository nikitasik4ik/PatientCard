using Microsoft.VisualBasic;
using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Polyclinic
    {
        [Key]
        public int PolyclinicId { get; set; }

        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        public DateTime? Date { get; set; }

        public int? DepartamentId { get; set; }

        public string Complaints { get; set; }

        public string Reason { get; set; }
        public int? InspectionId { get; set; }

        public int? FinancingId { get; set; }

        public string Conditions { get; set; }

        public int? AnalyzeId { get; set; }

        public int? StudyId { get; set; }
        //public virtual Financing Financing { get; set; }
        //public virtual Analyze Analyze { get; set; }
        //public virtual Study Study { get; set; }
        //public virtual Inspection Inspection { get; set; }
        //public virtual Departament Department { get; set; }
        //public virtual PersonalDate Person { get; set; }
    }

}
