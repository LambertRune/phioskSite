using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public DateOnly ExpireDate { get; set; }

        //public User? User { get; set; }
        //public int? UserId { get; set; }
    }
}
