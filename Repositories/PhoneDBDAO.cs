﻿using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.DataDB;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Repositories
{
    public class PhoneDBDAO : IDBDAO<Phone>
    {
        private readonly PhioskDbContext _context;

        public PhoneDBDAO(PhioskDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Phone entity)
        {
            
             throw new NotImplementedException();
            
        }

        public Task DeleteAsync(Phone entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Phone?> FindByIdAsync(int Id)
        {
            return await _context.Phones.FindAsync(Id);
        }

        public async Task<IEnumerable<Phone>?> GetAllAsync()
        {
            return await _context.Phones
                .Include(p=> p.Order)
                .ToListAsync();
        }

        public Task UpdateAsync(Phone entity)
        {
            throw new NotImplementedException();
        }
    }
}
