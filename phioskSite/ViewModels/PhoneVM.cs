﻿using PhioskSite.Domains.EntitiesDB;

namespace PhioskSite.ViewModels
{
    public class PhoneVM
    {
        public int Id { get; set; }
        public string PhoneName { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public decimal Price { get; set; }

        public string Color { get; set; } = null!;

        public int StorageCapacity { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;        
    }
}
