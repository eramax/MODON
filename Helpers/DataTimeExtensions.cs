using System;
using System.Globalization;

namespace Helpers
{
    public static class DataTimeExtensions
    {
        public static string ToDateWithMonthName(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy");
        }

        public static string ToDateFullDetails(this DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("ar-EG");
            return dateTime.ToString("dddd dd MMMM yyyy", cultureInfo) + " ميلادي";
        }
        public static string ToDateHijriFullDetails(this DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("ar-SA");
            return dateTime.ToString("dddd dd MMMM yyyy", cultureInfo) + " هجري";
        }

        public static HijriDateTime ToHijriDateObject(this DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("ar-SA");
            Calendar calendar = cultureInfo.Calendar;
            return new HijriDateTime
            {
                Year = calendar.GetYear(dateTime),
                Month = calendar.GetMonth(dateTime),
                MonthName = dateTime.ToString("MMMM", cultureInfo.DateTimeFormat),
                Day = calendar.GetDayOfMonth(dateTime),
                DayName = dateTime.ToString("dddd", cultureInfo.DateTimeFormat),
                Hour = calendar.GetHour(dateTime),
                Minute = calendar.GetMinute(dateTime),
                Second = calendar.GetSecond(dateTime)
            };
        }

        public static string ToHijriDateString(this DateTime dateTime, string format)
        {
            CultureInfo cultureInfo = new CultureInfo("ar-SA");
            return dateTime.ToString(format, cultureInfo.DateTimeFormat);
        }
    }
}
