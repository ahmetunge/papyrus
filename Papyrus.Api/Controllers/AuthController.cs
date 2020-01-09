using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userToLogin =await _authService.LoginAsync(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result =await _authService.CreateAccessTokenAsync(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            var userExist =await _authService.UserExistAsync(userForRegisterDto.Email);

            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult =await _authService.RegisterAsync(userForRegisterDto);

            //TODO After register redirect to login
            var result =await _authService.CreateAccessTokenAsync(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

    }
}