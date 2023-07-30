namespace StoneAssemblies.Hikvision.Tests.Services;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using StoneAssemblies.Hikvision.Extensions;
using StoneAssemblies.Hikvision.Services;
using StoneAssemblies.Hikvision.Services.Interfaces;

using Xunit;

public class FingerPrintClientFacts
{
    public class The_GetEmployeeFingerPrintsAsync_Method
    {
        [Fact]
        [Trait(Traits.Category, TestCategory.Integration)]
        public async Task Gets_EmployeeFingerPrints_Properly_Async()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHikvision();

            var hikvisionDeviceConnectionFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IHikvisionDeviceConnectionFactory>();
            var deviceConnection = hikvisionDeviceConnectionFactory.Create(
                Environment.Device.Url,
                Environment.Device.Username,
                Environment.Device.Password);

            var userInfoClient = deviceConnection.GetClient<IUserInfoClient>();
            var fingerPrintClient = deviceConnection.GetClient<IFingerPrintClient>();

            await foreach (var userInfo in userInfoClient.ListUserAsync())
            {
                var fingerPrints = await fingerPrintClient.GetUserFingerPrintsAsync(userInfo.EmployeeNo).ToListAsync();
            }
        }
    }
}