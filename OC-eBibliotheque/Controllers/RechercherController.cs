using OC_eBibliotheque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_eBibliotheque.Controllers
{
    public class RechercherController : Controller
    {
        private IDal dal;

        public RechercherController() : this(new DalEnDur())
        {
        }

        public RechercherController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        // GET: Rechercher
        public ActionResult Index()
        {
                return View();
        }

        //envoi du formulaire à la vue (post)
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(string chaine)
        {
            //Si la chaine est vide, on reste sur la page
            if (string.IsNullOrWhiteSpace(chaine))
                return View();
            //Sinon on affiche la liste des livres
            else
            {
                return RedirectToAction("Livre", new { chaine = chaine });
            }
        }

        // GET: Rechercher
        public ActionResult Livre(string chaine)
        {
            //L'id est obligatoire
            if (string.IsNullOrWhiteSpace(chaine))
                return View("Error");
            else
            {

                List<Livre> ListeDesLivres = dal.ObtenirListeLivresAvecTitreOuNomAuteurContenant(chaine.ToUpper());
                return View("RechercherLivres", ListeDesLivres);
            }
        }



    }
}