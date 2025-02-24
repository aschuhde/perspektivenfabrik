using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionTypes")]
public sealed class DbDescriptionType : DbEntityWithId
{
    public required string Name { get; init; }
    public required DbFormattedTitle DescriptionTitle { get; init; } 
}