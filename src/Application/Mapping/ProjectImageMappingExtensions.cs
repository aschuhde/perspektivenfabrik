using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ProjectImageDto ToProjectImage(this ApiProjectImage apiProjectImage);
    
    public static partial ApiProjectImage ToApiProjectImage(this ProjectImageDto projectImageDto);
}