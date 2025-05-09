using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial FieldTranslationDto ToFieldTranslation(this DbFieldTranslation dbFieldTranslation);
    
    public static partial DbFieldTranslation ToDbFieldTranslation(this FieldTranslationDto fieldTranslationDto);
}