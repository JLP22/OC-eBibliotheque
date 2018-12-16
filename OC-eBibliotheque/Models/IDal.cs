using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OC_eBibliotheque.Models
{
    interface IDal : IDisposable
    {

        List<Client> ObtenirListeClients();
        List<Auteur> ObtenirListeAuteurs();
        List<Livre> ObtenirListeLivres();
        List<Livre> ObtenirListeLivresEmpruntes();
        List<Livre> ObtenirListeLivresAvecTitreOuNomAuteurContenant(string chaine);
        List<Livre> ObtenirListeLivresAuteur(int id);
        Livre ObtenirLivreParId(int id);
        void AjouterLivre(string titre, string dateParution, Auteur auteur);
        Auteur ObtenirAuteurParId(int id);

    }
}
