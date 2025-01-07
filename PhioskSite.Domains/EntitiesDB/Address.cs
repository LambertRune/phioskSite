using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Domains.EntitiesDB
{
        public class Address
        {
            public int Id { get; set; }

            public string Street { get; set; } = null!;

            public string Number { get; set; } = null!;

            public string City { get; set; } = null!;

            public string PostalCode { get; set; } = null!;

            public string Country { get; set; } = null!;

            public ICollection<User>? Users { get; set; } = new List<User>();
        }

    
}
