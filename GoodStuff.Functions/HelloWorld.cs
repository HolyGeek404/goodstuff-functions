using System.Net;
using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GoodStuff.Functions;

public class HelloWorld
{
    [Function("HelloWorld")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var credential = new DefaultAzureCredential();
        var token = await credential.GetTokenAsync(
            new TokenRequestContext(["api://56b1c593-a584-4622-b223-bcf0fb117cb1/.default"])
        );

        
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteStringAsync("Hello world");
        return response;
    }
}