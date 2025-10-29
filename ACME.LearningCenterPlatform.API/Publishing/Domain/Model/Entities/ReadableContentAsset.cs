using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a readable content asset within the publishing bounded context.
/// </summary>
public class ReadableContentAsset : Asset
{
    public string ReadableContent { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadableContentAsset"/> class.
    /// </summary>
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadableContentAsset"/> class with the specified content.
    /// </summary>
    /// <param name="content">The readable content.</param>
    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }
    
    public override bool Readable => true;
    public override bool Viewable => false;
    
    /// <summary>
    /// Gets the content of the readable content asset.
    /// </summary>
    /// <returns>>The readable content as a string if available; otherwise, an empty string.</returns>
    public override string GetContent()
    {
        return ReadableContent;
    }
}