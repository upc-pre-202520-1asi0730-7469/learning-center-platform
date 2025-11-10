using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace ACME.LearningCenterPlatform.API.Shared.Application.Internal.EventHandlers;

/// <summary>
///     Base interface for event handlers
/// </summary>
/// <typeparam name="TEvent">The type of event to handle</typeparam>
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}