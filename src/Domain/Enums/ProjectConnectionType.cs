using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectConnectionType
{
    Related, SubProject, ParentProject, PredecessorProject, SuccessorProject
}