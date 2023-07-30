namespace StoneAssemblies.Hikvision.Services.Interfaces
{
    /// <summary>
    /// The HikvisionDeviceConnection interface.
    /// </summary>
    public interface IHikvisionDeviceConnection
    {
        /// <summary>
        /// The get client.
        /// </summary>
        /// <typeparam name="THikvisionServiceClient">
        /// The hikvision service client type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="THikvisionServiceClient"/>.
        /// An instance of hikvision service client.
        /// </returns>
        THikvisionServiceClient GetClient<THikvisionServiceClient>() where THikvisionServiceClient : IHikvisionServiceClient;
    }
}