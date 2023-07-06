namespace StoneAssemblies.Hikvision.Services.Interfaces
{
    using StoneAssemblies.Hikvision.Models;

    public interface IHikvisionDeviceClient
    {
        Task<Time> GetTimeAsync();

        Task<DeviceInfo> GetDeviceInfoAsync();

        Task SetTimeAsync(Time time, bool syncTimeZone = true);

        IAsyncEnumerable<UserInfo> ListUserAsync(int bufferSize = 100);

        IAsyncEnumerable<FingerPrint> GetEmployeeFingerPrintsAsync(string employeeNo);
    }
}