namespace PatientCard.Models
{
    public class HealthDiary
    {
        public IEnumerable<Temperature> Temperature { get; set; }
        public IEnumerable<Anthropometry> Anthropometry { get; set; }
        public IEnumerable<Oxygen> Oxygen { get; set; }
        public IEnumerable<Glucose> Glucose { get; set; }
        public IEnumerable<Pressure> Pressure { get; set; }
    }
}
