namespace StoneAssemblies.Hikvision.Models;

public class FingerPrintInfo
{
    public string SearchID { get; set; }

    public string Status { get; set; }

    public List<FingerPrint> FingerPrintList { get; set; }
}