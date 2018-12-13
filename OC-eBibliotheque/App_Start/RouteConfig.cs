using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OC_eBibliotheque
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //permet d’ignorer les requêtes qui ont la forme /n-importe-quoi.axd/n-importe-quoi.
            /* Les requêtes ayant pour extension axd constituent des requêtes aux HTTP handlers d’ASP.NET. 
             * Nous n’allons pas parler des handlers HTTP, sachez simplement qu’il s’agit d’une classe qui 
             * est exécutée en amont de tout traitement par le site web, avant d’afficher une page. Cela peut 
             * servir notamment à obtenir des ressources particulières, comme des fichiers CSS ou JavaScript 
             * mais aussi pourquoi pas à générer dynamiquement une image. Ici en l’occurrence, le but 
             * est d’ignorer ces éventuelles requêtes, afin qu’elles ne soient pas traitées par nos 
             * contrôleurs, et qu’elles suivent leur cycle de vie propre.*/

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            routes.MapRoute(
                name: "Rechercher",
                url: "Rechercher/Livre/{chaine}",
                defaults: new { controller = "Rechercher", action = "Livre" });

            //requêtes de type /xxx/yyy/zzz
            //instancier le contrôleurxxxController , et appeler la méthodeyyy() en lui passant en paramètre la valeurzzz
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Livres", id = UrlParameter.Optional });

            /*
             * 
            // Pour URL suivante /Ajouter/5/11
            routes.MapRoute(
            name: "Default",
            url: "{action}/{valeur1}/{valeur2}",
            defaults: new { controller = "Calculateur", action = "Ajouter", valeur1 = 0, valeur2 = 0 });
            */

            /*
            //Pour URL Calculatrice-Ajouter/2-4
            // pas obligatoire de conserver le / pour séparer les fragments d’URL
            routes.MapRoute(
            name: "Default",
            url: "Calculatrice-{action}/{valeur1}-{valeur2}",
            defaults: new { controller = "Calculateur", action = "Ajouter", valeur1 = 0, valeur2 = 0 });
            */

            /*
             //Pour l'URL jour/mois/annee
             routes.MapRoute(
            name: "Meteo",
            url: "{jour}/{mois}/{annee}",
            defaults: new { controller = "Meteo", action = "Afficher" },
            constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d+" });
             */

            /*
            //Pour nombre indeterminé de paramètre (astérisque (*), combiné au dernier paramètre)
            routes.MapRoute(
            name: "RouteAttrapeTout",
            url: "{controller}/{action}/{*id}",
            defaults: new { controller = "Accueil", action = "Index", id = UrlParameter.Optional });
             
             */


        }
    }
}
