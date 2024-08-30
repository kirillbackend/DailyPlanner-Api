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
                Logger.LogInformation("AuthController.SingUp started");

                if (!ModelState.IsValid)
                {
                    Logger.LogWarning($"AuthController.SingUp failed: {ModelState}");
                    return BadRequest(ModelState);
                }

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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(LoginModel loginModel)
        {
            try
            {
                Logger.LogInformation("AuthController.LogIn started");

                if (!ModelState.IsValid)
                {
                    Logger.LogWarning($"AuthController.LogIn failed: {ModelState}");
                    return BadRequest(ModelState);
                }

                var token = await _authFacade.LogIn(new LoginDto()
                {
                    Username = loginModel.Username,
                    Password = loginModel.Password,
                });

                Logger.LogInformation("AuthController.LogIn completed");
                return Ok(token);
            }
            catch (ValidationException ex)
            {
                Logger.LogWarning("AuthController.LogIn completed; invalid request");
                return BadRequest(ex);
            }
        }
    }
}
