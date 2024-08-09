using DailyPlanner.Facades.Contracts;
using DailyPlanner.Facades.Exceptions;
using DailyPlanner.Model;
using DailyPlanner.Services.Dtos;
using DailyPlanner_RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DailyPlanner_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AbstractController
    {
        private readonly ApiSettings _settings;
        private readonly IAuthFacade _authFacade;

        public AuthController(ILogger<AuthController> logger, ApiSettings settings, IAuthFacade authFacade)
            : base(logger)
        {
            _settings = settings;
            _authFacade = authFacade;
        }

        [HttpPost]
        [Route("singUp")]
        public async Task<IActionResult> SingUp([FromBody] SignUpModel model)
        {
            try
            {
                Logger.LogInformation("AuthController.SingUp started");

                await _authFacade.SignUp(new SignUpDto()
                {
                    Username = model.Username,
                    Password = model.Password,
                });

                Logger.LogInformation("AuthController.SingUp completed; success");
                return Ok();
            }
            catch (ValidationException ex)
            {
                Logger.LogInformation("AuthController.SingUp completed; invalid request");
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel user)
        //{
        //    Logger.LogDebug($"AuthController.Login started");

        //    var liginDto = new LoginDto()
        //    {
        //        Username = user.Username,
        //        Password = user.Password
        //    };

        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    //if (user.Password == _settings.Password)
        //    //{
        //    //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Auth.Secret));
        //    //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //    //    var tokeOptions = new JwtSecurityToken(
        //    //        issuer: "https://localhost:5001",
        //    //        audience: "https://localhost:5001",
        //    //        claims: new List<Claim>(),
        //    //        expires: DateTime.Now.AddMinutes(_settings.Auth.TokenExpireMinutes),
        //    //        signingCredentials: signinCredentials
        //    //    );
        //    //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        //    //    Logger.LogDebug($"AuthController.Login({user}) completle tokenString = {tokenString}");
        //    //    return Ok(new AuthenticatedResponse { Token = tokenString });
        //    //}
        //    //else
        //    //{
        //    //    Logger.LogWarning($"AuthController.Login({user}) invalid user data");
        //    //    return Unauthorized();
        //    //}
        //}
    }
}
