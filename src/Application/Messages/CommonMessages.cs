using Common;

namespace Application.Messages;

public class CommonMessages
{
    public static Message InternalServerError() => new ("An internal server error occurred. Please try again later or contact us!");
}
