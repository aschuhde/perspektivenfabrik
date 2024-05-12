using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    public static partial User ToUser(this DbUser dbUser);
    public static partial DbUser ToDbUser(this User user);
    
    internal static partial Person ToPersonInner(this DbPerson dbPerson);
    internal static partial DbPerson ToDbPersonInner(this Person person);

    [UserMapping(Default = true)]
    public static DbPerson ToDbPerson(this Person person) =>
        person switch
        {
            User u => u.ToDbUser(),
            _ => person.ToDbPersonInner()
        };

    [UserMapping(Default = true)]
    public static Person ToPerson(this DbPerson dbPerson) =>
        dbPerson switch
        {
            DbUser u => u.ToUser(),
            _ => dbPerson.ToPersonInner()
        };

    internal static DbEntityPersonCreatedByConnection ToDbEntityPersonCreatedByConnection(this Person p) => new DbEntityPersonCreatedByConnection()
    {
        PersonId = p.EntityId
    };
    internal static Person ToPerson(this DbEntityPersonCreatedByConnection p) => p.Person!.ToPerson();
    
    internal static DbEntityPersonLastModifiedByConnection ToDbEntityPersonLastModifiedByConnection(this Person p) => new DbEntityPersonLastModifiedByConnection()
    {
        PersonId = p.EntityId
    };
    internal static Person ToPerson(this DbEntityPersonLastModifiedByConnection p) => p.Person!.ToPerson();
}