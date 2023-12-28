using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
