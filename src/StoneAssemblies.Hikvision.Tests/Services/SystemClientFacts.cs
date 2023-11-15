namespace StoneAssemblies.Hikvision.Tests.Services;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using Moq;
using Moq.Protected;

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

        [Fact]
        [Trait(Traits.Category, TestCategory.Unit)]
        public async Task Deserializes_Time_Properly_Async()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<Time version=""2.0"" xmlns=""http://www.isapi.org/ver20/XMLSchema"">
    <timeMode>manual</timeMode>
    <localTime>2023-11-15T00:45:49-05:00</localTime>
    <timeZone>CST+5:00:00</timeZone>
</Time>")
            };

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                    httpResponseMessage);

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };
            var systemClient = new SystemClient(httpClient);

            var info = await systemClient.GetTimeAsync();
            info.Should().NotBeNull();
            info.LocalTime.Should().Be(DateTimeOffset.Parse("2023-11-15T00:45:49-05:00").LocalDateTime);
            info.TimeMode.Should().Be("manual");
            info.TimeZone.Should().Be("CST+5:00:00");
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

        public static IEnumerable<object[]> DeviceInfo_Data()
        {
            yield return new object[]
                             {
                                 @"<?xml version=""1.0"" encoding=""UTF-8""?>
<DeviceInfo xmlns=""http://www.isapi.org/ver20/XMLSchema"" version=""2.0"">
    <deviceName>Access Controller</deviceName>
    <deviceID>255</deviceID>
    <model>DS-K1T341AMF</model>
    <serialNumber>DS-K1T341AMF20220311V030230ENJ70368704</serialNumber>
    <macAddress>AC:B9:2F:E5:1B:88</macAddress>
    <firmwareVersion>V3.2.30</firmwareVersion>
    <firmwareReleasedDate>build 220311</firmwareReleasedDate>
    <encoderVersion>V1.0</encoderVersion>
    <encoderReleasedDate>build 191119</encoderReleasedDate>
    <deviceType>ACS</deviceType>
    <telecontrolID>1</telecontrolID>
    <supportBeep>false</supportBeep>
    <localZoneNum>0</localZoneNum>
    <alarmOutNum>0</alarmOutNum>
    <electroLockNum>1</electroLockNum>
    <RS485Num>1</RS485Num>
    <manufacturer>hikvision</manufacturer>
    <OEMCode>1</OEMCode>
    <marketType>2</marketType>
</DeviceInfo>"
                             };

            yield return new object[]
                             {
                                 @"<?xml version=""1.0"" encoding=""UTF-8""?>
<DeviceInfo version=""2.0"" xmlns=""http://www.isapi.org/ver20/XMLSchema"">
    <deviceName>T&amp;A Access Controller</deviceName>
    <deviceID>255</deviceID>
    <model>DS-K1T804AEF</model>
    <serialNumber>K29703787</serialNumber>
    <macAddress>BC:9B:5E:11:DE:98</macAddress>
    <firmwareVersion>V1.4.0</firmwareVersion>
    <firmwareReleasedDate>build 220523</firmwareReleasedDate>
    <deviceType>ACS</deviceType>
    <supportBeep>true</supportBeep>
    <alarmOutNum>1</alarmOutNum>
    <relayNum>1</relayNum>
    <electroLockNum>1</electroLockNum>
    <RS485Num>1</RS485Num>
    <customizedInfo></customizedInfo>
</DeviceInfo>"
                             };
        }

        [Theory]
        [MemberData(nameof(DeviceInfo_Data))]
        [Trait(Traits.Category, TestCategory.Unit)]
        public async Task Supports_DeviceInfo_Deserialization_With_Optional_Xml_Nodes_Async(string content)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                    httpResponseMessage);

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };
            var systemClient = new SystemClient(httpClient);

            var info = await systemClient.GetDeviceInfoAsync();
            info.Should().NotBeNull();
        }
    }
}