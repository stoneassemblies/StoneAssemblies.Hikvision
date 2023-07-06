namespace StoneAssemblies.Hikvision.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using StoneAssemblies.Hikvision.Models;
    using StoneAssemblies.Hikvision.Services;

    using Xunit;

    public class HikvisionDeviceFacts
    {
        public class The_GetTime_Method
        {
            [Fact]
            public async Task Gets_Time_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);

                var time = await hikvisionDevice.GetTimeAsync();

                Assert.NotNull(time);
            }
        }

        public class The_SetTime_Method
        {
            [Fact]
            public async Task Sets_Time_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);

                var time = new Time
                {
                    LocalTime = DateTime.Now,
                    TimeZone = TimeZoneInfo.Local.ToCST()
                };

                await hikvisionDevice.SetTimeAsync(time);
            }
        }

        public class The_GetDeviceInfo_Method
        {
            [Fact]
            public async Task Gets_DeviceInfo_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);
                var deviceInfo = await hikvisionDevice.GetDeviceInfoAsync();

                Assert.NotNull(deviceInfo);
            }
        }

        public class The_ListUserAsync_Method
        {
            [Fact]
            public async Task Lists_Users_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);
                var userInfos = await hikvisionDevice.ListUserAsync().ToListAsync();
                Assert.NotEmpty(userInfos);
            }
        }

        public class The_GetEmployeeFingerPrintsAsync_Method
        {
            [Fact]
            public async Task Gets_EmployeeFingerPrints_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);
                await foreach (var userInfo in hikvisionDevice.ListUserAsync())
                {
                    var fingerPrints = await hikvisionDevice.GetEmployeeFingerPrintsAsync(userInfo.EmployeeNo).ToListAsync();
                }
            }
        }

        public class The_UpdateUserAsync_Method
        {
            [Fact]
            public async Task Updates_Users_Properly_Async()
            {
                var httpMessageHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(Environment.Device.Username, Environment.Device.Password)
                };
                var httpClient = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Environment.Device.Url)
                };

                var hikvisionDevice = new HikvisionDeviceClient(httpClient);
                await foreach (var userInfo in hikvisionDevice.ListUserAsync())
                {
                    userInfo.PersonInfoExtends = new List<PersonInfoExtend>()
                                                     {
                                                         new PersonInfoExtend() 

                                                             {
                                                                 Name = "data",
                                                                 Value = "1"
                                                             }
                                                     };

                    await hikvisionDevice.UpdateUserAsync(userInfo);
                }
            }
        }

    }
}
