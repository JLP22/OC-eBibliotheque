using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.ViewModels
{
    public class RechercherViewModel
    {
        [Display(Name = "Chaine de caractères à rechercher")]
        public string Chaine { get; set; }
    }
}