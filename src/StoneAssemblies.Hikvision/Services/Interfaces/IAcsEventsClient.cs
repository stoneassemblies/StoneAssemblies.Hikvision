using StoneAssemblies.Hikvision.Models;

namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface IAcsEventsClient : IHikvisionServiceClient
{
    IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync(DateTime startTime, DateTime endTime, int accessControlEventType, int eventMinorType);
}