using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }

        //[Required]
        //[StringLength(100)]
        public string? NameService { get; set; }

        //[Required]
        //[StringLength(20)]
        public string? CodeService { get; set; }
        public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();
        public virtual ICollection<Operation> Operation { get; set; } = new List<Operation>();

    }
}
