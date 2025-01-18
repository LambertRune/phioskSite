using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public DateOnly ExpireDate { get; set; }
        public ICollection<Phone>? Phones { get; set; } = new List<Phone>();

        //public User? User { get; set; }
        //public int? UserId { get; set; }
    }
}
