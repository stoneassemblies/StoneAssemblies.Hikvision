using Newtonsoft.Json;

namespace StoneAssemblies.Hikvision.Models;

public class Time
{
    public DateTime LocalTime { get; set; }

    public string? TimeMode { get; set; } = Models.TimeMode.Manual;

    public string? TimeZone { get; set; }

    public string DaylightSavingMode { get; set; } = Models.DaylightSavingMode.None;
}

public class FingerPrintCond
{
    public string SearchID { get; set; }
    public string EmployeeNo { get; set; }
    public int? CardReaderNo { get; set; }
    public int? FingerPrintID { get; set; }
}