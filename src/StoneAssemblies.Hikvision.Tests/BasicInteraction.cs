using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneAssemblies.Hikvision.Tests;

using System.Globalization;
using System.Numerics;

using Xunit;

public class BasicInteraction
{
    [Fact]
    public void WorkingWithDateTime()
    {
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");


        var timeSpan1 = new TimeSpan(0, -5, 0, 0);
        var timeSpan2 = new TimeSpan(0, -4, 0, 0);

        // var time = DateTime.Now;
        var timeZoneInfo = TimeZoneInfo.Local;
        var now = DateTime.Now;

        var convertedNow = TimeZoneInfo.ConvertTime(now, timeZoneInfo);

        var s = now.ToString("yyyy-MM-ddTHH:mm:ss-05:00");
        var exact = DateTime.ParseExact(s, "yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture);

        var dateTime = convertedNow.ToString("yyyy-MM-ddTHH:mm:ssK");
        var dateTime2 = exact.ToString("yyyy-MM-ddTHH:mm:ssK");
    }


    [Fact]
    public void WorkingWithDateTime2()
    {
        //TimeZoneInfo cstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

        //var standardName = cstTimeZone.StandardName;
        //var daylightName = cstTimeZone.DaylightName;

        //DateTime dateTime = DateTime.UtcNow;
        //TimeSpan offset = cstTimeZone.GetUtcOffset(dateTime);


        // TzdbDateTimeZoneSource

        //var timeZoneInfo = TimeZoneInfo.Utc;
        //TimeZoneInfo cstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        //var timeSpan = cstTimeZone.BaseUtcOffset.Add(TimeSpan.FromHours(12));




        DateTime utcTime = DateTime.UtcNow;
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
    }
}