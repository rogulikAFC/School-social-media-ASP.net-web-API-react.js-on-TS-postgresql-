﻿using Microsoft.EntityFrameworkCore;
using SchoolSocialMediaServer.DbContexts;
using SchoolSocialMediaServer.Entities;

namespace SchoolSocialMediaServer.UnitOfWork
{
    public class UserRepository : IUserRepository
    {
        private readonly SchoolSocialMediaDbContext _socialMediaDbContext;

        public UserRepository(
            SchoolSocialMediaDbContext schoolSocialMediaDbContext)
        {
            _socialMediaDbContext = schoolSocialMediaDbContext
                ?? throw new ArgumentNullException(nameof(schoolSocialMediaDbContext));
        }

        public void Add(User user)
        {
            _socialMediaDbContext.Users.Add(user);
        }

        public void Delete(User user)
        {
            _socialMediaDbContext.Users.Remove(user);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _socialMediaDbContext.Users
                .Include(u => u.School)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> ListAsync(int pageNum, int pageSize)
        {
            return await _socialMediaDbContext.Users
                .Include(u => u.School)
                .Skip((pageNum - 1) * pageSize).Take(pageSize)
                .ToListAsync();
        }
    }
}