using Application.Common;
using Application.Models.ApiModels;

namespace Application.GetJsonTypeDiscriminatorNames.GetJsonTypeDiscriminatorNames;

public class GetJsonTypeDiscriminatorNamesHandler(IServiceProvider serviceProvider) : BaseHandler<GetJsonTypeDiscriminatorNamesRequest, GetJsonTypeDiscriminatorNamesResponse>(serviceProvider)
{
    public override Task<GetJsonTypeDiscriminatorNamesResponse> ExecuteAsync(GetJsonTypeDiscriminatorNamesRequest command, CancellationToken ct)
    {
        return Task.FromResult(new GetJsonTypeDiscriminatorNamesResponse()
        {
            ApiTimeSpecificationTypes = Enum.GetValues<ApiTimeSpecificationTypes>().ToArray(),
            ApiLocationSpecificationTypes = Enum.GetValues<ApiLocationSpecificationTypes>().ToArray(),
            ApiRequirementSpecificationTypes = Enum.GetValues<ApiRequirementSpecificationTypes>().ToArray(),
            ApiContactSpecificationTypes = Enum.GetValues<ApiContactSpecificationTypes>().ToArray()
        });
    }
}
