using System;
using System.Globalization;

namespace Helpers
{
    public static class DateTimeHelper
    {
        public const string dateFormatedd_MM_yyyy = "dd-MM-yyyy";
        public const string dateFormateMM_dd_yyyy = "mm-dd-yyyy";
        private const string dateFormatedd_MMM_yyyy = "dd-MM-yyyy";
        private const string TimeSpanHH_MM_SS = @"hh\:mm\:ss";
        private const string TimeSpanHH_MM_TT = @"h:mm tt";
        public const string dateFormatedd_MMM_yyyy_hhMMss = "dd-MM-yyyy hh:mm:ss tt";
        private static readonly char[] splitArray = new char[] { '-', '/', ' ', ':', '_', '\\' };

        public const string DATEFORMATE_ddMMyyyy = "dd/MM/yyyy";

        public static DateTime ToDateDD_MM_YYYY(string dateStr)
        {
            DateTime dt;
            TryParseToDateDD_MM_YYYY(dateStr, out dt);
            return dt;
        }
        public static DateTime ToDateMM_DD_YYYY(string dateStr)
        {
            DateTime dt;
            TryParseToDateMM_DD_YYYY(dateStr, out dt);
            return dt;
        }

        public static string ToArabicDate(DateTime dateStr)
        {
            return dateStr.ToString("dd, MMMM, yyyy", new CultureInfo("ar-AE"));
        }
        public static DateTime ParseToDateTime(string dateStr)
        {
            try
            {
                DateTime dt;
                if (!DateTime.TryParse(dateStr, out dt))
                {
                    if (!TryParseToDateYYYY_MM_DD(dateStr, out dt))
                    {
                        if (!TryParseToDateDD_MM_YYYY(dateStr, out dt))
                        {
                            // do no thing!
                        }
                    }
                }
                return dt;
            }
            catch
            {
                return DateTime.Today;
            }
        }

        public static bool TryParseToDateDD_MM_YYYY(string dd_MM_yyyy, out DateTime dt)
        {
            var vals = dd_MM_yyyy.Trim().Split(new char[] { '-', '/', '_', '\\' });
            try
            {
                if (!string.IsNullOrWhiteSpace(dd_MM_yyyy))
                    dt = new DateTime(int.Parse(vals[2].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()));
                else
                    dt = DateTime.Today;

            }
            catch
            {
                dt = new DateTime(int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[2].Trim()));
            }
            return true;



        }
        public static bool TryParseToDateMM_DD_YYYY(string dd_MM_yyyy, out DateTime dt)
        {
            try
            {
                var vals = dd_MM_yyyy.Trim().Split(new char[] { '-', '/', '_', '\\' });
                dt = new DateTime(int.Parse(vals[1].Trim()), int.Parse(vals[2].Trim()), int.Parse(vals[0].Trim()));
                return true;
            }
            catch
            {
                dt = DateTime.Today;
                return false;
            }
        }


        public static bool TryParseToDateDD_MM_YYYY(string dd_MM_yyyy, out DateTime? dt)
        {
            try
            {
                var vals = dd_MM_yyyy.Trim().Split(new char[] { '-', '/', '_', '\\' });
                dt = new DateTime(int.Parse(vals[2].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()));
                return true;
            }
            catch
            {
                dt = null;
                return false;
            }
        }

        public static bool TryParseToDateYYYY_MM_DD(string yyyy_MM_dd, out DateTime dt)
        {
            try
            {
                var vals = yyyy_MM_dd.Trim().Split(new char[] { '-', '/', '_', '\\' });
                dt = new DateTime(int.Parse(vals[1].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[2].Trim()));
                return true;
            }
            catch
            {
                dt = DateTime.Today;
                return false;
            }
        }

        public static bool TryParseToDateTime(string datetimeStr, out DateTime dt)
        {
            try
            {
                if (!DateTime.TryParse(datetimeStr, out dt))
                {
                    if (!TryParseToDateTimeDD_MM_YYYY_TIME(datetimeStr, out dt))
                    {
                        if (!TryParseToDateTimeMM_DD_YYYY_TIME(datetimeStr, out dt))
                        {
                            throw new Exception("Invalid date!");
                        }
                    }
                }
                return true;
            }
            catch
            {
                dt = DateTime.Today;
                return false;
            }
        }


        //public static bool TryParseToDateTimeDD_MM_YYYY_TIME(string DD_MM_YYYY_TIME, out DateTime dt)
        //{
        //    dt = DateTime.Today;
        //    try
        //    {
        //        var vals = DD_MM_YYYY_TIME.Trim().Split(new char[] { '-', '/', '_', '\\', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

        //        int year = int.Parse(vals[2].Trim());
        //        if (year < 30)
        //            year = int.Parse("20" + vals[2].Trim());
        //        else if (year < 100)
        //            year = int.Parse("19" + vals[2].Trim());

        //        if (vals.Length == 5) // d m y H M
        //        {
        //            dt = new DateTime(year, int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()), int.Parse(vals[3].Trim()), int.Parse(vals[4].Trim()), 0);
        //            return true;
        //        }
        //        else if (vals.Length == 6) // d m y H M t
        //        {
        //            int hours = int.Parse(vals[3].Trim());
        //            if (vals[5].Trim().ToLower() == "pm")
        //                hours += 12;
        //            dt = new DateTime(year, int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()), hours, int.Parse(vals[4].Trim()), 0);
        //            return true;
        //        }
        //    }
        //    catch { }
        //    return false;
        //}

        public static string ToStringDD_MM_YYYY(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
                return dateTime.ToString(dateFormatedd_MM_yyyy);
            return string.Empty;
        }

        public static string ToStringDD_MM_YYYY(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString(dateFormatedd_MM_yyyy);
            return string.Empty;
        }

        public static string ToStringDD_MMM_YYYY(DateTime dateTime)
        {
            return dateTime.ToString(dateFormatedd_MMM_yyyy);
        }

        public static bool TryParseToDateTimeMM_DD_YYYY_TIME(string MM_DD_YYYY_TIME, out DateTime dt)
        {
            dt = DateTime.Today;
            try
            {
                var vals = MM_DD_YYYY_TIME.Trim().Split(new char[] { '-', '/', '_', '\\', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(vals[2].Trim());
                if (year < 30)
                    year = int.Parse("20" + vals[2].Trim());
                else if (year < 100)
                    year = int.Parse("19" + vals[2].Trim());

                if (vals.Length == 5) // m d y H M
                {
                    dt = new DateTime(year, int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()), int.Parse(vals[3].Trim()), int.Parse(vals[4].Trim()), 0);
                    return true;
                }
                else if (vals.Length == 6) // m d y H M t
                {
                    int hours = int.Parse(vals[3].Trim());
                    if (vals[5].Trim().ToLower() == "pm")
                        hours += 12;
                    dt = new DateTime(year, int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), hours, int.Parse(vals[4].Trim()), 0);
                    return true;
                }
            }
            catch { }
            return false;
        }


        public static bool TryParseToTimeHH_MM_tt(string HH_MM_tt, out TimeSpan ts)
        {
            try
            {
                DateTime t = DateTime.ParseExact(HH_MM_tt, TimeSpanHH_MM_TT, CultureInfo.InvariantCulture);
                //if you really need a TimeSpan this will get the time elapsed since midnight:
                ts = t.TimeOfDay;
                return true;
            }
            catch
            {
                ts = DateTime.Today.TimeOfDay;
                return false;
            }
        }


        public static bool TryParseToTimeHH_MM_SS(string HH_MM_SS, out TimeSpan ts)
        {
            try
            {
                var vals = HH_MM_SS.Trim().Split(new char[] { ':' });
                if (vals.Length > 2)
                    ts = new TimeSpan(int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[2].Trim()));
                else
                    ts = new TimeSpan(int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), 0);
                return true;
            }
            catch
            {
                ts = DateTime.Today.TimeOfDay;
                return false;
            }
        }

        public static bool TryParseToTimeHH_MM_SS(string HH_MM_SS, out TimeSpan? ts)
        {
            try
            {
                var vals = HH_MM_SS.Trim().Split(new char[] { ':' });
                if (vals.Length > 2)
                    ts = new TimeSpan(int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), int.Parse(vals[2].Trim()));
                else
                    ts = new TimeSpan(int.Parse(vals[0].Trim()), int.Parse(vals[1].Trim()), 0);
                return true;
            }
            catch
            {
                ts = null;
                return false;
            }
        }

        public static string ToStringDD_MM_YYYY_TIME(DateTime dateTime)
        {
            if (dateTime >= DateTime.MinValue)
                return dateTime.ToString(dateFormatedd_MMM_yyyy_hhMMss);
            return string.Empty;
        }

        public static string ToStringDD_MM_YYYY_TIME(DateTime? dateTime)
        {
            if (dateTime.HasValue && dateTime.Value >= DateTime.MinValue)
                return dateTime.Value.ToString(dateFormatedd_MMM_yyyy_hhMMss);
            return string.Empty;
        }

        public static bool TryParseToDateTimeDD_MM_YYYY_TIME(string DD_MM_YYYY_TIME, out DateTime dt)
        {
            dt = DateTime.Today;
            try
            {
                var vals = DD_MM_YYYY_TIME.Trim().Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(vals[2].Trim());
                if (year < 30)
                    year = int.Parse("20" + vals[2].Trim());
                else if (year < 100)
                    year = int.Parse("19" + vals[2].Trim());

                if (vals.Length == 5) // d m y H M
                {
                    dt = new DateTime(year, int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()), int.Parse(vals[3].Trim()), int.Parse(vals[4].Trim()), 0);
                    return true;
                }
                else if (vals.Length == 6) // d m y H M t
                {
                    int hours = int.Parse(vals[3].Trim());
                    if (vals[5].Trim().ToLower() == "pm")
                        hours += 12;
                    dt = new DateTime(year, int.Parse(vals[1].Trim()), int.Parse(vals[0].Trim()), hours, int.Parse(vals[4].Trim()), 0);
                    return true;
                }
                return TryParseToDateDD_MM_YYYY(DD_MM_YYYY_TIME, out dt);
            }
            catch { }
            return false;
        }

        public static string ToStringHH_MM_SS(TimeSpan timeSpan)
        {
            return timeSpan.ToString(TimeSpanHH_MM_SS);
        }

        public static string ToStringHH_MM_SS(TimeSpan? timeSpan)
        {
            if (timeSpan.HasValue)
                return timeSpan.Value.ToString(TimeSpanHH_MM_SS);
            return string.Empty;
        }


        public static string ToStringHH_MM_TT(TimeSpan timeSpan)
        {
            return timeSpan.ToString(TimeSpanHH_MM_TT);
        }

        public static string ToStringHH_MM_TT(TimeSpan? timeSpan)
        {
            if (timeSpan.HasValue)
            {
                var dt = new DateTime().Add(timeSpan.Value);
                return dt.ToString(TimeSpanHH_MM_TT);
            }
            return string.Empty;
        }


        public static string ToCountryDateTime(DateTime? utcDateTime)
        {
            if (utcDateTime.HasValue)
                return ToCountryDateTime(utcDateTime.Value);
            return string.Empty;
        }

    }
}
