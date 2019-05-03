using System;
using System.Globalization;

namespace Helpers
{
    public class DateUtility
    {
        private const string DateOnlyFormat = "dd-MM-yyyy";

        private const string DateWithTimeFormat = "dd-MM-yyyy hh:mm:ss tt";

        public static string FormatDateOnly(DateTime date, bool convertToHijri)
        {
            if (convertToHijri)
            {
                return date.ToHijriDateString("dd-MM-yyyy");
            }
            return date.ToString("dd-MM-yyyy");
        }

        public static string FormatDateWithTime(DateTime date, bool convertToHijri)
        {
            if (convertToHijri)
            {
                return date.ToHijriDateString("dd-MM-yyyy hh:mm:ss tt");
            }
            return date.ToString("dd-MM-yyyy hh:mm:ss tt");
        }

        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int num = dt.DayOfWeek - startOfWeek;
            if (num < 0)
            {
                num += 7;
            }
            return dt.AddDays(-1 * num).Date;
        }

        public static DateTime? ExtractDate(string dateTextYYYYMMDD)
        {
            DateTime? result = null;
            if (!string.IsNullOrWhiteSpace(dateTextYYYYMMDD) && dateTextYYYYMMDD.Length == 8)
            {
                try
                {
                    int year = int.Parse(dateTextYYYYMMDD.Substring(0, 4));
                    int month = int.Parse(dateTextYYYYMMDD.Substring(4, 2));
                    int day = int.Parse(dateTextYYYYMMDD.Substring(6, 2));
                    result = new DateTime(year, month, day).Date;
                    return result;
                }
                catch
                {
                    return result;
                }
            }
            return result;
        }

        public static DateTime ConvertHijriToMiladi(DateTime hijriDate)
        {
            return new DateTime(hijriDate.Year, hijriDate.Month, hijriDate.Day, hijriDate.Hour, hijriDate.Minute, hijriDate.Second, new CultureInfo("ar-SA").Calendar);
        }
    }
}
