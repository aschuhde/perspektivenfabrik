using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetJsonTypeDiscriminatorNames.GetJsonTypeDiscriminatorNames;

public class GetJsonTypeDiscriminatorNamesResponse : JsonResponse
{
    public required ApiTimeSpecificationTypes[] ApiTimeSpecificationTypes { get; set; }
    public required ApiLocationSpecificationTypes[] ApiLocationSpecificationTypes { get; set; }
    public required ApiRequirementSpecificationTypes[] ApiRequirementSpecificationTypes { get; set; }
    public required ApiContactSpecificationTypes[] ApiContactSpecificationTypes { get; set; }
}

