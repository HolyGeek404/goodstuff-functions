using GoodStuff.Functions.Interfaces;
using Microsoft.Identity.Client;

namespace GoodStuff.Functions.Shared;

public class TokenProviderService : ITokenProviderService
{
    public async Task<string> GetAccessToken(string scope)
    {

        var tenantId = Environment.GetEnvironmentVariable("TenantId");
        var clientId = Environment.GetEnvironmentVariable("ClientId");
        var clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
        var instanceUrl = Environment.GetEnvironmentVariable("InstanceUrl");
        var authority = $"{instanceUrl}{tenantId}";

        var app = ConfidentialClientApplicationBuilder.Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri(authority))
            .Build();

        var result = await app.AcquireTokenForClient([scope]).ExecuteAsync();

        return result.AccessToken;
    }
}