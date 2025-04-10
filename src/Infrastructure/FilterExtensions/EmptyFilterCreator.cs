using Application.Filter;

namespace Infrastructure.FilterExtensions;

public static class EmptyFilterCreator
{
    public static ProjectFilter CreateEmptyProjectFilter()
    {
        return new ProjectFilter();
    }
}