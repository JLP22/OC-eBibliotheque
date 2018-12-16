using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    public class DalEnDur: IDal
    {

        private List<Client> listeDesClients;
        private List<Auteur> listeDesAuteurs;
        private List<Livre> listeDesLivres;

        //Constructeur
        public DalEnDur()
        {
            //Clients par défaut
            listeDesClients = new List<Client>
            {
                new Client { Nom = "NomClient1", Email = "Client1@email.com" },
                new Client { Nom = "NomClient2", Email = "Client2@email.com" }
            };

            //Auteurs par défaut
            listeDesAuteurs = new List<Auteur>
            {
                new Auteur { Id = 1, Nom = "auteur1" },
                new Auteur { Id = 2, Nom = "auteur2" },
                new Auteur { Id = 3, Nom = "auteur3" }
            };

            //Livres par défaut

            Auteur auteur1 = ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 1);
            Auteur auteur2 = ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 2);
            Auteur auteur3 = ObtenirListeAuteurs().FirstOrDefault(c => c.Id == 3);

            Client client1 = ObtenirListeClients().FirstOrDefault(c => c.Email == "Client1@email.com");
            Client client2 = ObtenirListeClients().FirstOrDefault(c => c.Email == "Client2@email.com");

            listeDesLivres = new List<Livre>
            {
                new Livre { Id = 1, Titre = "Titre livre 1", DateParution = DateTime.Now.AddMonths(-1).ToString("d") , Auteur = auteur1, Emprunteur = client1 },
                new Livre { Id = 2, Titre = "Titre livre 2", DateParution = DateTime.Now.AddMonths(-2).ToString("d") , Auteur = auteur2, Emprunteur = client2 },
                new Livre { Id = 3, Titre = "Titre livre 3", DateParution = DateTime.Now.AddMonths(-3).ToString("d") , Auteur = auteur3, Emprunteur = client1 },
                new Livre { Id = 4, Titre = "Titre livre 4", DateParution = DateTime.Now.AddMonths(-4).ToString("d") , Auteur = auteur1  },
                new Livre { Id = 5, Titre = "Titre livre 5", DateParution = DateTime.Now.AddMonths(-5).ToString("d") , Auteur = auteur2  }
            };
          
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //              Clients
        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------
        // Recherche tous les clients
        //---------------------------------------------------------------------
        public List<Client> ObtenirListeClients()
        {
            return listeDesClients;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //              Auteurs
        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------
        // Recherche tous les auteurs
        //---------------------------------------------------------------------
        public List<Auteur> ObtenirListeAuteurs()
        {
            return listeDesAuteurs;
        }

        //---------------------------------------------------------------------
        // Détails d'un livre par son identifiant 
        //---------------------------------------------------------------------
        public Auteur ObtenirAuteurParId(int id)
        {

            return listeDesAuteurs.FirstOrDefault(c => c.Id == id);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //              Livres
        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------
        // Recherche tous les livres
        //---------------------------------------------------------------------
        public List<Livre> ObtenirListeLivres()
        {
            return listeDesLivres;
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

            foreach (Livre livre in livres)
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

        //---------------------------------------------------------------------
        // Ajout d'un livre par son identifiant 
        //---------------------------------------------------------------------     
        public void AjouterLivre(string titre, string dateParution, Auteur auteur)
        {
            int id = listeDesLivres.Count == 0 ? 1 : listeDesLivres.Max(r => r.Id) + 1;
            listeDesLivres.Add(
                new Livre { Id = id, Titre = titre, DateParution = dateParution, Auteur = auteur }
                );
        }

        public void Dispose()
        {
            listeDesClients = new List<Client>();
            listeDesAuteurs = new List<Auteur>();
            listeDesLivres = new List<Livre>();
        }
    }
}
 