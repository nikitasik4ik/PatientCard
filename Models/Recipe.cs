using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string? CodeRecipe { get; set; }

        public DateTime? DateRecipe { get; set; }

        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        public int? IdDoctor { get; set; }

        public string? RecipeName { get; set; }

        //public virtual Doctor? IdDoctorNavigation { get; set; }

        //public virtual PersonalDate? IdPersonNavigation { get; set; }
    }
}
