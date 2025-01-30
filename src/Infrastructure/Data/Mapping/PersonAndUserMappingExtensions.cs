using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    public static partial UserDto ToUser(this DbUser dbUser);
    public static partial DbUser ToDbUser(this UserDto userDto);
    
    internal static partial PersonDto ToPersonInner(this DbPerson dbPerson);
    internal static partial DbPerson ToDbPersonInner(this PersonDto personDto);

    [UserMapping(Default = true)]
    public static DbPerson ToDbPerson(this PersonDto personDto) =>
        personDto switch
        {
            UserDto u => u.ToDbUser(),
            _ => personDto.ToDbPersonInner()
        };

    [UserMapping(Default = true)]
    public static PersonDto ToPerson(this DbPerson dbPerson) =>
        dbPerson switch
        {
            DbUser u => u.ToUser(),
            _ => dbPerson.ToPersonInner()
        };

    internal static DbEntityPersonCreatedByConnection ToDbEntityPersonCreatedByConnection(this PersonDto p) => new DbEntityPersonCreatedByConnection()
    {
        PersonId = p.EntityId
    };
    internal static PersonDto ToPerson(this DbEntityPersonCreatedByConnection p) => p.Person?.ToPerson() ?? null!;
    
    internal static DbEntityPersonLastModifiedByConnection ToDbEntityPersonLastModifiedByConnection(this PersonDto p) => new DbEntityPersonLastModifiedByConnection()
    {
        PersonId = p.EntityId
    };
    internal static PersonDto ToPerson(this DbEntityPersonLastModifiedByConnection p) => p.Person?.ToPerson() ?? null!;
}