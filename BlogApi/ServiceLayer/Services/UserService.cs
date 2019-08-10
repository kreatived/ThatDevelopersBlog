using BlogApi.DataAccessLayer.Repositories;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer.Models;

namespace BlogApi.ServiceLayer.Services
{
    public interface IUserService
    {
        ApplicationUser GetUserBySubId(string subId);
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApplicationUser GetUserBySubId(string subId)
        {
            var user = _userRepository.GetBySubId(subId);

            if(user == null)
            {
                throw new UserNotFoundException(subId);
            }

            return new ApplicationUser
            {
                Id = user.Id,
                SubId = user.SubId,
                Name = user.Name,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Permissions = user.Permissions
            };
        }
    }
}