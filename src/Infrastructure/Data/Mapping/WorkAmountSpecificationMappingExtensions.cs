using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class WorkAmountSpecificationMappingExtensions
{
    public static partial WorkAmountSpecification ToWorkAmountSpecification(this DbWorkAmountSpecification dbWorkAmountSpecification);
    
    public static partial DbWorkAmountSpecification ToDbWorkAmountSpecification(this WorkAmountSpecification workAmountSpecification);
}