namespace StoneAssemblies.Hikvision.Services.Interfaces;

using StoneAssemblies.Hikvision.Models;

public interface IUserInfoClient : IHikvisionServiceClient
{
    IAsyncEnumerable<UserInfo> ListUserAsync(int bufferSize = 100);

    Task UpdateUserAsync(UserInfo userInfo);
}