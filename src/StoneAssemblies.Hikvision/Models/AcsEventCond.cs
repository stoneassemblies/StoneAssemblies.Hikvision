namespace StoneAssemblies.Hikvision.Models;

public class AcsEventCond
{
    public string SearchID { get; set; }

    public int SearchResultPosition { get; set; }

    public int MaxResults { get; set; }

    public int Major { get; set; }

    public int Minor { get; set; }

    public string StartTime { get; set; }

    public string EndTime { get; set; }

    public string CardNo { get; set; }

    public string Name { get; set; }

    public bool? PicEnable { get; set; }

    public int? BeginSerialNo { get; set; }

    public int? EndSerialNo { get; set; }

    public string EmployeeNoString { get; set; }

    public string EventAttribute { get; set; }

    public string EmployeeNo { get; set; }

    public bool? TimeReverseOrder { get; set; }
}