namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a unique identifier for an Acme Asset.
/// </summary>
/// <param name="Identifier">The unique identifier as a GUID.</param>
public record AcmeAssetIdentifier(Guid Identifier)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcmeAssetIdentifier"/> class with a new GUID.
    /// </summary>
    public AcmeAssetIdentifier() : this(Guid.NewGuid()) {}
}