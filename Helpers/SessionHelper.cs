using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Helpers
{

    public static class SessionHelper
    {
        public static object Get(string name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                return HttpContext.Current.Session[name];
            }
            return null;
        }

        public static void Remove(string name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session[name] != null)
                    HttpContext.Current.Session.Remove(name);
            }
        }

        public static void Set(string name, object value)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (value == null && HttpContext.Current.Session[name] != null)
                    HttpContext.Current.Session.Remove(name);
                else
                    HttpContext.Current.Session[name] = value;
            }
        }

        public static void ClearCurrentCache()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                HttpContext.Current.Response.Cache.SetNoStore();
            }
        }
        public static void ClearCurrentSession()
        {
            if (HttpContext.Current != null)
            {
                try
                {
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.Abandon();
                }
                catch { }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static string Home_IO
        {
            get
            {

                if (HttpContext.Current != null)
                {
                    try
                    {
                        return HttpContext.Current.Request.Url.LocalPath;
                    }
                    catch { }
                }
                return "";
            }
        }

        public static string Home_Request
        {
            get
            {

                if (HttpContext.Current != null)
                {
                    try
                    {
                        return HttpContext.Current.Request.Url.OriginalString;
                    }
                    catch { }
                }
                return "";
            }
        }




        public static string CurrentSessionID
        {
            get
            {
                string sessionID = "000000";
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    sessionID = HttpContext.Current.Session.SessionID;
                return sessionID;
            }
        }


        public static string CurrentIP
        {
            get
            {
                var GetLan = true;
                var visitorIPAddress = DefaultLocalIP;

                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];

                    if (string.IsNullOrEmpty(visitorIPAddress))
                        visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (string.IsNullOrEmpty(visitorIPAddress))
                        visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];

                    if (string.IsNullOrEmpty(visitorIPAddress))
                        visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                    if (string.IsNullOrEmpty(visitorIPAddress))
                        visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

                    if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
                    {
                        GetLan = true;
                        visitorIPAddress = string.Empty;
                    }

                    if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
                    {
                        //This is for Local(LAN) Connected ID Address
                        string stringHostName = Dns.GetHostName();
                        //Get Ip Host Entry
                        var ipHostEntries = Dns.GetHostEntry(stringHostName);
                        //Get Ip Address From The Ip Host Entry Address List
                        var arrIpAddress = ipHostEntries.AddressList;
                        var isIner = arrIpAddress.FirstOrDefault(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) != null;

                        if (isIner)
                        {
                            visitorIPAddress = DefaultLocalIP;
                        }
                        else
                        {
                            try
                            {
                                visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                            }
                            catch
                            {
                                try
                                {
                                    visitorIPAddress = arrIpAddress[0].ToString();
                                }
                                catch
                                {
                                    try
                                    {
                                        arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                        visitorIPAddress = arrIpAddress[0].ToString();
                                    }
                                    catch
                                    {
                                        visitorIPAddress = DefaultLocalIP;
                                    }
                                }
                            }
                        }
                    }
                    if (visitorIPAddress.StartsWith("192.168.") || visitorIPAddress == "::1")
                        visitorIPAddress = DefaultLocalIP;
                }


                if (string.IsNullOrWhiteSpace(visitorIPAddress))
                    visitorIPAddress = DefaultLocalIP;

                return visitorIPAddress.Trim();
            }
        }

        public static string CurrentChannel
        {
            get
            {
                return Get("CurrentChannel") as string;
            }
            set
            {
                Set("CurrentChannel", value);
            }
        }

        public static object GetPerRequest(string name)
        {
            var preRequestName = PerRequestPrefix + name + PerRequestSuffix;
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                return HttpContext.Current.Session[preRequestName];
            }

            return null;
        }

        public static void ClearPerRequest()
        {
            var preRequestKeysList = Get(PreRequestKeys) as List<string>;
            if (preRequestKeysList != null)
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    for (int i = 0; i < preRequestKeysList.Count; i++)
                    {
                        HttpContext.Current.Session.Remove(preRequestKeysList[i]);
                    }
                }
            }
        }

        public static void SetPerRequest(string name, object value)
        {
            var preRequestName = PerRequestPrefix + name + PerRequestSuffix;
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (value == null && HttpContext.Current.Session[preRequestName] != null)
                    HttpContext.Current.Session.Remove(preRequestName);
                else
                    HttpContext.Current.Session[preRequestName] = value;
            }
            var preRequestKeysList = Get(PreRequestKeys) as List<string>;
            if (preRequestKeysList == null)
                preRequestKeysList = new List<string>();
            if (!preRequestKeysList.Contains(preRequestName))
                preRequestKeysList.Add(preRequestName);
            Set(PreRequestKeys, preRequestKeysList);
        }

        public static bool Contains(string name)
        {
            return Get(name) != null;
        }

        private const string SuccessMessage = "__SuccessMessage";
        public static string GetSuccessMessage()
        {
            var msg = Get(SuccessMessage);
            if (msg != null)
                return msg.ToString();
            return null;
        }
        public static void SetSuccessMessage(string msg)
        {
            Set(SuccessMessage, msg);
        }
        public static void RemoveSuccessMessage()
        {
            Remove(SuccessMessage);
        }

        private const string FailMessage = "__FailMessage";
        public static string GetFailMessage()
        {
            var msg = Get(FailMessage);
            if (msg != null)
                return msg.ToString();
            return null;
        }
        public static void SetFailMessage(string msg)
        {
            Set(FailMessage, msg);
        }
        public static void RemoveFailMessage()
        {
            Remove(FailMessage);
        }

        public const string PerRequestPrefix = "PerRequestPrefix_";
        public const string PerRequestSuffix = "_PerRequestSuffix";
        public const string PreRequestKeys = "PreRequestKeys";
        private const string DefaultLocalIP = "127.0.0.1";
        private const string CurrentCountryISOStr = "CurrentCountryISO";
        private const string CurrentCountryTimeZoneStr = "CurrentCountryTimeZone";
        private const string CurrentIPStr = "CurrentIP";

        public static string CurrentCountryISO
        {
            get
            {
                var currentCountryISO = SessionHelper.Get(CurrentCountryISOStr) as string;
                //var currentCountryTimeZone = SessionHelper.Get(CurrentCountryTimeZoneStr) as string;
                //if (string.IsNullOrWhiteSpace(currentCountryISO))
                //{
                //    try
                //    {
                //        var ip = "";
                //        if (SessionHelper.CurrentIP != DefaultLocalIP)
                //            ip = SessionHelper.CurrentIP;

                //        var url = "http://freegeoip.net/json/" + ip;
                //        using (var client = new WebClient())
                //        {
                //            var jsonstring = client.DownloadString(url);
                //            dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
                //            if (dynObj.country_code != null)
                //            {
                //                currentCountryISO = dynObj.country_code.ToString().ToLower();
                //                currentCountryTimeZone = dynObj.time_zone.ToString().ToLower();
                //                SessionHelper.Set(CurrentCountryISOStr, currentCountryISO);
                //                SessionHelper.Set(CurrentCountryTimeZoneStr, currentCountryTimeZone);
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
                return currentCountryISO;
            }
        }

        public static string CurrentCountryTimeZone
        {
            get
            {
                var iso = CurrentCountryISO;
                return SessionHelper.Get(CurrentCountryTimeZoneStr) as string;
            }
        }
    }
}