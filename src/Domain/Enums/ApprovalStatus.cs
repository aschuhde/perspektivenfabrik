using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApprovalStatus
{
    Pending, AutoApproved, Approved, Rejected, Unknown
}