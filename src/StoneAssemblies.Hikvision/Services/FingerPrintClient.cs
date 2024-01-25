namespace StoneAssemblies.Hikvision.Services;

using StoneAssemblies.Hikvision.Services.Interfaces;

using StoneAssemblies.Hikvision.Models;

public class FingerPrintClient : IFingerPrintClient
{
    private readonly HttpClient httpClient;

    private readonly ISearchIdGenerationService searchIdGenerationService;

    public FingerPrintClient(HttpClient httpClient, ISearchIdGenerationService searchIdGenerationService)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(searchIdGenerationService);

        this.httpClient = httpClient;
        this.searchIdGenerationService = searchIdGenerationService;
    }

    public async IAsyncEnumerable<FingerPrint> GetUserFingerPrintsAsync(string employeeNo)
    {
        var request = new FingerPrintCond
        {
            SearchID = searchIdGenerationService.Next(),
            EmployeeNo = employeeNo
        };

        try
        {
            for (int fingerPrintId = 1; fingerPrintId <= 10; fingerPrintId++)
            {
                request.FingerPrintID = fingerPrintId;
                var fingerPrintInfo = await httpClient.PostAsync<FingerPrintCond, FingerPrintInfo>(EndPoints.Json.FingerPrintUpload, request);
                if (fingerPrintInfo?.FingerPrintList is not null)
                {
                    foreach (var fingerPrint in fingerPrintInfo.FingerPrintList)
                    {
                        yield return fingerPrint;
                    }
                }
            }
        }
        finally
        {
            this.searchIdGenerationService.Release(request.SearchID);
        }
    }
}