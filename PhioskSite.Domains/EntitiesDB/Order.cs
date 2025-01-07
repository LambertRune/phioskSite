using System;
using System.Collections.Generic;

namespace PhioskSite.Domains.EntitiesDB;

public class Order
{
    public int Id { get; set; }

    public DateOnly InvoiceDate { get; set; }

    public DateOnly ExpireDate { get; set; }

    public User? User { get; set; }
    public int? UserId { get; set; }
    public ICollection<Phone>? Phones { get; set; } = new List<Phone>();
}
