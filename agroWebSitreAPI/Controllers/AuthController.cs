using agroWebSitreAPI.Application.Services;
using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace agroWebSitreAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository usersRepository)
        {
            _userRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        [HttpPost]
        [Route("api/v1/auth")]
        public IActionResult Auth([FromBody] LoginDTO login) 
        {
            var user = _userRepository.FindByEmail(login.Email, login.Password);
            if (user == null)
            {
                return BadRequest("Email or password invalid!");
            }

            var token = TokenService.GenerateToken(user);
                return Ok(token);
        }

    }
}
