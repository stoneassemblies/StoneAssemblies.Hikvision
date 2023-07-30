namespace StoneAssemblies.Hikvision.Tests.Services;

using System;
using System.Net;
using System.Net.Http;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Services;
using StoneAssemblies.Hikvision.Services.Interfaces;

using Xunit;

public class HikvisionDeviceConnectionFactoryFacts
{
    public class The_Create_Method_Named_Overload
    {

        [Fact]
        [Trait(Traits.Category, TestCategory.Unit)]
        public void Activation_Succeeds()
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
                        Credentials = new NetworkCredential(
                                      Environment.Device.Username,
                                      Environment.Device.Password)
                    });

            var buildServiceProvider = serviceCollection.BuildServiceProvider();
            var deviceConnectionFactory = buildServiceProvider.GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var hikvisionDeviceConnection = deviceConnectionFactory.Create("local");

            hikvisionDeviceConnection.Should().NotBeNull();
        }
    }
}