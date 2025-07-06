using agroWebSitreAPI.Application.ViewModel;
using agroWebSitreAPI.Domain.Model.UserAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agroWebSitreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository usersRepository)
        {
            _userRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }
        //[Authorize]
        [HttpPost]
        public IActionResult Add(UserViewModel userView)
        {
            var user = new User(userView.Email, userView.Password, userView.Is_admin);
            _userRepository.Add(user);
            return Ok();
        }
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var user = _userRepository.GetAll();
            return Ok(user);
        }
    }
}
