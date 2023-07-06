namespace StoneAssemblies.Hikvision.Services;

public class ResponseStatus
{
    public string RequestURL { get; set; }

    public int StatusCode { get; set; }

    public string StatusString { get; set; }

    public string SubStatusCode { get; set; }

    public int ErrorCode { get; set; }

    public string ErrorMsg { get; set; }
}