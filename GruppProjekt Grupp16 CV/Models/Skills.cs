﻿using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje kompetens måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "kompetens namn får inte vara längre än 100 karaktärer!")]
        public string Titel { get; set; } = null!;
    }
}
