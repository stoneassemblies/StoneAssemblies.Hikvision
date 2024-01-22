namespace StoneAssemblies.Hikvision.Services
{
    using StoneAssemblies.Hikvision.Models;
    using StoneAssemblies.Hikvision.Services.Interfaces;

    public class AcsEventsClient : IAcsEventsClient
    {
        private readonly HttpClient httpClient;

        private readonly ISearchIdGenerationService searchIdGenerationService;

        public AcsEventsClient(HttpClient httpClient, ISearchIdGenerationService searchIdGenerationService)
        {
            this.httpClient = httpClient;
            this.searchIdGenerationService = searchIdGenerationService;
        }

        public IAsyncEnumerable<AcsEventInfo> ListEventsAsync(DateTime startTime, DateTime endTime, EventTypes eventType)
        {
            return this.ListAcsEventsAsync(startTime, endTime, AccessControlEventTypes.Event, (int)eventType);
        }

        public async IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync(DateTime startTime, DateTime endTime, AccessControlEventTypes accessControlEventType, int eventMinorType)
        {
            // Fix time.
            startTime = DateTime.SpecifyKind(startTime, DateTimeKind.Unspecified);
            endTime = DateTime.SpecifyKind(endTime, DateTimeKind.Unspecified);

            var startTimeOffset = new DateTimeOffset(startTime, TimeZoneInfo.Local.BaseUtcOffset);
            var endTimeOffset = new DateTimeOffset(endTime, TimeZoneInfo.Local.BaseUtcOffset);

            var request = new AcsEventCond
            {
                SearchID = this.searchIdGenerationService.Next(),
                StartTime = startTimeOffset.ToString(TimeFormats.TimeFormat),
                EndTime = endTimeOffset.ToString(TimeFormats.TimeFormat),
                Major = (int)accessControlEventType,
                Minor = eventMinorType,
                SearchResultPosition = 0,
                MaxResults = 10,
            };

            try
            {
                var acsEvent = await httpClient.PostAsync<AcsEventCond, AcsEvent>(EndPoints.Json.AcsEvent, request);
                while (acsEvent?.InfoList is not null)
                {
                    foreach (var eventInfo in acsEvent.InfoList)
                    {
                        yield return eventInfo;
                    }

                    request.SearchResultPosition += acsEvent.InfoList.Count;
                    acsEvent = await httpClient.PostAsync<AcsEventCond, AcsEvent>(EndPoints.Json.AcsEvent, request);
                }
            }
            finally
            {
                this.searchIdGenerationService.Release(request.SearchID);
            }
        }
    }
}