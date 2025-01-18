using Microsoft.AspNetCore.Mvc.Rendering;
using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.ViewModels
{
    public class UserOrdersVM
    {
        public int? Id { get; set; }

        public IEnumerable<SelectListItem>? Users { get; set; }
        public IEnumerable<OrderVM>? Orders { get; set; }
    }
}
