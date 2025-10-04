using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLoop.Application.Features.Users.DTOs;
using ToyLoop.Domain.Entities;

namespace ToyLoop.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);

        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);  
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
