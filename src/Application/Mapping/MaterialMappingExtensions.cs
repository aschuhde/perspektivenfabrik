using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial MaterialDto ToMaterial(this ApiMaterial apiMaterial);
    
    public static partial ApiMaterial ToApiMaterial(this MaterialDto materialDto);
}