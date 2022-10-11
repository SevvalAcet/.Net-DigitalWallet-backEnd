using Digiwallet.Entities;

namespace Digiwallet.Businness.Abstarct
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);

        Task<User> Update(User user);

        Task<User> Register(User user);

        Task<User> Login(User user);
    }
}
