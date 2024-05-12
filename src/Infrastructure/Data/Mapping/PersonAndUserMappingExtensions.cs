using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper(UseReferenceHandling = true)]
public static partial class PersonAndUserMappingExtensions
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
            _ => person.ToDbPerson()
        };

    [UserMapping(Default = true)]
    public static Person ToPerson(this DbPerson dbPerson) =>
        dbPerson switch
        {
            DbUser u => u.ToUser(),
            _ => dbPerson.ToPersonInner()
        };
}