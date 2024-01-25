namespace StoneAssemblies.Hikvision.Services;

using System;
using System.Net;

using global::StoneAssemblies.Hikvision.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The hikvision device connection factory.
/// </summary>
public class HikvisionDeviceConnectionFactory : IHikvisionDeviceConnectionFactory
{
    /// <summary>
    /// The service provider.
    /// </summary>
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="HikvisionDeviceConnectionFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// The service provider.
    /// </param>
    public HikvisionDeviceConnectionFactory(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        this.serviceProvider = serviceProvider;
    }

    ///// <summary>
    ///// Creates a device connection.
    ///// </summary>
    ///// <param name="url">
    ///// The url.
    ///// </param>
    ///// <param name="username">
    ///// The username.
    ///// </param>
    ///// <param name="password">
    ///// The password.
    ///// </param>
    ///// <returns>
    ///// The <see cref="IHikvisionDeviceConnection"/>.
    ///// </returns>
    public IHikvisionDeviceConnection Create(string url, string username, string password)
    {
        var httpMessageHandler = new HttpClientHandler
        {
            Credentials = new NetworkCredential(username, password)
        };

        var httpClient = new HttpClient(httpMessageHandler)
        {
            BaseAddress = new Uri(url)
        };

        return ActivatorUtilities.CreateInstance<HikvisionDeviceConnection>(this.serviceProvider, httpClient); ;
    }

    /// <summary>
    /// Creates a device connection.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <returns>
    /// The <see cref="IHikvisionDeviceConnection"/>.
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// When service provider is <c>null</c>.
    /// </exception>
    public IHikvisionDeviceConnection Create(string name)
    {
        var httpClientFactory = this.serviceProvider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient(name);

        return ActivatorUtilities.CreateInstance<HikvisionDeviceConnection>(this.serviceProvider, httpClient);
    }
}