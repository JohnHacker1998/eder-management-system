using Eder.Domain.Entities;
using Eder.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Eder.Infrastructure.Persistence.Repositories
{
    internal class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<User> Add(User item)
        {
            await _context.Users.AddAsync(item);
            return item;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> Get()
        {
            var Users=await _context.Users.ToListAsync();
            return Users;
        }

        public Task<User> GetById(Guid Id)
        {
            var User=_context.Users.Where(user => user.Id == Id.ToString()).FirstOrDefaultAsync();
            return User;
        }

        public async Task<User> Update(User item, Guid id)
        {
            await _context.SaveChangesAsync();
            return item;

        }
    }
}
