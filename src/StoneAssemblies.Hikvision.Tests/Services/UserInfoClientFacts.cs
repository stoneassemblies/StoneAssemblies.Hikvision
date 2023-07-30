namespace StoneAssemblies.Hikvision.Tests.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Models;
using StoneAssemblies.Hikvision.Services;
using StoneAssemblies.Hikvision.Services.Interfaces;

using Xunit;

public class UserInfoClientFacts
{
    public class The_ListUserAsync_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Lists_Users_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var userInfos = await deviceConnection.GetClient<IUserInfoClient>().ListUserAsync().ToListAsync();
            Assert.NotEmpty(userInfos);
        }
    }


    public class The_UpdateUserAsync_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Updates_Users_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var userInfoClient = deviceConnection.GetClient<IUserInfoClient>();
            await foreach (var userInfo in userInfoClient.ListUserAsync())
            {
                userInfo.PersonInfoExtends = new List<PersonInfoExtend>()
                                                 {
                                                     new PersonInfoExtend
                                                         {
                                                             Name = "data",
                                                             Value = "1"
                                                         }
                                                 };

                await userInfoClient.UpdateUserAsync(userInfo);
            }
        }
    }

}