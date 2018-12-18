using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    public static class Clients
    {
        //---------------------------------------------------------------------
        // Initialise une liste de clients
        //---------------------------------------------------------------------

        private static List<Client> bddClients = new List<Client>{
                new Client { Nom = "NomClient1", Email = "Client1@email.com" },
                new Client { Nom = "NomClient2", Email = "Client2@email.com" }
            };

        // read-write variable
        public static List<Client> BDDCLients
        {
            get
            {
                return bddClients;
            }
            set
            {
                bddClients = value;
            }
        }        
    }
}