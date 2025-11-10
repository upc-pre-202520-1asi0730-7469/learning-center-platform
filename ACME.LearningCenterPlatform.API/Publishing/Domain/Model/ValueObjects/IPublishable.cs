namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
///     Interface defining publishing workflow actions for publishable entities.
/// </summary>
public interface IPublishable
{
    void SendToEdit();
    void SendToApproval();
    void ApproveAndLock();
    void Reject();
    void ReturnToEdit();
}