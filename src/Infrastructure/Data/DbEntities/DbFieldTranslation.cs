using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("FieldTranslations")]
[Index(nameof(GroupEntityId))]
public sealed class DbFieldTranslation : DbEntityWithId
{
    public required Guid GroupEntityId { get; set; }
    public required Guid CorrelatedEntityId { get; set; }
    
    [MaxLength(Constants.StringLengths.Small)]
    public required string LanguageCode { get; set; }
    
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PropertyPath { get; set; }
    
    [MaxLength(Constants.StringLengths.Largest)]
    public required string Content { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
        if(target is not DbFieldTranslation fieldTranslation) return;
        if (this.CorrelatedEntityId != fieldTranslation.CorrelatedEntityId)
        {
            this.CorrelatedEntityId = fieldTranslation.CorrelatedEntityId;
        }
        if (this.LanguageCode != fieldTranslation.LanguageCode) 
        {
            this.LanguageCode = fieldTranslation.LanguageCode;
        }
        if (this.PropertyPath != fieldTranslation.PropertyPath)
        {
            this.PropertyPath = fieldTranslation.PropertyPath; 
        }
        if (this.Content != fieldTranslation.Content)
        {
            this.Content = fieldTranslation.Content;
        }
    }
}