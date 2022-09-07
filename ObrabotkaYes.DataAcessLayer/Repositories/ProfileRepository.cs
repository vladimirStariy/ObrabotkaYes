﻿using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Profile entity)
        {
            await _context.Profiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Profile entity)
        {
            _context.Profiles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _context.Profiles;
        }

        public async Task<Profile> Update(Profile entity)
        {
            _context.Profiles.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
