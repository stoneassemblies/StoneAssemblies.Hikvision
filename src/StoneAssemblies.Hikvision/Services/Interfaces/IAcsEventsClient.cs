using StoneAssemblies.Hikvision.Models;

namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface IAcsEventsClient : IHikvisionServiceClient
{
    IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync(DateTime startTime, DateTime endTime, AccessControlEventTypes accessControlEventType, int eventMinorType);
    
    IAsyncEnumerable<AcsEventInfo> ListEventsAsync(DateTime startTime, DateTime endTime, EventTypes eventType);
}