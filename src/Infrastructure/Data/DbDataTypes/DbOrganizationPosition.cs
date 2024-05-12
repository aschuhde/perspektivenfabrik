using System.ComponentModel.DataAnnotations;
using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbOrganizationPosition
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PositionName { get; init; }
}