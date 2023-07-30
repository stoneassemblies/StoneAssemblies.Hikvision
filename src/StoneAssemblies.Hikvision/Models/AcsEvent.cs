namespace StoneAssemblies.Hikvision.Models;

public class AcsEvent
{
    public string SearchID { get; set; }

    public string ResponseStatusStrg { get; set; }

    public string NumOfMatches { get; set; }

    public string TotalMatches { get; set; }

    public List<AcsEventInfo> InfoList { get; set; }

    public int? PicturesNumber { get; set; }
}