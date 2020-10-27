using CRUDwithMVC_EF.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CRUDwithMVC_EF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //
            // Summary:
            // This variable will be declared once the application is started and will keep the value till the application stopped. 
            // So once the application launched, it will be counting on the visitors until the application is online*/
            Application["Totaluser"] = 0;



            //
            // Summary:
            //     this helps to drop or create the tables and database if there is a change in class models
            //     when the application starts
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());

            //
            // Summary:
            //     this helps to drop or create the tables and database according to your data if there is a change in class models
            //     when the application starts
            Database.SetInitializer(new EmployeeDBContextSeeder());




            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            Application.Lock();
            Application["Totaluser"] = (int)Application["Totaluser"] + 1;
            Application.UnLock();
        }
        protected void Session_End()
        {
            Application.Lock();
            Application["Totaluser"] = (int)Application["Totaluser"] - 1;
            Application.UnLock();
        }

    }
}
