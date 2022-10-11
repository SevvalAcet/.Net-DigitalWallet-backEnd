using Business;
using Digiwallet.Businness.Abstarct;
using Digiwallet.DataAccess.Abstract;
using Digiwallet.Entities;

namespace Digiwallet.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(User user)
        {
            var passwordHash = PasswordHelper.HashPassword(user.UserPassword);
            var result = await _userRepository.GetAsync(item => item.Email == user.Email && item.Password == passwordHash);
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _userRepository.GetUserById(id);
            return result;
        }

        public async Task<User> Register(User user)
        {
            var result = await _userRepository.Register(user);
            return result;
        }

        public async Task<User> Update(User user)
        {
            var result = await _userRepository.Update(user);
            return result;
        }
    }

}
