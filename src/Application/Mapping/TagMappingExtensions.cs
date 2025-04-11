using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial TagDto ToTag(this ApiTag apiTag);
    
    public static partial ApiTag ToApiTag(this TagDto tagDto);
}