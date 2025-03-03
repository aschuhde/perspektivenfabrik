﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("QuantitySpecifications")]
public sealed class DbQuantitySpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Value { get; init; }
}

[Table("QuantitySpecificationRequirementConnections")]
public sealed class DbQuantitySpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(QuantitySpecification))]
    public required Guid QuantitySpecificationId { get; init; }
    public DbQuantitySpecification? QuantitySpecification { get; init; }

    public DbQuantitySpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbQuantitySpecificationRequirementConnection()
      {
        EntityId = this.EntityId,
        QuantitySpecificationId = this.QuantitySpecificationId,
        RequirementSpecificationId = this.RequirementSpecificationId
      };
    }
}
