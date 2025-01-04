using System;
using System.Collections.Generic;

namespace PhioskSite.Domains.EntitiesDB;

public partial class UserAccount
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public int? Address { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
