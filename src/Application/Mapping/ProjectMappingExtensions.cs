using Application.Models;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ApiProject ToApiProject(this ProjectDto projectDto);
    
    public static partial ProjectDto ToProject(this ApiProject apiProject);
}