namespace StoneAssemblies.Hikvision.Tests.Services;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Models;
using StoneAssemblies.Hikvision.Services;
using StoneAssemblies.Hikvision.Services.Interfaces;

using Xunit;

public class SystemClientFacts
{
    public class The_GetTime_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Gets_Time_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            serviceCollection.AddHttpClient(
                    "local",
                    httpClient =>
                        {
                            httpClient.BaseAddress = new Uri(Environment.Device.Url);
                        })
                .ConfigurePrimaryHttpMessageHandler(
                    () => new HttpClientHandler
                    {
                        Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                    });

            var buildServiceProvider = serviceCollection.BuildServiceProvider();
            var hikvisionDeviceClientFactory = buildServiceProvider.GetRequiredService<IHikvisionDeviceConnectionFactory>();

            var deviceConnection = hikvisionDeviceClientFactory.Create("local");
            var time = await deviceConnection.GetClient<ISystemClient>().GetTimeAsync();

            Assert.NotNull(time);
        }
    }

    public class The_SetTime_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Sets_Time_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var time = new Time
            {
                LocalTime = DateTime.Now,
                TimeZone = TimeZoneInfo.Local.ToCST(),
            };

            await deviceConnection.GetClient<ISystemClient>().SetTimeAsync(time);
        }
    }

    public class The_GetDeviceInfo_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Gets_DeviceInfo_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var deviceInfo = await deviceConnection.GetClient<ISystemClient>().GetDeviceInfoAsync();

            Assert.NotNull(deviceInfo);
        }
    }
}