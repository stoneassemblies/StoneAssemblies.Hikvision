namespace StoneAssemblies.Hikvision.Models;

public class AcsEventInfo
{
    public int Major { get; set; }

    public int Minor { get; set; }

    public string Time { get; set; }

    public string NetUser { get; set; }

    public string RemoteHostAddr { get; set; }

    public string CardNo { get; set; }

    public int? CardType { get; set; }

    public int? WhiteListNo { get; set; }

    public int? ReportChannel { get; set; }

    public int? CardReaderKind { get; set; }

    public int? CardReaderNo { get; set; }

    public int? DoorNo { get; set; }

    public int? VerifyNo { get; set; }

    public int? AlarmInNo { get; set; }

    public int? AlarmOutNo { get; set; }

    public int? CaseSensorNo { get; set; }

    public int? RS485No { get; set; }

    public int? MultiCardGroupNo { get; set; }

    public int? AccessChannel { get; set; }

    public int? DeviceNo { get; set; }

    public int? DistractControlNo { get; set; }

    public string EmployeeNoString { get; set; }

    public int? LocalControllerID { get; set; }

    public int? InternetAccess { get; set; }

    public int? Type { get; set; }

    public string MACAddr { get; set; }

    public int? SwipeCardType { get; set; }

    public int? SerialNo { get; set; }

    public int? ChannelControllerID { get; set; }

    public int? ChannelControllerLampID { get; set; }

    public int? ChannelControllerIRAdaptorID { get; set; }

    public int? ChannelControllerIREmitterID { get; set; }

    public string UserType { get; set; }

    public string CurrentVerifyMode { get; set; }

    public bool? PicEnable { get; set; }

    public string AttendanceStatus { get; set; }

    public int? StatusValue { get; set; }

    public string Filename { get; set; }
}