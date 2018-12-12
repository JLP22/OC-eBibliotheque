using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    public class Auteurs
    {
        //---------------------------------------------------------------------
        // Initialise une liste d'auteurs
        //---------------------------------------------------------------------
        public List<Auteur> ObtenirListeAuteurs()
        {
            return new List<Auteur>
            {
                new Auteur { Id = 1, Nom = "auteur1" },
                new Auteur { Id = 2, Nom = "auteur2" },
                new Auteur { Id = 3, Nom = "auteur3" }
            };
        }
    }
}