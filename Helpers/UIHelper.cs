using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace Helpers
{
    public static class UIHelper
    {

        public static string MapPath(string path)
        {
            return System.Web.HttpContext.Current.Server.MapPath(path);
        }

        public static string GetCookieLanguage()
        {
            var lang = arLang;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.Cookies["EduLegendlang"] == null)
                {
                    SetThreadLanguage(lang);
                    SetThreadDateTimeFormat(DateTimeHelper.DATEFORMATE_ddMMyyyy, DateTimeHelper.dateFormatedd_MMM_yyyy_hhMMss);
                }

                var cookieLang = System.Web.HttpContext.Current.Request.Cookies["EduLegendlang"].Value;
                if (!string.IsNullOrWhiteSpace(cookieLang))
                {
                    lang = cookieLang.ToString();
                }
            }
            return lang;
        }
        public static bool ChangeCookieLanguage( string lang)
        {
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.Cookies["EduLegendlang"] == null)
                {
                    SetThreadLanguage(lang);
                    SetThreadDateTimeFormat(DateTimeHelper.DATEFORMATE_ddMMyyyy, DateTimeHelper.dateFormatedd_MMM_yyyy_hhMMss);
                }

                System.Web.HttpContext.Current.Request.Cookies["EduLegendlang"].Value= lang;
            }
            return true;
        }

        public static void SetThreadDateTimeFormat(string dateTimeFormate, string longDateTimeFormate)
        {
            CultureInfo culture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = dateTimeFormate;
            culture.DateTimeFormat.LongDatePattern = longDateTimeFormate;
            culture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static void CheckLoggedUser()
        {
            //bool isAuth = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            //if (!isAuth)
            //{
            //    var userID = UIHelper.CurrentUserID;
            //    if (userID != 0)
            //    {
            //        FormsAuthentication.SetAuthCookie(userID.ToString(), true);
            //    }
            //}
        }

        public static void SetThreadLanguage(string lang)
        {
            HttpCookie cook = new HttpCookie("EduLegendlang", lang);
            cook.Expires = DateTime.Now.AddDays(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cook);
        }
        public static List<T> GetAllControls<T>(ControlCollection collection) where T : Control
        {
            List<T> controls = new List<T>();
            foreach (Control c in collection)
            {
                if (c is T)
                {
                    controls.Add((T)c);
                }
                else if (c.Controls != null && c.Controls.Count > 0)
                {
                    var lst = GetAllControls<T>(c.Controls);
                    if (lst != null)
                        controls.AddRange(lst);
                }
            }
            if (controls.Count > 0)
                return controls;
            return null;
        }

        public static string GetFromRequestOrRouteData(string key)
        {
            string value = null;
            // 2. try get from the request
            if (HttpContext.Current.Request != null)
            {
                // 2.a. try get from the request route data
                if (HttpContext.Current.Request.RequestContext != null && HttpContext.Current.Request.RequestContext.RouteData != null && HttpContext.Current.Request.RequestContext.RouteData.Values.ContainsKey(key))
                {
                    value = HttpContext.Current.Request.RequestContext.RouteData.Values[key].ToString();
                }
                // 2.b. try get from the request query string
                else if (HttpContext.Current.Request[key] != null)
                {
                    value = HttpContext.Current.Request[key].ToString();
                }
            }
            return value;
        }

        /// <summary>
        /// Returns a site relative HTTP path from a partial path starting out with a ~.
        /// Same syntax that ASP.Net internally supports but this method can be used
        /// outside of the Page framework.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="originalUrl">Any Url including those starting with ~</param>
        /// <returns>relative url</returns>
        private static string ResolveUrl(string originalUrl, string appName)
        {
            if (originalUrl == null)
                return null;

            // *** Absolute path - just return
            if (originalUrl.IndexOf("://") != -1)
                return originalUrl;

            // *** Fix up image path for ~ root app dir directory
            if (originalUrl.StartsWith("~"))
            {
                var newUrl = "";
                if (HttpContext.Current != null)
                {
                    if (!string.IsNullOrWhiteSpace(appName))
                        appName = "/" + appName + "/";



                    var rootURL = ConfigurationManager.AppSettings["RootURL"];
                    if (rootURL != string.Empty && rootURL != "~")
                    {
                        newUrl = rootURL + (appName + originalUrl.Substring(1)).Replace("//", "/");
                    }
                    else
                    {
                        newUrl = HttpContext.Current.Request.ApplicationPath + (appName +
                              originalUrl.Substring(1)).Replace("//", "/");
                    }
                }
                else
                    // *** Not context: assume current directory is the base directory
                    //throw new ArgumentException("Invalid URL: Relative URL not allowed.");
                    newUrl = originalUrl;

                // *** Just to be sure fix up any double slashes
                return newUrl;
            }

            return originalUrl;
        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <param name="forceHttps">if true forces the url to use https</param>
        /// <returns></returns>
        private static string ResolveServerUrl(string serverUrl, bool forceHttps, string appName = "")
        {
            // *** Is it already an absolute Url?
            if (serverUrl == null)
                return string.Empty;

            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;


            // *** Start by fixing up the Url an Application relative Url
            var newUrl = ResolveUrl(serverUrl, appName);

            if (HttpContext.Current != null)
            {
                if (!newUrl.StartsWith("http"))
                {
                    var originalUri = HttpContext.Current.Request.Url;
                    newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                             "://" + originalUri.Authority + newUrl;
                }
            }

            return newUrl;
        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// It work like Page.ResolveUrl, but adds these to the beginning.
        /// This method is useful for generating Urls for AJAX methods
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <returns></returns>
        public static string ResolveServerUrl(string serverUrl, string appName = "")
        {
            return ResolveServerUrl(serverUrl, false, appName);
        }


        public static string MapImagePath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && path.StartsWith("~"))
                path = ConfigurationManager.AppSettings["ImagesPhysicalPath"] + path.Substring(1);
            return MapPath(path);
        }

        public static string ReverseMapImagePath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && path.StartsWith(ConfigurationManager.AppSettings["Domain"]))
                path = "~" + path.Substring(ConfigurationManager.AppSettings["Domain"].Length);
            return MapPath(path);
        }

        public static string ResolveDomainURL(string url, string appName = "")
        {
            if (!string.IsNullOrWhiteSpace(url) && url.StartsWith("~"))
            {
                if (!string.IsNullOrWhiteSpace(appName))
                    appName = "/" + appName + "/";
                url = ConfigurationManager.AppSettings["Domain"] + (appName + url.Substring(1)).Replace("//", "/");
            }
            return url;
        }

        //public static long CurrentUserID
        //{
        //    get
        //    {
        //        long uid = 0;
        //        if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
        //        {
        //            var cookieUID = System.Web.HttpContext.Current.Request.Cookies["ui"];
        //            if (cookieUID != null && !string.IsNullOrWhiteSpace(cookieUID.Value))
        //                long.TryParse(StringCipher.Decrypt(cookieUID.Value, SecurityHelper.APPLICATION_KEY_CODE), out uid);
        //        }
        //        return uid;
        //    }
        //    set
        //    {
        //        if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
        //        {
        //            if (value != 0)
        //            {
        //                HttpCookie cook = new HttpCookie("ui", StringCipher.Encrypt(value.ToString(), SecurityHelper.APPLICATION_KEY_CODE));
        //                cook.Expires = DateTime.Now.AddDays(1);
        //                System.Web.HttpContext.Current.Response.Cookies.Add(cook);
        //            }
        //            else
        //            {
        //                var cookieUID = System.Web.HttpContext.Current.Request.Cookies["ui"];
        //                if (cookieUID != null && !string.IsNullOrWhiteSpace(cookieUID.Value))
        //                {
        //                    cookieUID.Expires = DateTime.Now.AddDays(-1);
        //                    System.Web.HttpContext.Current.Response.Cookies.Add(cookieUID);
        //                }
        //            }
        //        }
        //    }
        //}

        //public static Language GetCookieLanguageEnum()
        //{
        //    var lang = GetCookieLanguage().ToLower();
        //    if (lang == arLang)
        //        return Language.Ar;
        //    return Language.En;
        //}

        private const string arLang = "ar";
        private const string enLang = "en";

        public static string MenuMenifiedClass()
        {
            var mclsCookie = System.Web.HttpContext.Current.Request.Cookies["mcls"];
            if (mclsCookie != null)
                return mclsCookie.Value;
            return "page-sidebar-minified";
        }

        public static string HideStringPart(string str, int percentage)
        {
            var returnStr = "";
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Contains("@"))
                {
                    var parts = str.Split('@');
                    var hidePart = parts[0].Substring(0, (int)Math.Ceiling(parts[0].Length * percentage / 100.0));
                    var part1 = parts[0].Replace(hidePart, "**");
                    returnStr = part1 + "@" + parts[1];
                }
                else
                {
                    var hidePart = str.Substring(0, (int)Math.Ceiling(str.Length * percentage / 100.0));
                    returnStr = str.Replace(hidePart, "**");
                }
            }
            return returnStr;
        }

        public static void ClearCache(HttpResponseBase Response)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}
