using PatientCard.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Hospital
    {
        [Key]
        public int IdHospital { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        public virtual Organization? Organization { get; set; }
        public int? IdReception { get; set; }
        public int? InspectionHospitalId { get; set; }
        public virtual InspectionHospital? InspectionHospital { get; set; }
        public DateTime? DateReceipt { get; set; }
        public DateTime? DateDischarge { get; set; }
        public string? Number { get; set; }
        public int? Ward { get; set; }
        public int? IdOperation { get; set; }
        [ForeignKey("IdOperation")]
        public virtual Operation? Operation { get; set; }
        [ForeignKey("IdReception")]
        public virtual Reception? Reception { get; set; }
    }
}
