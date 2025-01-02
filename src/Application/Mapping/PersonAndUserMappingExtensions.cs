using Application.Models.ApiModels;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

public static partial class ApiMappingExtensions
{
    public static partial UserDto ToUser(this ApiUser apiUser);
    public static partial ApiUser ToApiUser(this UserDto userDto);
    
    internal static partial PersonDto ToPersonInner(this ApiPerson apiPerson);
    internal static partial ApiPerson ToApiPersonInner(this PersonDto personDto);

    [UserMapping(Default = true)]
    public static ApiPerson ToApiPerson(this PersonDto personDto) =>
        personDto switch
        {
            UserDto u => u.ToApiUser(),
            _ => personDto.ToApiPersonInner()
        };

    [UserMapping(Default = true)]
    public static PersonDto ToPerson(this ApiPerson apiPerson) =>
        apiPerson switch
        {
            ApiUser u => u.ToUser(),
            _ => apiPerson.ToPersonInner()
        };

    public static PersonDto ToPerson(this ApiPersonReference personReference)
    {
        return new PersonDto()
        {
            EntityId = personReference.PersonEntityId,
            Email = "",
            Firstname = "",
            Lastname = ""
        };
    }
}