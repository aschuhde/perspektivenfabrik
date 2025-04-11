using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial DescriptionImageDto ToDescriptionImage(this ApiDescriptionImage apiDescriptionImage);
    
    public static partial ApiDescriptionImage ToApiDescriptionImage(this DescriptionImageDto descriptionImageDto);
}