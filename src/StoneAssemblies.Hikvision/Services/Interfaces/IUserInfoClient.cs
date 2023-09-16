namespace StoneAssemblies.Hikvision.Services.Interfaces;

using StoneAssemblies.Hikvision.Models;

public interface IUserInfoClient : IHikvisionServiceClient
{
    Task AddUserAsync(UserInfo userInfo);

    IAsyncEnumerable<UserInfo> ListUserAsync(params string[] employeeNumbers);

    Task UpdateUserAsync(UserInfo userInfo);
}