using Skillfactory_35.Models.Users;

namespace Skillfactory_35.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }
        public List<User> Friends { get; set; }
    }
}
