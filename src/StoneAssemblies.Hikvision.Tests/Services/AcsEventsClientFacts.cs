namespace StoneAssemblies.Hikvision.Tests.Services;

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Services;
using StoneAssemblies.Hikvision.Services.Extensions;
using StoneAssemblies.Hikvision.Services.Interfaces;

using Xunit;

public class AcsEventsClientFacts
{
    public class The_ListAcsEventsAsync_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Lists_Acs_Events_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHikvision();
            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();

            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var acsEventsClient = deviceConnection.GetClient<IAcsEventsClient>();

            var startTime = new DateTime(2023, 7, 30, 18, 50, 0);
            var endTime = DateTime.Now;

            var acsEvents = await acsEventsClient.ListAcsEventsAsync(startTime, endTime, AccessControlEventTypes.Event, EventTypes.FingerprintComparePass, EventTypes.FaceVerifyPass).ToListAsync();
            Assert.NotEmpty(acsEvents);
        }
    }
}