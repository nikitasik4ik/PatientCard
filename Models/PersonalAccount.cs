namespace PatientCard.Models
{
    public class PersonalAccount
    {
        public Analyze Analyze { get; set; }
        public DisabilitySheet DisabilitySheet { get; set; }
        public List<Anthropometry> Anthropometry { get; set; }
        public List<Temperature> Temperature { get; set; }
        public List<Pressure> Pressure { get; set; }
        public List<Glucose> Glucose { get; set; }
        public List<Oxygen> Oxygen { get; set; }
    }
}
