using System;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        public int? UserId { get; set; }
        public int? DepartamentId { get; set; }
        public int? ReceptionId { get; set; }
        public int? InspectionHospitalId { get; set; }
        public DateTime? DateReceipt { get; set; }
        public DateTime? DateDischarge { get; set; }
        public string? Number { get; set; }
        public int? Ward { get; set; }
        public int? DoctorHospitalId { get; set; }
        public int? OperationId { get; set; }

        //public virtual Departament Department { get; set; }
        //public virtual DoctorHospital DoctorHospital { get; set; }
        //public virtual InspectionHospital InspectionHospital { get; set; }
        //public virtual Operation Operation { get; set; }
        //public virtual PersonalDate Person { get; set; }
        //public virtual Reception Reception { get; set; }
    }
}
