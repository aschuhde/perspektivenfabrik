namespace Infrastructure.Data.Mapping;

public static class MappingTools
{
    public static T[] MapArray<T, T2>(T2[] source, Func<T2, T> map)
    {
        var result = new T[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = map(source[i]);
        }
        return result;
    }
}