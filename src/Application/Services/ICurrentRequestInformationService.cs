namespace Application.Services;

public interface ICurrentRequestInformationService
{
    public Uri? RequestUri { get; }
    public string? Method { get; }
}
