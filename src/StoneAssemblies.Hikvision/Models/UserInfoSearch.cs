namespace StoneAssemblies.Hikvision.Models;

public class UserInfoSearch
{
    public string? SearchID { get; set; }

    public string? ResponseStatusStrg { get; set; }

    public int NumOfMatches { get; set; }

    public int TotalMatches { get; set; }

    public List<UserInfo>? UserInfo { get; set; }
}