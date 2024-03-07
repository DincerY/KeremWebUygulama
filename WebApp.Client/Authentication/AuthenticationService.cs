using Microsoft.AspNetCore.Http;

namespace WebApp.Client.Authentication;

public class AuthenticationService
{
    private readonly HttpContext _context;

    public AuthenticationService(HttpContext context)
    {
        _context = context;
    }

    public void Deneme()
    {
        

    }
}