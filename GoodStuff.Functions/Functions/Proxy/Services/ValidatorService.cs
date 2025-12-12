using GoodStuff.Functions.Interfaces;
using GoodStuff.Functions.Models;

namespace GoodStuff.Functions.Functions.Proxy.Services;

public class ValidatorService : IValidatorService
{
    public ApiRoute ValidateApi(string api)
    {
        var baseUrl = Environment.GetEnvironmentVariable($"ApiRoutes{api.ToUpper()}__BaseUrl");
        var scope = Environment.GetEnvironmentVariable($"ApiRoutes{api.ToUpper()}__Scope");
        if (baseUrl == null || scope == null)
            throw new ArgumentException($"Route {api} not found");

        return new ApiRoute
        {
            BaseUrl = baseUrl,
            Scope = scope
        };
    }
}