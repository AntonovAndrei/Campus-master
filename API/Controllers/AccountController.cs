using System.Formats.Asn1;
using System.Security.Claims;
using API.DTOs;
using API.Services;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;
    private readonly CampusContext _dbContext;
    
    public AccountController(UserManager<User> userManager, CampusContext dbContext,
        SignInManager<User> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _dbContext = dbContext;
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<dynamic>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        user.Employee = _dbContext.Employees.Where(e => e.UserId.Equals(user.Id)).FirstOrDefault();
        user.Resident = _dbContext.Residents.Where(e => e.UserId.Equals(user.Id)).FirstOrDefault();

        if (user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (result.Succeeded)
        {
            return await CreateUserObjectAsync(user);
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
        {
            ModelState.AddModelError("email", "Email taken");
            return ValidationProblem();
        }

        var user = new User
        {
            UserName = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            MiddleName = registerDto.MiddleName,
            BirthDate = registerDto.BirthDate.Value
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest("Problem registering user");
        
        return Ok("Registration success - please verify email");
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<dynamic>> GetCurrentUser()
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));
        return await CreateUserObjectAsync(user);
    } 
        
    private async Task<dynamic> CreateUserObjectAsync(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        string type;
        Guid id;
        if (user.Resident == null)
        {
            type = "employee";
            id = user.Employee.Id;
        }
        else
        {
            type = "resident";
            id = user.Resident.Id;
        }
        return new 
        {
            Id = id,//user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Token = await _tokenService.CreateTokenAsync(user, roles),
            Type = type,
            Roles = roles
        };
    }
}