using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     Extension methods for configuring Publishing context services in a WebApplicationBuilder.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///     Adds the Publishing context services to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder"></param>
    public static void AddPublishingContextServices(this WebApplicationBuilder builder)
    {
        // Here you would typically add services related to the Publishing context,
        // such as repositories, query services, command handlers, etc.
        // For example:
        //
        // builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        // builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        //
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
        builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddScoped<ITutorialCommandService, TutorialCommandService>();
        builder.Services.AddScoped<ITutorialQueryService, TutorialQueryService>();
    }
}