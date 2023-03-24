using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Recipe
    {
        [Key]
        public int IdRecipe { get; set; }

        public string? CodeRecipe { get; set; }

        public DateTime? DateRecipe { get; set; }

        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }

        public string? RecipeName { get; set; }
        public int? IdSignatureDoctor { get; set; }
        [ForeignKey("IdSignatureDoctor")]
        public virtual SignatureDoctor? SignatureDoctor { get; set; }

    }
}
