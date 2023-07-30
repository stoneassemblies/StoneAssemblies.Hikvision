namespace StoneAssemblies.Hikvision.Tests.Services;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Services.Interfaces;
using StoneAssemblies.Hikvision.Tests;

using Xunit;

public class HikvisionDeviceConnectionFacts
{
    public class The_GetClient_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Creates_Clients_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            serviceCollection
                .AddHttpClient("local",
                    httpClient =>
                        {
                            httpClient.BaseAddress = new Uri(Environment.Device.Url);
                        })
                .ConfigurePrimaryHttpMessageHandler(
                    () => new HttpClientHandler
                    {
                        Credentials = new NetworkCredential(
                                      Environment.Device.Username,
                                      Environment.Device.Password)
                    });

            var buildServiceProvider = serviceCollection.BuildServiceProvider();
            var hikvisionDeviceConnectionFactory = buildServiceProvider.GetRequiredService<IHikvisionDeviceConnectionFactory>();

            var hikvisionDeviceConnection = hikvisionDeviceConnectionFactory.Create("local");
            var userInfoClient = hikvisionDeviceConnection.GetClient<IUserInfoClient>();

            userInfoClient.Should().NotBeNull();
        }
    }
}