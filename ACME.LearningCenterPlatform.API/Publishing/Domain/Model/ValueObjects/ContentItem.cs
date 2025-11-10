namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
///     Represents a content item with a specific type and content.
/// </summary>
/// <param name="Type">The type of the content item related to <see cref="EAssetType" /> enum values.</param>
/// <param name="Content">The actual content of the item.</param>
public record ContentItem(string Type, string Content);