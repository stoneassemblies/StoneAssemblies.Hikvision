using System.Text;

namespace StoneAssemblies.Hikvision.Services;

using StoneAssemblies.Hikvision.Collections;
using StoneAssemblies.Hikvision.Services.Interfaces;

public class SearchIdGenerationService : ISearchIdGenerationService
{
    private readonly ConcurrentHashSet<string> results = new ConcurrentHashSet<string>();

    private readonly Random random = new Random();

    private string CreateRandomString(int digits)
    {
        var builder = new StringBuilder();
        while (builder.Length < digits)
        {
            builder.Append(random.Next(10).ToString());
        }

        return builder.ToString();
    }

    public string Next()
    {
        var result = CreateRandomString(16);
        while (!results.Add(result))
        {
            result = CreateRandomString(16);
        }

        return result;
    }

    public void Release(string data)
    {
        results.Remove(data);
    }
}