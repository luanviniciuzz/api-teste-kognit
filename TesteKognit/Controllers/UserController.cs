using TesteKognit.Models;
using TesteKognit.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesteKognit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly WalletRepository _walletRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
            _walletRepository = new WalletRepository();
        }

        [HttpGet("users/listing")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _userRepository.GetAllUsers;

            if (users == null)
                return NotFound();

            return users;
        }

        [HttpGet("users/by-id/id={id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost("users/create")]
        public ActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            _userRepository.InserirUser(user);

            return NoContent();
        }

        
    }
}