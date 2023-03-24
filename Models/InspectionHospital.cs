﻿using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class InspectionHospital
    {
        [Key]
        public int IdInspectionHospital { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service? Service { get; set; }
        public string? InspectionPlan { get; set; }
        public string? Complaint { get; set; }
        public string? Inspection { get; set; }

        public virtual ICollection<Hospital> Hospital { get; set; } = new List<Hospital>();
    }
}
