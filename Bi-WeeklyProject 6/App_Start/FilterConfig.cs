using System.Web;
using System.Web.Mvc;

namespace Bi_WeeklyProject_6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
