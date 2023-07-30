namespace StoneAssemblies.Hikvision.Services.Interfaces;

using StoneAssemblies.Hikvision.Models;

public interface IFingerPrintClient : IHikvisionServiceClient
{
    IAsyncEnumerable<FingerPrint> GetUserFingerPrintsAsync(string employeeNo);
}