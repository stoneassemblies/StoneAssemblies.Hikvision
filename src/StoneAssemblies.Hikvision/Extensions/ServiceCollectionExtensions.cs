namespace StoneAssemblies.Hikvision.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using StoneAssemblies.Hikvision.Services.Interfaces;
    using StoneAssemblies.Hikvision.Services;

    public static class ServiceCollectionExtensions
    {
        public static void AddHikvision(this IServiceCollection serviceCollection, Action<IServiceCollection>? serviceCustomization = null)
        {
            serviceCollection.AddScoped<ISearchIdGenerationService, SearchIdGenerationService>();
            serviceCollection.AddScoped<IHikvisionDeviceConnectionFactory, HikvisionDeviceConnectionFactory>();
            serviceCollection.AddScoped<IHikvisionDeviceConnection, HikvisionDeviceConnection>();

            var hikvisionServiceCollection = new ServiceCollection();
            if (serviceCustomization is not null)
            {
                serviceCustomization(hikvisionServiceCollection);
            }

            Dictionary<Type, Type> clientTypeMappings = new Dictionary<Type, Type>();
            var registeredService = new HashSet<Type>();
            foreach (ServiceDescriptor serviceDescriptor in hikvisionServiceCollection)
            {
                if (!HikvisionServiceClientMappingProvider.DefaultClientTypeMappings.ContainsKey(serviceDescriptor.ServiceType))
                {
                    throw new NotSupportedException("Not supported service");
                }

                if (serviceDescriptor.ImplementationType is null)
                {
                    throw new NotSupportedException("Not supported this type of registration.");
                }

                serviceCollection.Add(serviceDescriptor);
                registeredService.Add(serviceDescriptor.ServiceType);

                clientTypeMappings[serviceDescriptor.ServiceType] = serviceDescriptor.ImplementationType;
            }

            foreach (var clientTypeMapping in HikvisionServiceClientMappingProvider.DefaultClientTypeMappings)
            {
                if (!registeredService.Contains(clientTypeMapping.Key))
                {
                    serviceCollection.AddScoped(clientTypeMapping.Key, clientTypeMapping.Value);
                    clientTypeMappings[clientTypeMapping.Key] = clientTypeMapping.Value;
                }
            }

            serviceCollection.AddScoped<IHikvisionServiceClientMappingProvider>(_ => new HikvisionServiceClientMappingProvider(clientTypeMappings));
        }
    }
}
