using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using MovieProject.Entities.Dtos.Users;

namespace MovieProject.WebAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            var tokenResult = _authService.CreateAccessToken(registerResult.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult.Message);
            }
            return Ok(tokenResult.Data);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var accessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!accessTokenResult.Success)
            {
                return BadRequest(accessTokenResult.Message);
            }
            return Ok(accessTokenResult.Data);
        }
    }
}
