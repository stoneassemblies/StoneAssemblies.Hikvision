using StoneAssemblies.Hikvision.Models;

namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface IAcsEventsClient : IHikvisionServiceClient
{
    IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync<TMinorType>(
        DateTime startTime, DateTime endTime, AccessControlEventTypes accessControlEventType, TMinorType minorEventType)
        where TMinorType : Enum;
}