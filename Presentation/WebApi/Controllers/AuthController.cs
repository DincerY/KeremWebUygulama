using Core.Application.Repositories;
using Core.Application.ViewModel;
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