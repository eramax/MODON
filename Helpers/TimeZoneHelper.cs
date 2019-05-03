using System;
using System.Collections.Generic;

namespace Helpers
{
    public static class TimeZoneHelper
    {
        public static string ToCountryDateTime(DateTime? utcDateTime)
        {
            if (utcDateTime.HasValue)
                return ToCountryDateTime(utcDateTime.Value);
            return string.Empty;
        }

        public static string ToCountryDateTime(DateTime utcDateTime)
        {
            string countryTimeZone = RailsToWindows(SessionHelper.CurrentCountryTimeZone);
            if (!string.IsNullOrWhiteSpace(countryTimeZone))
            {
                try
                {
                    var dateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDateTime, TimeZoneInfo.Utc.DisplayName, countryTimeZone);
                    return DateTimeHelper.ToStringDD_MM_YYYY_TIME(dateTime);
                }
                catch (Exception ex)
                {
                    MDResponse.CallErrorHandlers(ex, utcDateTime);
                }
            }
            return DateTimeHelper.ToStringDD_MM_YYYY_TIME(utcDateTime);
        }

        public static string RailsToWindows(string railsTimeZoneId)
        {
            if (!string.IsNullOrWhiteSpace(railsTimeZoneId))
            {
                railsTimeZoneId = railsTimeZoneId.ToLower();
                var i = railsTimeZoneId.IndexOf("/");
                if (i != -1)
                    railsTimeZoneId = railsTimeZoneId.Substring(i + 1);
                if (RailsWindowsMapping.ContainsKey(railsTimeZoneId))
                    return RailsWindowsMapping[railsTimeZoneId];
            }

            return TimeZone.CurrentTimeZone.StandardName;
        }

        private static readonly IReadOnlyDictionary<string, string> RailsWindowsMapping = new Dictionary<string, string>
        {
            {"abu dhabi", "Arabian Standard Time"},
            {"adelaide", "Cen. Australia Standard Time"},
            {"alaska", "Alaskan Standard Time"},
            {"almaty", "Central Asia Standard Time"},
            {"american samoa", "UTC-11"},
            {"amsterdam", "W. Europe Standard Time"},
            {"arizona", "US Mountain Standard Time"},
            {"astana", "Bangladesh Standard Time"},
            {"athens", "GTB Standard Time"},
            {"atlantic time (canada)", "Atlantic Standard Time"},
            {"auckland", "New Zealand Standard Time"},
            {"azores", "Azores Standard Time"},
            {"baghdad", "Arabic Standard Time"},
            {"baku", "Azerbaijan Standard Time"},
            {"bangkok", "SE Asia Standard Time"},
            {"beijing", "China Standard Time"},
            {"belgrade", "Central Europe Standard Time"},
            {"berlin", "W. Europe Standard Time"},
            {"bern", "W. Europe Standard Time"},
            {"bogota", "SA Pacific Standard Time"},
            {"brasilia", "E. South America Standard Time"},
            {"bratislava", "Central Europe Standard Time"},
            {"brisbane", "E. Australia Standard Time"},
            {"brussels", "Romance Standard Time"},
            {"bucharest", "GTB Standard Time"},
            {"budapest", "Central Europe Standard Time"},
            {"buenos aires", "Argentina Standard Time"},
            {"cairo", "Egypt Standard Time"},
            {"canberra", "AUS Eastern Standard Time"},
            {"cape verde is.", "Cape Verde Standard Time"},
            {"caracas", "Venezuela Standard Time"},
            {"casablanca", "Morocco Standard Time"},
            {"central america", "Central America Standard Time"},
            {"central time (us & canada)", "Central Standard Time"},
            {"chennai", "India Standard Time"},
            {"chihuahua", "Mountain Standard Time (Mexico)"},
            {"chongqing", "China Standard Time"},
            {"copenhagen", "Romance Standard Time"},
            {"darwin", "AUS Central Standard Time"},
            {"dhaka", "Bangladesh Standard Time"},
            {"dublin", "GMT Standard Time"},
            {"eastern time (us & canada)", "Eastern Standard Time"},
            {"edinburgh", "GMT Standard Time"},
            {"ekaterinburg", "Ekaterinburg Standard Time"},
            {"fiji", "Fiji Standard Time"},
            {"georgetown", "SA Western Standard Time"},
            {"greenland", "Greenland Standard Time"},
            {"guadalajara", "Central Standard Time (Mexico)"},
            {"guam", "West Pacific Standard Time"},
            {"hanoi", "SE Asia Standard Time"},
            {"harare", "South Africa Standard Time"},
            {"hawaii", "Hawaiian Standard Time"},
            {"helsinki", "FLE Standard Time"},
            {"hobart", "Tasmania Standard Time"},
            {"hong kong", "China Standard Time"},
            {"indiana (east)", "US Eastern Standard Time"},
            {"international date line west", "UTC-11"},
            {"irkutsk", "North Asia East Standard Time"},
            {"islamabad", "Pakistan Standard Time"},
            {"istanbul", "Turkey Standard Time"},
            {"jakarta", "SE Asia Standard Time"},
            {"jerusalem", "Israel Standard Time"},
            {"kabul", "Afghanistan Standard Time"},
            {"kaliningrad", "Kaliningrad Standard Time"},
            {"kamchatka", "Russia Time Zone 11"},
            {"karachi", "Pakistan Standard Time"},
            {"kathmandu", "Nepal Standard Time"},
            {"kolkata", "India Standard Time"},
            {"krasnoyarsk", "North Asia Standard Time"},
            {"kuala lumpur", "Singapore Standard Time"},
            {"kuwait", "Arab Standard Time"},
            {"kyiv", "FLE Standard Time"},
            {"la paz", "SA Western Standard Time"},
            {"lima", "SA Pacific Standard Time"},
            {"lisbon", "GMT Standard Time"},
            {"ljubljana", "Central Europe Standard Time"},
            {"london", "GMT Standard Time"},
            {"madrid", "Romance Standard Time"},
            {"magadan", "Magadan Standard Time"},
            {"marshall is.", "UTC+12"},
            {"mazatlan", "Mountain Standard Time (Mexico)"},
            {"melbourne", "AUS Eastern Standard Time"},
            {"mexico city", "Central Standard Time (Mexico)"},
            {"mid-atlantic", "UTC-02"},
            {"midway island", "UTC-11"},
            {"minsk", "Belarus Standard Time"},
            {"monrovia", "Greenwich Standard Time"},
            {"monterrey", "Central Standard Time (Mexico)"},
            {"montevideo", "Montevideo Standard Time"},
            {"moscow", "Russian Standard Time"},
            {"mountain time (us & canada)", "Mountain Standard Time"},
            {"mumbai", "India Standard Time"},
            {"muscat", "Arabian Standard Time"},
            {"nairobi", "E. Africa Standard Time"},
            {"new caledonia", "Central Pacific Standard Time"},
            {"new delhi", "India Standard Time"},
            {"newfoundland", "Newfoundland Standard Time"},
            {"novosibirsk", "N. Central Asia Standard Time"},
            {"nuku'alofa", "Tonga Standard Time"},
            {"osaka", "Tokyo Standard Time"},
            {"pacific time (us & canada)", "Pacific Standard Time"},
            {"paris", "Romance Standard Time"},
            {"perth", "W. Australia Standard Time"},
            {"port moresby", "West Pacific Standard Time"},
            {"prague", "Central Europe Standard Time"},
            {"pretoria", "South Africa Standard Time"},
            {"quito", "SA Pacific Standard Time"},
            {"rangoon", "Myanmar Standard Time"},
            {"riga", "FLE Standard Time"},
            {"riyadh", "Arab Standard Time"},
            {"rome", "W. Europe Standard Time"},
            {"samara", "Russia Time Zone 3"},
            {"samoa", "Samoa Standard Time"},
            {"santiago", "Pacific SA Standard Time"},
            {"sapporo", "Tokyo Standard Time"},
            {"sarajevo", "Central European Standard Time"},
            {"saskatchewan", "Canada Central Standard Time"},
            {"seoul", "Korea Standard Time"},
            {"singapore", "Singapore Standard Time"},
            {"skopje", "Central European Standard Time"},
            {"sofia", "FLE Standard Time"},
            {"solomon is.", "Central Pacific Standard Time"},
            {"srednekolymsk", "Russia Time Zone 10"},
            {"sri jayawardenepura", "Sri Lanka Standard Time"},
            {"st. petersburg", "Russian Standard Time"},
            {"stockholm", "W. Europe Standard Time"},
            {"sydney", "AUS Eastern Standard Time"},
            {"taipei", "Taipei Standard Time"},
            {"tallinn", "FLE Standard Time"},
            {"tashkent", "West Asia Standard Time"},
            {"tbilisi", "Georgian Standard Time"},
            {"tehran", "Iran Standard Time"},
            {"tijuana", "Pacific Standard Time"},
            {"tokelau is.", "Tonga Standard Time"},
            {"tokyo", "Tokyo Standard Time"},
            {"ulaanbaatar", "Ulaanbaatar Standard Time"},
            {"urumqi", "Central Asia Standard Time"},
            {"utc", "UTC"},
            {"vienna", "W. Europe Standard Time"},
            {"vilnius", "FLE Standard Time"},
            {"vladivostok", "Vladivostok Standard Time"},
            {"volgograd", "Russian Standard Time"},
            {"warsaw", "Central European Standard Time"},
            {"wellington", "New Zealand Standard Time"},
            {"west central africa", "W. Central Africa Standard Time"},
            {"yakutsk", "Yakutsk Standard Time"},
            {"yerevan", "Caucasus Standard Time"},
            {"zagreb", "Central European Standard Time"}
        };
    }
}