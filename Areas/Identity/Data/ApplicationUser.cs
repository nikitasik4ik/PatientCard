using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
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

        public ICollection<Temperature> Temperature { get; set; }  // свойство навигации
        public ICollection<Anthropometry> Anthropometry { get; set; }  // свойство навигации
        public ICollection<Glucose> Glucose { get; set; }  // свойство навигации
        public ICollection<Oxygen> Oxygen { get; set; }  // свойство навигации
        public ICollection<Pressure> Pressure { get; set; }  // свойство навигации
        public ICollection<Analyze> Analyze { get; set; }  // свойство навигации
    }
}
