using Ecom.API.Middleware;
using Ecom.Applcation;
using Ecom.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services to the container
builder.Services.InfrastructureConfiguration(builder.Configuration);
builder.Services.ApplicationConfiguration();

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails(options =>
{
	options.CustomizeProblemDetails = context =>
	{
		context.ProblemDetails.Instance = context.HttpContext.Request.Path;
		context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
		context.ProblemDetails.Extensions["timestamp"] = DateTime.UtcNow;
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();

	app.UseSwagger();
	app.UseSwaggerUI();

	app.MapScalarApiReference();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
