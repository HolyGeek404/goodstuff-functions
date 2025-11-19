using Microsoft.Azure.Functions.Worker.Http;

namespace GoodStuff.Functions.Services;

public interface IFunctionService
{
    Task<HttpResponseMessage> HandleRequest(HttpRequestData request, string api);
}