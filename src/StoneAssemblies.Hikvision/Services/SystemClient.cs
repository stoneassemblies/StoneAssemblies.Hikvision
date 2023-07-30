namespace StoneAssemblies.Hikvision.Services;

using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Xml.Linq;

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
        this.httpClient = httpClient;
    }

    public async Task<Time> GetTimeAsync()
    {
        var httpResponseMessage = await this.httpClient.GetAsync(EndPoints.Xml.SystemTime);
        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
        var document = XDocument.Parse(responseContentString);

        var value = document.Root.Element(IsapiXml.Time.LocalTime)!.Value;
        var dateTimeOffset = DateTimeOffset.Parse(value);
        return new Time
                   {
                       TimeMode = document.Root!.Element(IsapiXml.Time.TimeMode)!.Value,
                       LocalTime = dateTimeOffset.DateTime,
                       TimeZone = document.Root.Element(IsapiXml.Time.TimeZone)!.Value
                   };
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

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
        var document = XDocument.Parse(responseContentString);

        return new DeviceInfo
        {
            DeviceName = document.Root!.Element(IsapiXml.DeviceInfo.DeviceName)!.Value,
            DeviceID = int.Parse(document.Root!.Element(IsapiXml.DeviceInfo.DeviceID)!.Value),
            Model = document.Root!.Element(IsapiXml.DeviceInfo.Model)!.Value,
            SerialNumber = document.Root!.Element(IsapiXml.DeviceInfo.SerialNumber)!.Value,
            MacAddress = document.Root!.Element(IsapiXml.DeviceInfo.MacAddress)!.Value,
            FirmwareVersion = document.Root!.Element(IsapiXml.DeviceInfo.FirmwareVersion)!.Value,
            FirmwareReleasedDate = document.Root!.Element(IsapiXml.DeviceInfo.FirmwareReleasedDate)!.Value,
            DeviceType = document.Root!.Element(IsapiXml.DeviceInfo.DeviceType)!.Value,
            SupportBeep = bool.Parse(document.Root!.Element(IsapiXml.DeviceInfo.SupportBeep)!.Value),
            AlarmOutNum = int.Parse(document.Root!.Element(IsapiXml.DeviceInfo.AlarmOutNum)!.Value),
            RelayNum = int.Parse(document.Root!.Element(IsapiXml.DeviceInfo.RelayNum)!.Value),
            ElectroLockNum = int.Parse(document.Root!.Element(IsapiXml.DeviceInfo.ElectroLockNum)!.Value),
            RS485Num = int.Parse(document.Root!.Element(IsapiXml.DeviceInfo.RS485Num)!.Value),
            CustomizedInfo = document.Root!.Element(IsapiXml.DeviceInfo.CustomizedInfo)!.Value
        };
    }
}