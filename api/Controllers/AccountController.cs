using api.Interfaces;
using api.Models;
using api.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService services;
        private readonly SignInManager<AppUser> signingManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService services, SignInManager<AppUser> signingManager)
        {
            this.userManager = userManager;
            this.services = services;
            this.signingManager = signingManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new AppUser { UserName = registerDto.UserName, Email = registerDto.Email };
                var createdUser = await userManager.CreateAsync(user, registerDto.Password);

                // Check if user creation was successful
                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "User");
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Failed to add user to role");
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = services.CreateToken(user)

                            }
                        );
                    }
                }
                else
                {
                    // Iterate over the errors and add them to ModelState
                    foreach (var error in createdUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return BadRequest(ModelState);  // Return detailed password validation errors
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid username!");
            }
            var result = await signingManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password!");
            }
            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = services.CreateToken(user)
            });
            {
            }
        }

    }
}