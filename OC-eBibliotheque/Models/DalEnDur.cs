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
            
            //Utilistation Bdd chargé en mémoire
            listeDesClients = Bdd.Clients;
            listeDesAuteurs = Bdd.Auteurs;
            listeDesLivres = Bdd.Livres;

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
 