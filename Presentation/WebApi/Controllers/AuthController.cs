using Core.Application.Repositories;
using Core.Application.Validator;
using Core.Application.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] VM_AuthUser authUser)
    {
        var validator = new AuthUserValidator();
        var validationResult = await validator.ValidateAsync(authUser);
        var modelResult = "";
        if (validationResult != null)
        {
            foreach (var error in validationResult.Errors)
            {
                modelResult += "Yanlış girilen alan: " + error.PropertyName + " - Hata mesajı: " + error.ErrorMessage + "\n";
            }

            return BadRequest(modelResult);
        }

        var user = await _userRepository
            .GetWhere(u => u.Email == authUser.Email)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new ArgumentNullException("Email yada şifre hatalı");
        }

        if (user.Password == authUser.Password)
        {
            return Ok("Giriş başarılı");
        }
        else
        {
            return BadRequest("Hatalı giriş");
        }
    }
}