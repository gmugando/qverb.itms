using QverbITMS.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //To force the user to login to see any content using ASP.NET MVC 4
            filters.Add(new AuthorizeAttribute());
            //filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }
}