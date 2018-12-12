using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OC_eBibliotheque.Models
{
    //---------------------------------------------------------------------
    // Modèle Livre 
    //---------------------------------------------------------------------
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string DateParution { get; set; }
        public Auteur Auteur { get; set; }
        public Client Emprunteur { get; set; }
    }
}