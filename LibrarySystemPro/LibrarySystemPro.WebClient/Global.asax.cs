using AutoMapper;
using LibrarySystemPro.DataAccessLayer.Profiles;
using LibrarySystemPro.WebClient.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LibrarySystemPro.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(x =>
            {
                x.AddProfile<AuthorBusinessToAuthorDataProfile>();
                x.AddProfile<AuthorDataToAuthorBusinessProfile>();
                x.AddProfile<BookBusinessToBookDataProfile>();
                x.AddProfile<BookDataToBookBusinessProfile>();
                x.AddProfile<RentedBookBusinessToRentedBookDataProfile>();
                x.AddProfile<RentedBookDataToRentedBookBusinessProfile>();
                x.AddProfile<UserBusinessToUserDataProfile>();
                x.AddProfile<UserDataToUserBusinessProfile>();
                x.AddProfile<AuthorBusinessToAuthorWebProfile>();
                x.AddProfile<AuthorWebToAuthorBusinessProfile>();
                x.AddProfile<BookBusinessToBookWebProfile>();
                x.AddProfile<BookWebToBookBusinessProfile>();
                x.AddProfile<RentedBookBusinessToRentedBookWebProfile>();
                x.AddProfile<RentedBookWebToRentedBookBusiness>();
                x.AddProfile<UserBusinessToUserWebProfile>();
                x.AddProfile<UserWebToUserBusinessProfile>();
            }
            );

        }
    }
}
