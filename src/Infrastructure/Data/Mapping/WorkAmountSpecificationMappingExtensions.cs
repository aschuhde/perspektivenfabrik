using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial WorkAmountSpecification ToWorkAmountSpecification(this DbWorkAmountSpecification dbWorkAmountSpecification);
    
    public static partial DbWorkAmountSpecification ToDbWorkAmountSpecification(this WorkAmountSpecification workAmountSpecification);
}