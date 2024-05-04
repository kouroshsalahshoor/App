using Domain;
using Domain.Dtos;
using Domain.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.Phone,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (string.IsNullOrEmpty(dto.Role) || (dto.Role != ApplicationConstants.Role_Admin && dto.Role != ApplicationConstants.Role_User))
            {
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "Wrong Role name"
                });
            }
            IdentityResult? result;
            if (await _roleManager.Roles.Select(x => x.Name).AnyAsync(x => x == dto.Role) == false)
            {
                result = await _roleManager.CreateAsync(new IdentityRole { Name = dto.Role });
                if (result.Succeeded == false)
                {
                    return BadRequest(new ResponseDto
                    {
                        Errors = result.Errors.Select(x => x.Description).ToList()
                    });
                }
            }

            result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded == false)
            {
                return BadRequest(new ResponseDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToList()
                });
            }

            result = await _userManager.AddToRoleAsync(user, dto.Role);
            if (result.Succeeded == false)
            {
                return BadRequest(new ResponseDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToList()
                });
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
