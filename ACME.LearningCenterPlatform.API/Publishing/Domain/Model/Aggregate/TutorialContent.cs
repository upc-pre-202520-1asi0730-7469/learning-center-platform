using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;

/// <summary>
/// Tutorial aggregate root implementing IPublishable interface
/// </summary>
/// <remarks>
/// This partial class extends the Tutorial aggregate root to implement the IPublishable interface,
/// providing functionality for managing publishing status and assets associated with the tutorial.
/// </remarks>
public partial class Tutorial : IPublishable
{
    
    public ICollection<Asset> Assets { get; }
    
    public EPublishingStatus Status { get; protected set; }
    
    /// <summary>
    /// Initializes a new instance of the Tutorial class with default values.
    /// </summary>
    public Tutorial()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Assets = new List<Asset>();
        Status = EPublishingStatus.Draft;
    }
    
    public bool HasReadableAssets => Assets.Any(asset => asset.Readable);
    
    public bool HasViewableAssets => Assets.Any(asset => asset.Viewable);

    public bool Readable => HasReadableAssets;
    
    public bool Viewable => HasViewableAssets;
    
    /// <summary>
    /// Checks if all assets have the specified publishing status.
    /// </summary>
    /// <param name="status">The publishing status to check against.</param>
    /// <returns>>True if all assets have the specified status; otherwise, false.</returns>
    private bool HasAllAssetsWithStatus(EPublishingStatus status)
    {
        return Assets.All(asset => asset.Status == status);
    }
    
    /// <summary>
    /// Sends the tutorial to edit if all assets are ready to edit.
    /// </summary>
    public void SendToEdit()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Sends the tutorial to approval if all assets are ready for approval.
    /// </summary>
    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approves and locks the tutorial if all assets are approved and locked.
    /// </summary>
    public void ApproveAndLock()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Rejects the tutorial, setting its status back to Draft.
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Returns the tutorial to edit status.
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Checks if an image with the specified URL already exists in the assets.
    /// </summary>
    /// <param name="imageUrl">The URL of the image to check.</param>
    /// <returns>>True if the image exists; otherwise, false.</returns>
    public bool ExistsImageByUrl(string imageUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Image && (string)asset.GetContent() == imageUrl);
    }
    
    /// <summary>
    /// Checks if a video with the specified URL already exists in the assets.
    /// </summary>
    /// <param name="videoUrl">The URL of the video to check.</param>
    /// <returns>>True if the video exists; otherwise, false.</returns>
    public bool ExistsVideoByUrl(string videoUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Video && (string)asset.GetContent() == videoUrl);
    }
    
    /// <summary>
    /// Checks if readable content with the specified content already exists in the assets.
    /// </summary>
    /// <param name="content">The readable content to check.</param>
    /// <returns>>True if the readable content exists; otherwise, false.</returns>
    public bool ExistsReadableContent(string content)
    {
        return Assets.Any(asset => asset.Type == EAssetType.ReadableContentItem && (string)asset.GetContent() == content);
    }

    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }
    
    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }
    
    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }

    public void RemoveAsset(AcmeAssetIdentifier identifier)
    {
        var asset = Assets.FirstOrDefault(a => a.AssetIdentifier == identifier);
        if (asset is null) return;
        Assets.Remove(asset);
    }
    
    public void ClearAssets()
    {
        Assets.Clear();
    }

    /// <summary>
    /// Gets the content items from the tutorial's assets.
    /// </summary>
    /// <returns>>A list of content items.</returns>
    public List<ContentItem> GetContent()
    {
        var content = new List<ContentItem>();
        if (Assets.Count > 0)
            content.AddRange(Assets.Select(asset => 
                new ContentItem(asset.Type.ToString(), asset.GetContent() as string ?? string.Empty )));
        return content;
    }
}