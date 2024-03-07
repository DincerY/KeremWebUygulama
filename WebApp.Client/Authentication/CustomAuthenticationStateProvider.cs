using Microsoft.AspNetCore.Components.Authorization;

namespace WebApp.Client.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        
        throw new NotImplementedException();
    }
}