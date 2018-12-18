using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    
    //---------------------------------------------------------------------
    // Initialise un jeu de données "BDD" static et modifiable
    //---------------------------------------------------------------------

    public static class Bdd
    {
       

        // --------- Auteurs ---------
        private static List<Auteur> auteurs = new List<Auteur>{
                 new Auteur { Id = 1, Nom = "auteur1" },
                new Auteur { Id = 2, Nom = "auteur2" },
                new Auteur { Id = 3, Nom = "auteur3" }
        };
        // read-write variable
        public static List<Auteur> Auteurs
        {
            get
            {
                return auteurs;
            }
            set
            {
                auteurs = value;
            }
        }

        // --------- Clients ---------
        private static List<Client> clients = new List<Client>{
                new Client { Nom = "NomClient1", Email = "Client1@email.com" },
                new Client { Nom = "NomClient2", Email = "Client2@email.com" }
        };
        // read-write variable
        public static List<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
            }
        }

        // --------- Livres ---------
        private static List<Livre> livres = new List<Livre>{
                new Livre { Id = 1, Titre = "Titre livre 1", DateParution = DateTime.Now.AddMonths(-1).ToString("d") , Auteur = auteurs.FirstOrDefault(c => c.Id == 1), Emprunteur = clients.FirstOrDefault(c => c.Email == "Client1@email.com")},
                new Livre { Id = 2, Titre = "Titre livre 2", DateParution = DateTime.Now.AddMonths(-2).ToString("d") , Auteur = auteurs.FirstOrDefault(c => c.Id == 2), Emprunteur = clients.FirstOrDefault(c => c.Email == "Client2@email.com")},
                new Livre { Id = 3, Titre = "Titre livre 3", DateParution = DateTime.Now.AddMonths(-3).ToString("d") , Auteur = auteurs.FirstOrDefault(c => c.Id == 3), Emprunteur = clients.FirstOrDefault(c => c.Email == "Client3@email.com")},
                new Livre { Id = 4, Titre = "Titre livre 4", DateParution = DateTime.Now.AddMonths(-4).ToString("d") , Auteur = auteurs.FirstOrDefault(c => c.Id == 1)},
                new Livre { Id = 5, Titre = "Titre livre 5", DateParution = DateTime.Now.AddMonths(-5).ToString("d") , Auteur = auteurs.FirstOrDefault(c => c.Id == 2)}
        };
        // read-write variable
        public static List<Livre> Livres
        {
            get
            {
                return livres;
            }
            set
            {
                livres = value;
            }
        }
    }
}