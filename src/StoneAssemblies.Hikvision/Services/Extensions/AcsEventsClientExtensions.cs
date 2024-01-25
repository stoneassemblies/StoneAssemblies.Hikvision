namespace StoneAssemblies.Hikvision.Services.Extensions
{
    using StoneAssemblies.Hikvision.Models;
    using StoneAssemblies.Hikvision.Services;
    using StoneAssemblies.Hikvision.Services.Interfaces;

    /// <summary>
    /// The AcsEventsClientExtensions.
    /// </summary>
    public static class AcsEventsClientExtensions
    {
        /// <summary>
        /// Lists acs events async.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        /// <param name="endTime">
        /// The end time.
        /// </param>
        /// <param name="accessControlEventType">
        /// The access control event type.
        /// </param>
        /// <param name="minorEventTypes">
        /// The minor event types.
        /// </param>
        /// <typeparam name="TMinorEventType">
        /// The minor event type.
        /// </typeparam>
        /// <returns>
        /// The async enumeration of <see cref="AcsEventInfo"/>.
        /// </returns>
        public static async IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync<TMinorEventType>(
            this IAcsEventsClient client,
            DateTime startTime,
            DateTime endTime,
            AccessControlEventTypes accessControlEventType,
            params TMinorEventType[] minorEventTypes)
            where TMinorEventType : Enum
        {
            foreach (var minorEventType in minorEventTypes)
            {
                await foreach (var acsEventInfo in client.ListAcsEventsAsync(startTime, endTime, accessControlEventType, minorEventType))
                {
                    yield return acsEventInfo;
                }
            }
        }

        /// <summary>
        /// Lists acs events async.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        /// <param name="endTime">
        /// The end time.
        /// </param>
        /// <param name="accessControlEventType">
        /// The access control event type.
        /// </param>
        /// <param name="minorEventTypes">
        /// The minor event types.
        /// </param>
        /// <typeparam name="TMinorEventType">
        /// The minor event type.
        /// </typeparam>
        /// <returns>
        /// The async enumeration of <see cref="AcsEventInfo"/>.
        /// </returns>
        public static async IAsyncEnumerable<AcsEventInfo> ListAcsEventsAsync<TMinorEventType>(
            this IAcsEventsClient client,
            DateTime startTime,
            DateTime endTime,
            AccessControlEventTypes accessControlEventType,
            IEnumerable<TMinorEventType> minorEventTypes)
            where TMinorEventType : Enum
        {
            await foreach (var acsEventInfo in client.ListAcsEventsAsync(startTime, endTime, accessControlEventType, minorEventTypes.ToArray()))
            {
                yield return acsEventInfo;
            }
        }
    }
}