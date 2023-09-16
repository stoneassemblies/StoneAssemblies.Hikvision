namespace StoneAssemblies.Hikvision.Services
{
    using System.Net.Http;

    using Microsoft.Extensions.DependencyInjection;

    using StoneAssemblies.Hikvision.Services.Interfaces;

    /// <summary>
    /// The hikvision device connection.
    /// </summary>
    public class HikvisionDeviceConnection : IHikvisionDeviceConnection
    {
        /// <summary>
        /// The http client.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// The hikvision client mapping provider.
        /// </summary>
        private readonly IHikvisionServiceClientMappingProvider hikvisionServiceClientMappingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HikvisionDeviceConnection"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service provider.
        /// </param>
        /// <param name="httpClient">
        ///     The http client.
        /// </param>
        /// <param name="hikvisionServiceClientMappingProvider">
        ///     The hikvision service client mapping provider.
        /// </param>
        public HikvisionDeviceConnection(
            IServiceProvider serviceProvider, HttpClient httpClient,
            IHikvisionServiceClientMappingProvider hikvisionServiceClientMappingProvider)
        {
            this.httpClient = httpClient;
            this.serviceProvider = serviceProvider;
            this.hikvisionServiceClientMappingProvider = hikvisionServiceClientMappingProvider;
        }

        /// <summary>
        /// Gets a Hikvision Service Client.
        /// </summary>
        /// <typeparam name="THikvisionServiceClient">
        /// The Hikvision service client type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="THikvisionServiceClient"/>.
        /// </returns>
        public THikvisionServiceClient GetClient<THikvisionServiceClient>()
            where THikvisionServiceClient : IHikvisionServiceClient
        {
            if (this.serviceProvider is not null)
            {
                return (THikvisionServiceClient)ActivatorUtilities.CreateInstance(
                    this.serviceProvider,
                    this.hikvisionServiceClientMappingProvider.GetClientType<THikvisionServiceClient>(),
                    this.httpClient);
            }

            return (THikvisionServiceClient)Activator.CreateInstance(this.hikvisionServiceClientMappingProvider.GetClientType<THikvisionServiceClient>(), this.httpClient)!;
        }
    }
}


