namespace StoneAssemblies.Hikvision.Models;

public class UserInfo
{
    public string EmployeeNo { get; set; }

    public string Name { get; set; }

    public string UserType { get; set; }

    public bool CloseDelayEnabled { get; set; }

    public Valid Valid { get; set; }

    public string BelongGroup { get; set; }

    public string Password { get; set; }

    public string DoorRight { get; set; }

    public List<RightPlan> RightPlan { get; set; }

    public int MaxOpenDoorTime { get; set; }

    public int OpenDoorTime { get; set; }

    public int RoomNumber { get; set; }

    public int FloorNumber { get; set; }

    public bool DoubleLockRight { get; set; }

    public bool LocalUIRight { get; set; }

    public string UserVerifyMode { get; set; }

    public string Gender { get; set; }

    public List<PersonInfoExtend> PersonInfoExtends { get; set; }
}