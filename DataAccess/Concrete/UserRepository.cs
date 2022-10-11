using Digiwallet.DataAccess.Abstract;
using Digiwallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digiwallet.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetAsync(System.Linq.Expressions.Expression<Func<User, bool>> expression)
        {
            using var dbContext = new DigiwalletDbContext();
            return await dbContext.Set<User>().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public async Task<User> GetUserById(int id)
        {
            using var dbContext = new DigiwalletDbContext();
            return await dbContext.Set<User>().FindAsync(id);
        }

        public async Task<User> Register(User user)
        {
            using var dbContext = new DigiwalletDbContext();
            await dbContext.Set<User>().AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            using var dbContext = new DigiwalletDbContext();
            dbContext.Entry(user).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
