using System;
using System.Collections.Generic;

namespace PhioskSite.Domains.EntitiesDB;

public partial class Invoice
{
    public int InvoiceNo { get; set; }

    public DateOnly InvoiceDate { get; set; }

    public DateOnly IssueDate { get; set; }

    public int AccountNo { get; set; }

    public virtual UserAccount AccountNoNavigation { get; set; } = null!;
}
