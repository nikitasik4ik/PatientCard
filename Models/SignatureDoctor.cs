using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class SignatureDoctor
    {
        [Key]
        public int IdSignatureDoctor { get; set; }
        public string? Information { get; set; }
        public string? Certificate { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        public DateTime? ValidWith { get; set; }
        public DateTime? ValidUntil { get; set; }
    }

}
