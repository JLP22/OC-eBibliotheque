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

        private IDal dal;

        public AfficherController() : this(new DalEnDur())
        {
        }

        public AfficherController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        public ActionResult Livres()
        {
            List<Livre> ListeDesLivres = dal.ObtenirListeLivres();
            return View("Livres", ListeDesLivres);
            
        }

        public ActionResult Auteurs()
        {
            List<Auteur> listedesAuteurs = dal.ObtenirListeAuteurs();
            return View("Auteurs", listedesAuteurs);
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
                    List<Livre> auteurLivres = dal.ObtenirListeLivresAuteur(numId);

                    if (auteurLivres.Count > 0)
                    {
                        return View("AuteurLivres", auteurLivres);
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
                    Livre livredetails = dal.ObtenirLivreParId(numId);

                    if (livredetails == null)
                        return View("Error");
                    else
                    {
                        return View("LivreDetails", livredetails);
                    }
                }
            }
        }
    }
}