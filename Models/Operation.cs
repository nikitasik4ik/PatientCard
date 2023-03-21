using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }

        public DateTime? DateOperation { get; set; }

        public int? IdDepartamnet { get; set; }

        public string? DiagnosisOperation { get; set; }

        public int? IdService { get; set; }

        public TimeSpan? DurationOperation { get; set; }

        public string? ProtocolOperation { get; set; }

        public int? IdFinancing { get; set; }

        public int? IdDoctorHospital { get; set; }

        //public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

        //[ForeignKey("IdDepartamnet")]
        //public virtual Departament IdDepartamnetNavigation { get; set; }

        //[ForeignKey("IdDoctorHospital")]
        //public virtual Doctor IdDoctorHospitalNavigation { get; set; }

        //[ForeignKey("IdFinancing")]
        //public virtual Financing IdFinancingNavigation { get; set; }

        //[ForeignKey("IdService")]
        //public virtual Service IdServiceNavigation { get; set; }
    }
}

