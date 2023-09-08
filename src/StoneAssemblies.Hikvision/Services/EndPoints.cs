namespace StoneAssemblies.Hikvision.Services;

public static class EndPoints
{
    public static class Xml
    {
        public const string SystemTime = "/ISAPI/System/time";
        public const string DeviceInfo = "/ISAPI/System/deviceInfo";
    }

    public class Json
    {
        public const string UserInfoSearch = "/ISAPI/AccessControl/UserInfo/Search?format=json";
        public const string UserInfoModify = "/ISAPI/AccessControl/UserInfo/Modify?format=json";
        public const string UserInfoRecord = "/ISAPI/AccessControl/UserInfo/Record?format=json";
        public const string FingerPrintUpload = "/ISAPI/AccessControl/FingerPrintUpload?format=json";
        public const string AcsEvent = "/ISAPI/AccessControl/AcsEvent?format=json";
    }
}