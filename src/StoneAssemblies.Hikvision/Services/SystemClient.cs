namespace StoneAssemblies.Hikvision.Services;

using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using StoneAssemblies.Hikvision.Models;
using StoneAssemblies.Hikvision.Services.Interfaces;

public class SystemClient : ISystemClient
{
    private const string SetTimeRequestContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Time version=""2.0"" xmlns=""http://www.isapi.org/ver20/XMLSchema"">
    <timeMode>{0}</timeMode>
    <localTime>{1}</localTime>
    <timeZone>{2}</timeZone>
    <daylightSavingMode>{3}</daylightSavingMode>
</Time>";

    private readonly HttpClient httpClient;

    public SystemClient(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        this.httpClient = httpClient;
    }

    public async Task<Time> GetTimeAsync()
    {
        var httpResponseMessage = await this.httpClient.GetAsync(EndPoints.Xml.SystemTime);
        httpResponseMessage.EnsureSuccessStatusCode();

        var overrides = new XmlAttributeOverrides();
        overrides.Add(
            typeof(Time),
            new XmlAttributes
            {
                XmlRoot = new XmlRootAttribute("Time") { Namespace = "http://www.isapi.org/ver20/XMLSchema" }
            });

        overrides.Add(
            typeof(Time),
            nameof(Time.TimeMode),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("timeMode") } });

        overrides.Add(
            typeof(Time),
            nameof(Time.LocalTime),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("localTime") } });

        overrides.Add(
            typeof(Time),
            nameof(Time.TimeZone),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("timeZone") } });

        var xmlSerializer = new XmlSerializer(typeof(Time), overrides);
        var time = xmlSerializer.Deserialize(await httpResponseMessage.Content.ReadAsStreamAsync()) as Time;
        return time!;
    }

    public async Task SetTimeAsync(Time time, bool syncTimeZone = true)
    {
        var content = string.Format(
            SetTimeRequestContent,
            time.TimeMode,
            syncTimeZone ? time.LocalTime.ToString(TimeFormats.TimeFormatWithoutTimeZone) : time.LocalTime.ToString(TimeFormats.TimeFormat),
            time.TimeZone,
            time.DaylightSavingMode);

        var stringContent = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Xml);
        var httpResponseMessage = await this.httpClient.PutAsync(EndPoints.Xml.SystemTime, stringContent);
        httpResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task<DeviceInfo> GetDeviceInfoAsync()
    {
        var httpResponseMessage = await this.httpClient.GetAsync(EndPoints.Xml.DeviceInfo);
        httpResponseMessage.EnsureSuccessStatusCode();

        var overrides = new XmlAttributeOverrides();
        overrides.Add(
            typeof(DeviceInfo),
            new XmlAttributes
            {
                XmlRoot = new XmlRootAttribute("DeviceInfo") { Namespace = "http://www.isapi.org/ver20/XMLSchema" }
            });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.DeviceName),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("deviceName") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.DeviceID),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("deviceID") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.Model),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("model") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.SerialNumber),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("serialNumber") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.MacAddress),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("macAddress") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.FirmwareVersion),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("firmwareVersion") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.FirmwareReleasedDate),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("firmwareReleasedDate") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.EncoderReleasedDate),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("encoderReleasedDate") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.EncoderVersion),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("encoderVersion") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.DeviceType),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("deviceType") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.TelecontrolID),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("telecontrolID") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.SupportBeep),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("supportBeep") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.AlarmOutNum),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("alarmOutNum") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.RelayNum),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("relayNum") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.LocalZoneNum),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("localZoneNum") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.ElectroLockNum),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("electroLockNum") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.RS485Num),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("RS485Num") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.CustomizedInfo),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("customizedInfo") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.Manufacturer),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("manufacturer") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.OEMCode),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("OEMCode") } });

        overrides.Add(
            typeof(DeviceInfo),
            nameof(DeviceInfo.MarketType),
            new XmlAttributes { XmlElements = { new XmlElementAttribute("marketType") } });

        var xmlSerializer = new XmlSerializer(typeof(DeviceInfo), overrides);
        var deviceInfo = xmlSerializer.Deserialize(await httpResponseMessage.Content.ReadAsStreamAsync()) as DeviceInfo;
        return deviceInfo!;
    }
}