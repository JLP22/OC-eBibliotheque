using OC_eBibliotheque.Models;
using OC_eBibliotheque.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_eBibliotheque.Controllers
{
    public class AjouterController : Controller
    {

        private IDal dal;

        public AjouterController() : this(new DalEnDur())
        {
        }

        public AjouterController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        // GET: Ajouter
        public ActionResult Livre()
        {
            //Création de la liste à afficher
            List<SelectListItem> auteursSelectListItem = new List<SelectListItem>();

            foreach (Auteur auteur in dal.ObtenirListeAuteurs())
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = auteur.Nom,
                    Value = auteur.Id.ToString()
                };
                auteursSelectListItem.Add(selectList);
            }
            AjouterLivreViewModel ajouterLivreViewModel = new AjouterLivreViewModel
            {
                AuteursList = auteursSelectListItem
            };

            return View(ajouterLivreViewModel);
        }

        //envoi du formulaire à la vue (post)
        [HttpPost]
        [ActionName("Livre")]
        public ActionResult LivrePost(AjouterLivreViewModel ajouterLivreViewModel)
        {
            //Teste si le modele est respecté
            if (!ModelState.IsValid)
                return View(ajouterLivreViewModel);

            //teste par le nom si restaurant existe déjà
            List<Livre> _livres = dal.ObtenirListeLivres();
            if (_livres.FirstOrDefault(c => c.Titre == ajouterLivreViewModel.Titre) != null)
            {
                //Renvoi message d'erreur
                ModelState.AddModelError("Nom", "Ce livre existe déjà");
                return View(ajouterLivreViewModel);
            }

            //Teste si la date de publication est valide
            DateTime temp;
            if (!DateTime.TryParse(ajouterLivreViewModel.DateParution, out temp))               
                return View(ajouterLivreViewModel);

            //Sinon on ajoute le livre enbase et réaffiche la feuille d'ajout
            //Auteur auteur = ajouterLivreViewModel.SelectedAuteurs.First();
            int AuteurSelectId;
            //Si erreur id non int
            if (!Int32.TryParse(ajouterLivreViewModel.SelectedAuteurs.First(), out AuteurSelectId))
                return View(ajouterLivreViewModel);

            Auteur auteur = dal.ObtenirAuteurParId(AuteurSelectId);
            //Si erreur auteur non trouvé 
            if (auteur==null)
                return View(ajouterLivreViewModel);

            dal.AjouterLivre( ajouterLivreViewModel.Titre, ajouterLivreViewModel.DateParution, auteur);
            return RedirectToAction("Livre");
            
        }

    }
}