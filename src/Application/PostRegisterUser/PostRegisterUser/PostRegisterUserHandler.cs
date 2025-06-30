using Application.Common;

namespace Application.PostRegisterUser.PostRegisterUser;

public sealed class PostRegisterUserHandler(IServiceProvider serviceProvider) : BaseHandler<PostRegisterUserRequest, PostRegisterUserResponse>(serviceProvider)
{
    public override Task<PostRegisterUserResponse> ExecuteAsync(PostRegisterUserRequest command, CancellationToken ct)
    {
        return Task.FromResult(new PostRegisterUserResponse() { });
    }
}
