namespace StoneAssemblies.Hikvision.Services.Interfaces;

using StoneAssemblies.Hikvision.Models;

public interface ISystemClient : IHikvisionServiceClient
{
    Task<Time> GetTimeAsync();

    Task SetTimeAsync(Time time, bool syncTimeZone = true);

    Task<DeviceInfo> GetDeviceInfoAsync();
}