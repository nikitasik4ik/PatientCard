namespace PatientCard.Models
{
    public class PersonalAccount
    {
        public List<Analyze> Analyze { get; set; }
        public List<DisabilitySheet> DisabilitySheet { get; set; }
        public List<Anthropometry> Anthropometry { get; set; }
        public List<Temperature> Temperature { get; set; }
        public List<Pressure> Pressure { get; set; }
        public List<Glucose> Glucose { get; set; }
        public List<Oxygen> Oxygen { get; set; }
        public List<MedicalCar> MedicalCar { get; set; }
        public List<Operation> Operation { get; set; }
        public List<Polyclinic> Polyclinic { get; set; }
        public List<Stydy> Stydy { get; set; }
        public List<Recipe> Recipe { get; set; }
    }
}
