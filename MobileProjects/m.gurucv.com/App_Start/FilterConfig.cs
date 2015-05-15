using System.Web.Mvc;
using Macrosage.Mobile.GuruCV.Filters;

namespace Macrosage.Mobile.GuruCV {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new ErrorAttributte());
        }
    }
}