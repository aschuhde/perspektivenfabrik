using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial ModificationHistory ToHistory(this DbModificationHistory dbHistory);
    public static partial DbModificationHistory ToDbHistory(this ModificationHistory history);
}