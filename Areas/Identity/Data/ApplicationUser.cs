using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PatientCard.Constants;
using PatientCard.Models;

namespace PatientCard.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? Patronymic { get; set; }

        [NotMapped]
        public string FullName => ToString();

        public override string ToString()
        {
            return $"{LastName} {FirstName} {(Patronymic ?? "")}";
        }
        public string? Phone { get; set; }
        public string? GenderName { get; set; }

        public DateTime? DataBirth { get; set; }

        public int? PassportSeries { get; set; }

        public string? AdressReg { get; set; }

        public string? AdressRes { get; set; }


        public int? Snils { get; set; }

        public int? Polisy { get; set; }

        public string? PlaceWork { get; set; }
        public ICollection<Analyze> Analyze { get; set; }  // свойство навигации
        public ICollection<Anthropometry> Anthropometry { get; set; }  // свойство навигации
        public ICollection<DisabilitySheet> DisabilitySheet { get; set; }  // свойство навигации
        public ICollection<MedicalCar> MedicalCar { get; set; }  // свойство навигации
        public ICollection<Operation> Operation { get; set; }  // свойство навигации
        public ICollection<Polyclinic> Polyclinic { get; set; }  // свойство навигации
        public ICollection<Recipe> Recipe { get; set; }  // свойство навигации
        public ICollection<Stydy> Stydy { get; set; }  // свойство навигации
        public ICollection<Glucose> Glucose { get; set; }  // свойство навигации
        public ICollection<Oxygen> Oxygen { get; set; }  // свойство навигации
        public ICollection<Pressure> Pressure { get; set; }  // свойство навигации
        public ICollection<Temperature> Temperature { get; set; }  // свойство навигации
        //public ICollection<Role> Role { get; set; } // добавленное свойство
    }
}
