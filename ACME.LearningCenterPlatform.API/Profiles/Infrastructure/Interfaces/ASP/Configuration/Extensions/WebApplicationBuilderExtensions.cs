using ACME.LearningCenterPlatform.API.Profiles.Application.ACL;
using ACME.LearningCenterPlatform.API.Profiles.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Profiles.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.ACL;

namespace ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///    Extension methods for configuring Profiles context services in a WebApplicationBuilder.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///   Adds the Profiles context services to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder to configure.</param>
    public static void AddProfilesContextServices(this WebApplicationBuilder builder)
    {
        // Here you would typically add services related to the Profiles context,
        // such as repositories, query services, command handlers, etc.
        // For example:
        //  builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        //  builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
        //
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
        builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
        builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

    }
} 