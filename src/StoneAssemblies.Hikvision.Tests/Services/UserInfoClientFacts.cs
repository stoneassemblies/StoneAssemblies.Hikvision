namespace StoneAssemblies.Hikvision.Tests.Services;

using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
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

            var regex = new Regex("([^,]+),\"([^\"]+)");

            var template = await userInfoClient.ListUserAsync().FirstAsync();
            var strings = await File.ReadAllLinesAsync("c:\\Tmp\\employees.csv");
            foreach (var s in strings)
            {
                var match = regex.Match(s);
                var id = match.Groups[1].Value;
                var name = match.Groups[2].Value;
                template.EmployeeNo = id;
                template.Name = name;

                await userInfoClient.AddUserAsync(template);
            }

        }
    }

}