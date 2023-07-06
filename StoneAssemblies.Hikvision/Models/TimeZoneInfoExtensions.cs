namespace StoneAssemblies.Hikvision.Models;

public static class TimeZoneInfoExtensions
{
    public static string ToCST(this TimeZoneInfo timeZoneInfo)
    {
        var baseUtcOffset = timeZoneInfo.BaseUtcOffset * -1;
        return $"CST{(baseUtcOffset.Hours > 0 ? "+" : "-")}{baseUtcOffset}";
    }
}