using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Core.DTOs;
using UserService.Core.ServiceContracts;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService _userService) : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest, IValidator<RegisterRequest> validator)
        {
            // check if request is not null
            if (registerRequest == null)
            {
                return BadRequest("Invalid request");
            }
            var validationResult = validator.Validate(registerRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);

            }

            AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);
            if (authenticationResponse == null || !authenticationResponse.Sucess)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest, IValidator<LoginRequest> _validator)
        {
            // check if request is not null
            if (loginRequest == null)
            {
                return BadRequest("Bad Request");
            }

            var validationResult = await _validator.ValidateAsync(loginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse == null || !authenticationResponse.Sucess)
            {
                return Unauthorized("User is not Authorized.");

            }
            return Ok(authenticationResponse);
        }
    }
}
