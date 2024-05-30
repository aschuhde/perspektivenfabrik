using Application.Models;
using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ProjectTagDto ToProjectTag(this ApiProjectTag apiProjectTag);
    public static partial ApiProjectTag ToApiProjectTag(this ProjectTagDto projectTagDto);
}