﻿using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Analyze
    {
        [Key]
        public int IdAnalyzes { get; set; }
        public int? IdDepartament { get; set; }
        public int? IdService { get; set; }
        public DateTime? DateAnalyzes { get; set; }
        public int? IdDoctor { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        //public virtual Departament IdDepartamentNavigation { get; set; }
        //public virtual Doctor IdDoctorNavigation { get; set; }
        //public virtual Service IdServiceNavigation { get; set; }

        //public virtual ICollection<Polyclinic> Polyclinics { get; set; } = new HashSet<Polyclinic>();
        //public virtual ICollection<Reception> Receptions { get; set; } = new HashSet<Reception>();
    }
}
