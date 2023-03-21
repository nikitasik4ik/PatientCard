namespace PatientCard.Models
{
    public class DisabilitySheet
    {
        public int DisabilitySheetId { get; set; }
        public int? UserId { get; set; }
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
