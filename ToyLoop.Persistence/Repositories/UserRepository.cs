using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLoop.Application.Interfaces.Repositories;
using ToyLoop.Domain.Entities;
using ToyLoop.Persistence.Contexts;

namespace ToyLoop.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.User.AddAsync(user,cancellationToken);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellation)
        {
            return await _context.User
                .Include(u => u.Location)
                .Include(u => u.Role)
                .ToListAsync(cancellation);
        }

        public async Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.User
                .Include(u => u.Role)
                .Include(u => u.Location)
                .FirstOrDefaultAsync(u => u.UserId == id, cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.User.Update(user);
            await Task.CompletedTask;
        }
    }
}
