﻿using System.Web.Mvc;

namespace Autos4Sale.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Offers", action = "Index", id = UrlParameter.Optional },
                new[] { "Autos4Sale.Web.Areas.Administration.Controllers" }
            );
        }
    }
}