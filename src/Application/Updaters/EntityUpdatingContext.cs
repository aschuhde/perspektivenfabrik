using Application.Models.ApiModels;

namespace Application.Updaters;

public class EntityUpdatingContext
{
    public required bool UserCanChangeMetadata { get; init; }
    public required Guid CurrentUserId { get; init; }
    public required bool IsCreating { get; init; }
    public bool HasChanged { get; set; }
    public required List<ApiModificationHistoryItem> Changes { get; init; }
    
    
    public void AddChange(string propertyName, string? newValue, string? oldValue)
    {
        
    }
    public void AddChangeForAddedItemToListProperty(string propertyName, string? addedValue)
    {
        
    }
    public void AddChangeForUpdatedItemInListProperty(string propertyName, string? updatedValue)
    {
        
    }
    public void AddChangeForDeletedItemFromListProperty(string propertyName, string? deletedValue)
    {
        
    }
}
