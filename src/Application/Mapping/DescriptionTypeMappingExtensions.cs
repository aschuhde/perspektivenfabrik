using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial DescriptionTypeDto ToDescriptionType(this ApiDescriptionType apiDescriptionType);
    public static partial ApiDescriptionType ToApiDescriptionType(this DescriptionTypeDto descriptionTypeDto);
}