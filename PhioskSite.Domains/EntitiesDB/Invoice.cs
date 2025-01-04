using System;
using System.Collections.Generic;

namespace PhioskSite.Domains.EntitiesDB;

public partial class Invoice
{
    public int Id { get; set; }

    public DateOnly InvoiceDate { get; set; }

    public DateOnly IssueDate { get; set; }

    public int? AccountNo { get; set; }

    public UserAccount? UserAccount { get; set; }
    public ICollection<Phone>? Phones { get; set; }
}
