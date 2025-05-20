using System.Net;
using System.Net.Mail;
using CodeAndLanguage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeAndLanguage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // Assign role
        if (!await _roleManager.RoleExistsAsync(model.Role))
            await _roleManager.CreateAsync(new IdentityRole(model.Role));

        await _userManager.AddToRoleAsync(user, model.Role);

        // Generate email confirmation token
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { userId = user.Id, token }, Request.Scheme);

        // Send email
        SendEmail(model.Email, "Confirm your email", confirmationLink);

        return Ok("Registration successful. Please confirm your email.");
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return BadRequest("Invalid user.");

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
            return BadRequest("Email confirmation failed.");

        return Ok("Email confirmed successfully.");
    }

    private void SendEmail(string toEmail, string subject, string body)
    {
        var smtpClient = new SmtpClient("smtp.your-email-provider.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
            EnableSsl = true,
        };

        smtpClient.Send("your-email@example.com", toEmail, subject, body);
    }
}