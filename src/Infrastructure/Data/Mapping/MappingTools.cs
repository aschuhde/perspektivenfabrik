namespace Infrastructure.Data.Mapping;

public static class MappingTools
{
    public static List<T> MapArrayToList<T, T2>(T2[] source, Func<T2, T> map)
    {
        var result = new List<T>(source.Length);
        for (var i = 0; i < source.Length; i++)
        {
            result.Add(map(source[i]));
        }
        return result;
    }
}