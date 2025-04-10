using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectType
{
    Idea, Inspiration, Project, ProjectRequest, Unkown
}