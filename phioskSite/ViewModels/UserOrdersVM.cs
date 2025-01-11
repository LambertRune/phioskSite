using Microsoft.AspNetCore.Mvc.Rendering;
using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.ViewModels
{
    public class UserOrdersVM
    {
        public int Id { get; set; }

        public IEnumerable<SelectListItem>? Orders { get; set; }
        public ICollection<Phone>? Phones { get; set; } = new List<Phone>();
    }
}
