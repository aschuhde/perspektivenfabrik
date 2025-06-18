using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HistoryEntryType
{
    Created, Deleted, Updated, Special, Unknown, Approval
}
