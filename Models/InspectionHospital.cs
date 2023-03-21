namespace PatientCard.Models
{
    public class InspectionHospital
    {
        public int InspectionHospitalId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DoctorHospitalId { get; set; }
        public int? ServiceId { get; set; }
        public string? InspectionPlan { get; set; }
        public string? Complaint { get; set; }
        public string? Inspection { get; set; }

        //    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
        //    public virtual Departament Department { get; set; }
        //    public virtual DoctorHospital DoctorHospital { get; set; }
        //    public virtual Service Service { get; set; }
    }
}
