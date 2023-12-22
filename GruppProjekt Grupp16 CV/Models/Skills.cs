﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Skills
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje kompetens måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "kompetens namn får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } 

        public virtual List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
    }
}
