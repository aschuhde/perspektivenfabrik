using Application.Models;
using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ModificationHistoryDto ToHistory(this ApiModificationHistory apiHistory);
    
    public static partial ApiModificationHistory ToApiHistory(this ModificationHistoryDto historyDto);
    
}