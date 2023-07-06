namespace StoneAssemblies.Hikvision.Models
{
    using System.Xml.Serialization;

    public class DeviceInfo
    {
        public string DeviceName { get; set; }

        public int DeviceID { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public string MacAddress { get; set; }

        public string FirmwareVersion { get; set; }

        public string FirmwareReleasedDate { get; set; }

        public string DeviceType { get; set; }

        public bool SupportBeep { get; set; }

        public int AlarmOutNum { get; set; }

        public int RelayNum { get; set; }

        public int ElectroLockNum { get; set; }

        public int RS485Num { get; set; }

        public string CustomizedInfo { get; set; }
    }
}