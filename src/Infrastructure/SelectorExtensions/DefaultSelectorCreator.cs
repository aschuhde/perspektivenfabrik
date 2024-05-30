using Application.Selectors;

namespace Infrastructure.SelectorExtensions;

public static class DefaultSelectorCreator
{
    public static ProjectSelector CreateDefaultProjectSelector()
    {
        return new ProjectSelector();
    }
}