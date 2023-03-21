using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class MedicalCar
    {
        [Key]
        public int MedicalCarId { get; set; }
        public int? IdPerson { get; set; }
        public DateTime? DateMedicalCar { get; set; }
        public string? PlaceExit { get; set; }
        public string? ReasonExit { get; set; }
        public string? Diagnosis { get; set; }
        public string? ResultExit { get; set; }
        public string? IssueExit { get; set; }
        public int? IdDoctor { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        //public virtual PersonalDate IdPersonNavigation { get; set; }
    }
}
