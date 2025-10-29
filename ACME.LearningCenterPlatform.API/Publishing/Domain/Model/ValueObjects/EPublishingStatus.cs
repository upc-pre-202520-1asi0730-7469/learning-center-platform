namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Enumeration representing the publishing status of an item.
/// </summary>
public enum EPublishingStatus
{
    Draft,
    ReadyToEdit,
    ReadyToApproval,
    ApprovedAndLocked
}