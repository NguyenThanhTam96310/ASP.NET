using System.Web;
using System.Web.Mvc;

namespace nguyenthanhtam_2122110440
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
