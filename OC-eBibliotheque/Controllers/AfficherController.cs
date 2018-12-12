using OC_eBibliotheque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_eBibliotheque.Controllers
{
    public class AfficherController : Controller
    {
        public ActionResult Livres()
        {
            Livres livres = new Livres();
            ViewData["Livres"] = livres.ObtenirListeLivres();
            return View("Livres");
            
        }

        public ActionResult Auteurs()
        {
            Auteurs auteurs = new Auteurs();
            ViewData["Auteurs"] = auteurs.ObtenirListeAuteurs();
            return View("Auteurs");
        }

        public ActionResult Auteur(string id)
        {
            //L'id est obligatoire
            if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
            {
                //Il doit être un numérique
                int numId;
                bool success = Int32.TryParse(id, out numId);
                if (!success)
                    return View("Error");
                else
                {
                    Livres livres = new Livres();
                    List<Livre> auteurLivres = livres.ObtenirListeLivresAuteur(numId);

                    if (auteurLivres.Count > 0)
                    {
                        ViewData["AuteurLivres"] = auteurLivres;
                        return View("AuteurLivres");
                    }
                    else return View("Error");
                }
            }
        } 

        public ActionResult Livre(string id)
        {
            //L'id est obligatoire
            if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
            {
                //Il doit être un numérique
                int numId;
                bool success = Int32.TryParse(id, out numId);
                if (!success)
                    return View("Error");
                else
                {
                    Livres livres = new Livres();
                    Livre livredetails = livres.ObtenirLivreParId(numId);

                    if (livredetails == null)
                        return View("Error");
                    else
                    {
                        ViewData["Titre"] = livredetails.Titre;
                        ViewData["DateParution"] = livredetails.DateParution;
                        ViewData["Emprunteur"] = livredetails.Emprunteur.Nom + " - " + livredetails.Emprunteur.Email;

                        return View("LivreDetails");
                    }
                }
            }
        }
    }
}