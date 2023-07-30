namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface IHikvisionDeviceConnectionFactory
{
    IHikvisionDeviceConnection Create(string url, string username, string password);

    IHikvisionDeviceConnection Create(string name);
}