using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Services
builder.AddDatabaseServices();

// Add OpenAPI Documentation Services
builder.AddOpenApiDocumentationServices();

// CORS Services Registration
builder.AddCorsServices();

// Bounded Context Services Registration
builder.AddSharedContextServices();
builder.AddPublishingContextServices();
builder.AddProfilesContextServices();
builder.AddIamContextServices();

// Add Cortex Mediator Services and Middleware
builder.AddCortexMediatorMiddleware();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
app.UseDatabaseCreationAssurance();

// Configure the HTTP request pipeline.

app.UseOpenApiDocumentation();
app.UseCorsPolicy();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRequestAuthorization();
app.MapControllers();
app.Run();