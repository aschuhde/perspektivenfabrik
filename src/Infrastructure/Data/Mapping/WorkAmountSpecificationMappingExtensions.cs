﻿using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial WorkAmountSpecificationDto ToWorkAmountSpecification(this DbWorkAmountSpecification dbWorkAmountSpecification);
    
    public static partial DbWorkAmountSpecification ToDbWorkAmountSpecification(this WorkAmountSpecificationDto workAmountSpecificationDto);
}