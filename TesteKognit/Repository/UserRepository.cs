using TesteKognit.Models;
using TesteKognit.Services;

namespace TesteKognit.Repository
{
    public class UserRepository
    {
        private readonly UserService _user;

        public UserRepository()
        {
            _user = new UserService();
        }

        public List<User> GetAllUsers
        {
            get
            {
                return _user.GetAllUsers();
            }
        }

        public User GetUserById(int id)
        {
            return _user.GetUserById(id);
        }

        public void InserirUser(User user)
        {
            _user.InsertUser(user);
        }

    }
}