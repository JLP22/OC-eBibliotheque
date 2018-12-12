using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    public class Livres
    {
        //---------------------------------------------------------------------
        // Initialise une liste de livres
        //---------------------------------------------------------------------
        public List<Livre> ObtenirListeLivres()
        {
            Auteurs auteurs = new Auteurs();

            Auteur auteur1 = auteurs.ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 1);
            Auteur auteur2 = auteurs.ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 2);
            Auteur auteur3 = auteurs.ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 3);
            
            Clients clients = new Clients();

            Client client1 = clients.ObtenirListeClients().FirstOrDefault(c => c.Email == "Client1@email.com");
            Client client2 = clients.ObtenirListeClients().FirstOrDefault(c => c.Email == "Client2@email.com");

            return new List<Livre>
            {
                new Livre { Id = 1, Titre = "Titre livre 1", DateParution = DateTime.Now.AddMonths(-1).ToString("d") , Auteur = auteur1, Emprunteur = client1 },
                new Livre { Id = 2, Titre = "Titre livre 2", DateParution = DateTime.Now.AddMonths(-2).ToString("d") , Auteur = auteur2, Emprunteur = client2 },
                new Livre { Id = 3, Titre = "Titre livre 3", DateParution = DateTime.Now.AddMonths(-3).ToString("d") , Auteur = auteur3, Emprunteur = client1 },
                new Livre { Id = 4, Titre = "Titre livre 4", DateParution = DateTime.Now.AddMonths(-4).ToString("d") , Auteur = auteur1  },
                new Livre { Id = 5, Titre = "Titre livre 5", DateParution = DateTime.Now.AddMonths(-5).ToString("d") , Auteur = auteur2  }
            };
        }

        //---------------------------------------------------------------------
        // Recherche les livres empruntés
        //---------------------------------------------------------------------
        public List<Livre> ObtenirListeLivresEmpruntes()
        {
            return ObtenirListeLivres().FindAll(c => c.Emprunteur != null);
        }

        //---------------------------------------------------------------------
        // Recherche les livres d'après titre ou auteur
        //---------------------------------------------------------------------
        public List<Livre> ObtenirListeLivresAvecTitreOuNomAuteurContenant(string chaine)
        {
            
            List<Livre> livresRecherches = new List<Livre>();
            List<Livre> livres = ObtenirListeLivres();

            foreach(Livre livre in livres)
            {
                if (livre.Titre.ToUpper().Contains(chaine) || livre.Auteur.Nom.ToUpper().Contains(chaine))
                    livresRecherches.Add(livre);
            }
            return livresRecherches;
        }

        //---------------------------------------------------------------------
        // Recherche les livres par l'identifiant de l'auteur
        //---------------------------------------------------------------------
        public List<Livre> ObtenirListeLivresAuteur(int id)
        {
            return ObtenirListeLivres().FindAll(c => c.Auteur.Id == id);
        }

        //---------------------------------------------------------------------
        // Détails d'un livre par son identifiant 
        //---------------------------------------------------------------------
        public Livre ObtenirLivreParId(int id)
        {
            
                return ObtenirListeLivres().FirstOrDefault(c => c.Id == id);
        }
    }
}