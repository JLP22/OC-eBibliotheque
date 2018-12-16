using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OC_eBibliotheque.Controllers
{
    /* 
     * Remplacer par contraintes sur les routes
    public class NotFoundControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // If controller not found it will be null, so we want to take control
            // of the request and send it to the ErrorController.NotFound method.
            if (controllerType == null)
            {
                requestContext.RouteData.Values["action"] = "NotFound";
                requestContext.RouteData.Values["controller"] = "Error";
                return base.GetControllerInstance(requestContext, typeof(ErrorController));
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }*/
}