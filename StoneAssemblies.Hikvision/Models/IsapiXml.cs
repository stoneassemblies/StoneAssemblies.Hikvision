namespace StoneAssemblies.Hikvision.Models;

using System.Xml.Linq;

public class IsapiXml
{
    private const string Schema = "http://www.isapi.org/ver20/XMLSchema";

    public class Time
    {
        public static readonly XName TimeMode = XName.Get("timeMode", Schema);

        public static readonly XName LocalTime = XName.Get("localTime", Schema);

        public static readonly XName TimeZone = XName.Get("timeZone", Schema);
    }

    public class DeviceInfo
    {
        public static readonly XName DeviceName = XName.Get("deviceName", Schema);
        public static readonly XName DeviceID = XName.Get("deviceID", Schema);
        public static readonly XName Model = XName.Get("model", Schema);
        public static readonly XName SerialNumber = XName.Get("serialNumber", Schema);
        public static readonly XName MacAddress = XName.Get("macAddress", Schema);
        public static readonly XName FirmwareVersion = XName.Get("firmwareVersion", Schema);
        public static readonly XName FirmwareReleasedDate = XName.Get("firmwareReleasedDate", Schema);
        public static readonly XName DeviceType = XName.Get("deviceType", Schema);
        public static readonly XName SupportBeep = XName.Get("supportBeep", Schema);
        public static readonly XName AlarmOutNum = XName.Get("alarmOutNum", Schema);
        public static readonly XName RelayNum = XName.Get("relayNum", Schema);
        public static readonly XName ElectroLockNum = XName.Get("electroLockNum", Schema);
        public static readonly XName RS485Num = XName.Get("RS485Num", Schema);
        public static readonly XName CustomizedInfo = XName.Get("customizedInfo", Schema);
    }
}