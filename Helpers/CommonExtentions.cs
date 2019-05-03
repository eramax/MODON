using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

namespace Helpers
{
    public static class CommonExtentions
    {
        private static Regex ValidEmailRegex = CreateValidEmailRegex();

        public static string ReplaceLineBreaks(this string lines, string replacement)
        {
            return lines.Replace("\r\n", replacement)
                        .Replace("\r", replacement)
                        .Replace("\n", replacement);
        }

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool IsValidEmail(this string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public static string TrySerialize(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
            }
            return string.Empty;
        }

        public static bool TryParse(string dd_MM_yyyy, out DateTime dt)
        {
            try
            {
                var vals = dd_MM_yyyy.Trim().Split(new char[] { '-', '/', '_', '\\' });
                dt = new DateTime(int.Parse(vals[2]), int.Parse(vals[1]), int.Parse(vals[0]));
                return true;
            }
            catch
            {
                dt = DateTime.MaxValue;
                return false;
            }
        }

        public static bool TryParse(string booleanValue, out bool isTrue)
        {
            if (string.IsNullOrWhiteSpace(booleanValue))
            {
                isTrue = false;
                return false;
            }
            booleanValue = booleanValue.ToLower();
            if (bool.TryParse(booleanValue, out isTrue))
                return true;

            if (booleanValue == "true" || booleanValue == "1" || booleanValue == "yes" || booleanValue == "نعم")
            {
                isTrue = true;
                return true;
            }
            if (booleanValue == "false" || booleanValue == "0" || booleanValue == "no" || booleanValue == "لا")
            {
                isTrue = false;
                return true;
            }

            return false;
        }

        public static bool ParseBoolean(string booleanValue)
        {
            try
            {
                bool isTrue = false;
                booleanValue = booleanValue.ToLower();
                if (bool.TryParse(booleanValue, out isTrue))
                    return true;

                if (booleanValue == "true" || booleanValue == "1" || booleanValue == "yes" || booleanValue == "نعم")
                {
                    isTrue = true;
                    return true;
                }
                if (booleanValue == "false" || booleanValue == "0" || booleanValue == "no" || booleanValue == "لا")
                {
                    isTrue = false;
                }

                return isTrue;
            }
            catch
            {
                return false;
            }
        }

        public static bool EqualsAny(this String str, params string[] words)
        {
            if (str == null || words == null)
                return false;

            for (int i = 0; i < words.Length; i++)
            {
                if (str == words[i])
                    return true;
            }
            return false;
        }

        public static string GetLabel(this String input, string fieldFKEntityForFormCmb = "", string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            if (!string.IsNullOrWhiteSpace(defaultValue))
                return defaultValue;

            input = input.Replace("_", " ");
            input = input[0].ToString().ToUpper() + input.Substring(1);

            if (fieldFKEntityForFormCmb != "" && fieldFKEntityForFormCmb != "NULL" && input.LastIndexOf("ID") > 0)
                input = input.Substring(0, input.LastIndexOf("ID"));

            string str = input[0].ToString();
            for (int i = 1; i < input.Length - 1; i++)
            {
                bool currentCharIsUpper = char.IsUpper(input[i]);
                bool nextCharIsUpper = char.IsUpper(input[i + 1]);

                if (currentCharIsUpper && !nextCharIsUpper)
                {
                    str = str.Trim();
                    str += " " + input[i].ToString();
                }
                else if (!currentCharIsUpper && nextCharIsUpper)
                {
                    str = str.Trim();
                    str += input[i].ToString() + " ";
                }
                else
                {
                    str = str.Trim();
                    str += input[i].ToString();
                }
            }
            str += input[input.Length - 1].ToString();
            return str;
        }

        public static string GetImageURL(this String input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            return input.Replace("~", ConfigurationManager.AppSettings["ImagesURLPrefix"]);
        }

        public static List<T> ItemsToList<T>(params T[] items)
        {
            var list = new List<T>();
            if (items != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    list.Add(items[i]);
                }
            }
            return list;
        }

        public static double DistancebetweenTwoPoingsInM(double geo1Latitude, double geo1Longitude, double geo2Latitude, double geo2Longitude)
        {
            double theta = geo1Longitude - geo2Longitude;
            double dist = Math.Sin(deg2rad(geo1Latitude)) * Math.Sin(deg2rad(geo2Latitude)) + Math.Cos(deg2rad(geo1Latitude)) * Math.Cos(deg2rad(geo2Latitude)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            return (dist * 60 * 1.1515) / 621.3711922;  //miles to Ms
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad * 180.0 / Math.PI);
        }

        public static string TruncateString(string str, int maxLength = 120)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length <= maxLength)
                return str;
            return str.Substring(0, maxLength) + "...";
        }

        public static string TruncateHTMLString(string htmlStr, int maxLength = 120)
        {
            var innerText = StripHTML(htmlStr);
            return TruncateString(innerText, maxLength);
        }

        public static string StripHTML(string source)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(source);
                return HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
            }
            catch
            {
                return source;
            }
        }

        public static long? NullIfZero(long? value)
        {
            if (value == 0)
                return null;
            return value;
        }

        public static decimal? NullIfZero(decimal? value)
        {
            if (value == 0)
                return null;
            return value;
        }

        public static int? NullIfZero(int? value)
        {
            if (value == 0)
                return null;
            return value;
        }

        public static long? DefaultIfZeroOrNULL(long? value, long? defaultValue)
        {
            if (!value.HasValue || value == 0)
                return defaultValue;
            return value;
        }

        public static long? DefaultIfZeroOrNULL(long value, long? defaultValue)
        {
            if (value == 0)
                return defaultValue;
            return value;
        }

        public static long DefaultIfZeroOrNULL(long value, long defaultValue)
        {
            if (value == 0)
                return defaultValue;
            return value;
        }

        public static string ToUniversalPhoneNumber(string phoneNumber, string countryPhoneISO)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Trim();
                if (!phoneNumber.StartsWith("+"))
                {
                    if (phoneNumber.StartsWith("00"))
                    {
                        phoneNumber = "+" + phoneNumber.Substring(2);
                    }
                    else if (!string.IsNullOrWhiteSpace(countryPhoneISO))
                    {
                        if (phoneNumber.StartsWith("0"))
                            phoneNumber = phoneNumber.Substring(1);
                        phoneNumber = countryPhoneISO + phoneNumber;
                    }
                    else
                    {
                        phoneNumber = "+0" + phoneNumber; // +0 is the default phone prefix
                    }
                }
            }
            return phoneNumber;
        }

        public static Dictionary<string, string> ToDictionary(string key, string value)
        {
            var dic = new Dictionary<string, string>();
            dic.Add(key, value);
            return dic;
        }

        public static string Padding(this string str, int length, char ch, bool padLeft = true)
        {
            if (str == null)
                str = "";
            for (int i = str.Length; i < length; i++)
            {
                if (padLeft)
                    str = ch + str;
                else
                    str = str + ch;
            }
            return str;
        }

        private const string _empty = "empty";
        public static bool IsNullOrWhiteSpaceOrEmpty(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return true;
            if (str.ToLower() == _empty)
                return true;
            return false;
        }

        private static Regex arabicRegex = new Regex(@"\p{IsArabic}");
        public static bool IsArabicString(this string text)
        {
            return arabicRegex.IsMatch(text);
        }

        private static string arabicDivStart = "<div style='text-align: right;'>";
        private static string arabicDivEnd = "</div>";
        public static string HandleTextDirectionIntoDiv(string text)
        {
            if (text != null && !text.Contains(arabicDivStart) && IsArabicString(text))
            {
                return arabicDivStart + text + arabicDivEnd;
            }
            return text;
        }
    }
}
