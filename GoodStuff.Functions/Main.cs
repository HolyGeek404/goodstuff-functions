using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using GoodStuff.Functions.Services;

namespace GoodStuff.Functions;

public class Main(ILogger<Main> logger, IFunctionService functionService)
{
    
    [Function("ApiGateway")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET", "POST", "PATCH", "DELETE", Route = "proxy/{api}/{endpoint}")]
        HttpRequestData req,
        string api)
    {
        logger.LogInformation("Function triggered. API: {Api}, Method: {Method}", api, req.Method);

       
        await functionService.HandleRequest(req, api);
        
        
        return req.CreateResponse(HttpStatusCode.OK);
    }
}