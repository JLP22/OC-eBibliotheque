﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    //---------------------------------------------------------------------
    // Modèle Livre 
    //---------------------------------------------------------------------
    public class Livre
    {

        public int Id { get; set; }

        [Key]
        [Required(ErrorMessage = "Le titre du livre doit être saisi")]
        public string Titre { get; set; }

        [Display(Name = "Date de parution")]
        [Required(ErrorMessage = "La date de parution du livre est obligatoire")]
        [StringLength(10)]
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$", ErrorMessage = "La date de parution du livre doit être saisi au format dd/mm/yyyy")]
        public string DateParution { get; set; }

        [Required(ErrorMessage = "L'auteur du livre doit être saisi")]
        public Auteur Auteur { get; set; }
        public Client Emprunteur { get; set; }
    }
}