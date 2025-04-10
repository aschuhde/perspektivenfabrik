using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectPhase
{
    Idea, Request, Planning, Ongoing, Finished, Cancelled, Unkown
}