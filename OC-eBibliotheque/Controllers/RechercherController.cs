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
        // GET: Rechercher
        public ActionResult Livre(string chaine)
        {
            //L'id est obligatoire
            if (string.IsNullOrWhiteSpace(chaine))
                return View("Error");
            else
            {
                Livres livres = new Livres();
                ViewData["RechercherLivres"] = livres.ObtenirListeLivresAvecTitreOuNomAuteurContenant(chaine.ToUpper());
                return View("RechercherLivres");
            }
        }
      
    }
}