using Cortex.Mediator.Commands;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;

/// <summary>
/// Logging behavior for commands
/// </summary>
public class LoggingCommandBehavior<TCommand> : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(TCommand command, CommandHandlerDelegate next, CancellationToken cancellationToken)
    {
        // Here you can add logging logic before the command is handled
        Console.WriteLine($"Handling command of type {typeof(TCommand).Name}");
        await next();
    }
}