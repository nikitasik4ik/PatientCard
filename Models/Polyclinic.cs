using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Polyclinic
    {
        [Key]
        public int PolyclinicId { get; set; }

        public int? UserId { get; set; }

        public DateTime? Date { get; set; }

        public int? DepartmentId { get; set; }

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
