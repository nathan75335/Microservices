using CustomValidation.Api.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CustomValidation.Api.Middleware;

public class ExceptionsHandlerMiddleware
{
     private readonly RequestDelegate _next;

     /// <summary>
     /// Initializes a instance of <see cref="ExceptionHandlerMiddleware"/>
     /// </summary>
     /// <param name="next">A <see cref="RequestDelegate"/></param>
     public ExceptionsHandlerMiddleware(RequestDelegate next)
     {
         _next = next;
     }

     /// <summary>
     /// Handler of exceptions.
     /// </summary>
     /// <param name="context">Http context.</param>
     public async Task InvokeAsync(HttpContext context)
     {
         try
         {
             await _next(context);
         }
         catch (Exception ex)
         {
             string message = $"Error occured: {ex.Message}{Environment.NewLine}{ex.StackTrace}";
             
             await HandleExceptionAsync(context, ex);
         }
     }

     /// <summary>
     ///  Function to handle the exception
     /// </summary>
     /// <param name="httpContext">Http context.</param>
     /// <param name="exception">Current exception.</param>
     private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
     {
         httpContext.Response.StatusCode = GetCodeStatus(exception);

         await httpContext.Response
                .WriteAsync($"{httpContext.Response.StatusCode}\n Message : {exception.Message}");
     }

     /// <summary>
     /// Function to get the status of the exception
     /// </summary>
     /// <param name="exception">Current exception.</param>
     private static int GetCodeStatus(Exception exception)
     {
         if (exception is NullException)
         {
             return StatusCodes.Status400BadRequest;
         }
         else if(exception is ArgumentException)
         {
             return StatusCodes.Status400BadRequest;
         }

         return StatusCodes.Status500InternalServerError;
     }
}
