using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Configuration;
using System.Configuration;
using System.Web.Hosting;

namespace eSportsTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // The following encrypts the web.config so no one can see the database connection string
            // Code found: https://forums.asp.net/t/1771774.aspx?configProtectionProvider+not+allowed+in+connectionStrings+in+Web+config
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);

            foreach (string sectionName in new[] { "connectionStrings", "appSettings" })
            {
                ConfigurationSection section = config.GetSection(sectionName);

                if (!section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }
            }
            config.Save();
        }
    }
}
