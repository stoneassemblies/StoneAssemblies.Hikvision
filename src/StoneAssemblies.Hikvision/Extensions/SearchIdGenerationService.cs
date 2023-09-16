using System.Text;

namespace StoneAssemblies.Hikvision.Extensions;

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
            builder.Append(this.random.Next(10).ToString());
        }

        return builder.ToString();
    }

    public string Next()
    {
        var result = this.CreateRandomString(16);
        while (!this.results.Add(result))
        {
            result = this.CreateRandomString(16);
        }

        return result;
    }

    public void Release(string data)
    {
        this.results.Remove(data);
    }
}