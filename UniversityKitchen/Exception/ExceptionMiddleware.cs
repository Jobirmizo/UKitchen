using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace UniversityKitchen.Exception;

public class ExeptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Conflict ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            var response = new
            {
                errorCode = 409,
                errorMassage = ex.Message,
                traceId = context.TraceIdentifier
            };
            var jsonResponse = JsonConvert.SerializeObject(response.errorMassage);
            await context.Response.WriteAsJsonAsync(jsonResponse);
        }
        catch (NotFoundMannually ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new
            {
                errorCode = 404,
                errorMassage = ex.Message,
                traceId = context.TraceIdentifier
            };
            var jsonResponse = JsonConvert.SerializeObject(response.errorMassage);
            await context.Response.WriteAsJsonAsync(jsonResponse);
        }
        catch (System.Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                errorCode = 500,  
                errorMessage = "Internal Server Error",
                traceId = context.TraceIdentifier,
                message = ex.Message
            };

           
            var jsonResponse = JsonConvert.SerializeObject(response.message);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}