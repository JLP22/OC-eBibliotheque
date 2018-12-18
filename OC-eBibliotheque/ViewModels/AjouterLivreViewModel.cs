using OC_eBibliotheque.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_eBibliotheque.ViewModels
{
    public class AjouterLivreViewModel
    {
        [Key]
        [Required(ErrorMessage = "Le titre du livre doit être saisi")]
        public string Titre { get; set; }

        [Display(Name = "Date de parution")]
        [Required(ErrorMessage = "La date de parution du livre est obligatoire")]
        [StringLength(10)]
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$", ErrorMessage = "La date de parution du livre doit être saisi au format dd/mm/yyyy")]
        public string DateParution { get; set; }

        [Display(Name = "Auteur")]
        [Required(ErrorMessage = "L'auteur du livre doit être saisi")]
        public List<string> SelectedAuteurs { get; set; }
        public List<SelectListItem> AuteursList {
            get {
                return InitialiseListAuteur();
            }
        }

        private IDal dal;

        private List<SelectListItem> InitialiseListAuteur()
        {
            //Création de la liste à afficher
            List<SelectListItem> auteursSelectListItem = new List<SelectListItem>();
            dal = new DalEnDur();
            foreach (Auteur auteur2 in dal.ObtenirListeAuteurs())
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = auteur2.Nom,
                    Value = auteur2.Id.ToString()
                };
                auteursSelectListItem.Add(selectList);
            }

            return auteursSelectListItem;
        }
    }   
}