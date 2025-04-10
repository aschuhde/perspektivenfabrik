namespace Common;

public static class Base64Extensions
{
    public static string ToBase64(this byte[] content)
    {
        return Convert.ToBase64String(content);
    }
    public static byte[] FromBase64(this string content)
    {
        return Convert.FromBase64String(content);
    }
}
