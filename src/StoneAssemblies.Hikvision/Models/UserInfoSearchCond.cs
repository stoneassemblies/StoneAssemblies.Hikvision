namespace StoneAssemblies.Hikvision.Models;

public class UserInfoSearchCond
{
    public string SearchID { get; set; }

    public int SearchResultPosition { get; set; }
    public int MaxResults { get; set; }
    public List<EmployeeNoListItem> EmployeeNoList { get; set; }
}