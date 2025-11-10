using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;

/// <summary>
///     Extension methods for configuring Cortex Mediator services in a WebApplicationBuilder.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///     Adds the Cortex Mediator middleware to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder to configure.</param>
    public static void AddCortexMediatorMiddleware(this WebApplicationBuilder builder)
    {
        // Add Mediator Injection Configuration
        builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

        // Add Cortex Mediator for Event Handling
        builder.Services.AddCortexMediator(
            builder.Configuration,
            [typeof(Program)], options =>
            {
                options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
                //options.AddDefaultBehaviors();
            });
    }
}