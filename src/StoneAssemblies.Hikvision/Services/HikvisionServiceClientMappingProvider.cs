using StoneAssemblies.Hikvision.Services.Interfaces;

namespace StoneAssemblies.Hikvision.Services;

using StoneAssemblies.Hikvision.Extensions;

internal class HikvisionServiceClientMappingProvider : IHikvisionServiceClientMappingProvider
{

    public static readonly Dictionary<Type, Type> DefaultClientTypeMappings = new Dictionary<Type, Type>
                                                                                  {
                                                                                      {typeof(IUserInfoClient), typeof(UserInfoClient)},
                                                                                      {typeof(ISystemClient), typeof(SystemClient)},
                                                                                      {typeof(IAcsEventsClient), typeof(AcsEventsClient)},
                                                                                      {typeof(IFingerPrintClient), typeof(FingerPrintClient)},
                                                                                  };

    private readonly Dictionary<Type, Type> clientTypeMappings;

    public HikvisionServiceClientMappingProvider(Dictionary<Type, Type> clientTypeMappings)
    {
        this.clientTypeMappings = clientTypeMappings;
    }

    public static readonly IHikvisionServiceClientMappingProvider Default =
        new HikvisionServiceClientMappingProvider(DefaultClientTypeMappings);

    public Type GetClientType<THikvisionServiceClient>()
        where THikvisionServiceClient : IHikvisionServiceClient
    {
        return this.clientTypeMappings[typeof(THikvisionServiceClient)];
    }
}