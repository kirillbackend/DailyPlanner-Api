using DailyPlanner.Model;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Exceptions;
using DailyPlanner.Services.Facades.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AbstractController
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(ILogger<AuthController> logger, IAuthFacade authFacade)
            : base(logger)
        {
            _authFacade = authFacade;
        }

        [HttpPost]
        [Route("singUp")]
        public async Task<IActionResult> SingUp(SignUpModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Logger.LogWarning($"AuthController.SingUp failed: {ModelState}");
                    return BadRequest(ModelState);
                }

                Logger.LogInformation("AuthController.SingUp started");

                await _authFacade.SingUp(new SignUpDto()
                {
                    Username = model.Username,
                    Password = model.Password,
                });

                Logger.LogInformation("AuthController.SingUp completed; success");
                return Ok("The user is registered.");
            }
            catch (ValidationException ex)
            {
                Logger.LogInformation("AuthController.SingUp completed; invalid request");
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            Logger.LogWarning($"AuthController.Login failed: {ModelState}");
        //            return BadRequest(ModelState);
        //        }

        //        var tokenString = _authFacade.Login(new LoginDto() 
        //        {
        //            Username = model.Username,
        //            Password = model.Password
        //        });

        //        Logger.LogDebug($"AuthController.Login started");
        //        return Ok(new AuthenticatedResponse { Token = tokenString });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        Logger.LogInformation("AuthController.Login completed; invalid request");
        //        return BadRequest(ex);
        //    }

            //if (user.Password == _settings.Password)
            //{
            //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Auth.Secret));
            //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //    var tokeOptions = new JwtSecurityToken(
            //        issuer: "https://localhost:5001",
            //        audience: "https://localhost:5001",
            //        claims: new List<Claim>(),
            //        expires: DateTime.Now.AddMinutes(_settings.Auth.TokenExpireMinutes),
            //        signingCredentials: signinCredentials
            //    );
            //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            //    Logger.LogDebug($"AuthController.Login({user}) completle tokenString = {tokenString}");
            //    return Ok(new AuthenticatedResponse { Token = tokenString });
            //}
            //else
            //{
            //    Logger.LogWarning($"AuthController.Login({user}) invalid user data");
            //    return Unauthorized();
            //}
        
    }
}
