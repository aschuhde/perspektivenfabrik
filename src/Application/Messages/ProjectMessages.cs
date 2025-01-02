using Common;

namespace Application.Messages;

public static class ProjectMessages
{
    public static Message FieldCannotBeEditedDueToMissingRights(string fieldName) => new($"You do not have the rights to modify the field '{fieldName}'! Please omit this field in the request or set it to null.");
    public static Message FieldCannotBeEdited(string fieldName) => new($"The field '{fieldName}' is not allowed to be set in the request! Please omit this field in the request or set it to null.");
    public static Message FieldIsNull(string fieldName) => new($"The field '{fieldName}' is not set but required by the request! Please set this field in the request.");
    public static Message EntityNotFound(Guid entityId) => new($"The project entity with the id '{entityId}' of the request could not be found.");
}
