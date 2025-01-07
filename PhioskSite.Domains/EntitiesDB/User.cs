using System;
using System.Collections.Generic;

namespace PhioskSite.Domains.EntitiesDB;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Mail { get; set; } = null!;

    public int? AddressId { get; set; }

    // Navigatie-eigenschap naar Address
    public Address? Address { get; set; }

    public ICollection<Order>? Orders { get; set; } = new List<Order>();
}
