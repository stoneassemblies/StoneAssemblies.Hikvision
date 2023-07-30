namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface IHikvisionServiceClientMappingProvider
{
    Type GetClientType<THikvisionServiceClient>() where THikvisionServiceClient : IHikvisionServiceClient;
}