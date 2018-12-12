using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    public class Clients
    {
        //---------------------------------------------------------------------
        // Initialise une liste de clients
        //---------------------------------------------------------------------
        public List<Client> ObtenirListeClients()
        {
            return new List<Client>
            {
                new Client { Nom = "NomClient1", Email = "Client1@email.com" },
                new Client { Nom = "NomClient2", Email = "Client2@email.com" }
            };
        }
    }
}