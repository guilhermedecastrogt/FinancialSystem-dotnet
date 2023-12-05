using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public TokenController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("/api/CreateToken")]
    public async Task<IActionResult> CreateToken([FromBody] InputModel input)
    {
        if (string.IsNullOrEmpty(input.Email) || string.IsNullOrEmpty(input.Password))
            //return BadRequest("Invalid model");
            return Unauthorized();

        var result = await _signInManager.PasswordSignInAsync(
            input.Email,
            input.Password,
            false, false
        );
        if (result.Succeeded)
        {
            var token = new TokenJWTBuilder().AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                .AddSubject("FinancialSystem")
                .AddIssuer("Test.Security.Bearer")
                .AddAudience("Test.Audience.Bearer")
                .AddClaim("UserAPUNumber", "1")
                .AddExpiry(5)
                .Builder();

            return Ok(token.value);
        }

        return Unauthorized();
    }
}