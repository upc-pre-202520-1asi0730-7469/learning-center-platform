using Cortex.Mediator.Notifications;

namespace ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

/// <summary>
/// Represents a domain event in the system.
/// </summary>
/// <remarks>
/// This interface extends INotification to integrate with the mediator pattern for event handling.
/// Domain events are used to signal that something of interest has occurred within the domain.
/// They help in decoupling different parts of the system by allowing components to react to events
/// without being tightly coupled to the event source.
/// </remarks>
public interface IEvent : INotification
{
    
}