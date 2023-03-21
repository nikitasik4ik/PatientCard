using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string? CodeRecipe { get; set; }

        public DateTime? DateRecipe { get; set; }

        public int? IdPerson { get; set; }

        public int? IdDoctor { get; set; }

        public string? RecipeName { get; set; }

        //public virtual Doctor? IdDoctorNavigation { get; set; }

        //public virtual PersonalDate? IdPersonNavigation { get; set; }
    }
}
