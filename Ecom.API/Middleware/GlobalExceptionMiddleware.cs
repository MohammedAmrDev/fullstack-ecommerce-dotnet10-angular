using Ecom.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecom.API.Middleware
{
	public class GlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IHostEnvironment _environment;

		public GlobalExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
		{
			_next = next;
			_environment = environment;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception ex)
			{
				await ProblemDetailsFactory(context, ex);
			}
		}

		private async Task ProblemDetailsFactory(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/problem+json";

			ProblemDetails problemDetails = new();
			switch (ex)
			{
				case NotFoundException notFound:
					context.Response.StatusCode = StatusCodes.Status404NotFound;
					problemDetails = new ProblemDetails
					{
						Status = StatusCodes.Status404NotFound,
						Title = "Resource Not Found",
						Detail = notFound.Message,
					};
					break;

				case ValidationException validation:
					context.Response.StatusCode = StatusCodes.Status400BadRequest;
					problemDetails = new ProblemDetails
					{
						Status = StatusCodes.Status400BadRequest,
						Title = "Validation Error",
						Detail = validation.Message,
					};
					break;

				default:
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					problemDetails = new ProblemDetails
					{
						Status = StatusCodes.Status500InternalServerError,
						Title = "Internal Server Error",
						Detail = _environment.IsDevelopment() ? ex.Message : "An error occurred !",
					};
					break;
			}

			// Common problem details props
			problemDetails.Instance = context.Request.Path;

			await context.Response.WriteAsJsonAsync(problemDetails);
		}
	}
}
