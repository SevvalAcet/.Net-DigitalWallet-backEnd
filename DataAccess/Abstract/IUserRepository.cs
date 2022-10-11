using Digiwallet.Entities;
using System.Linq.Expressions;

namespace Digiwallet.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> GetUserById(int id);
        Task<User> Update(User user);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);

    }
}
