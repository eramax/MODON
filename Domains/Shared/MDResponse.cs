using System.Collections.Generic;

namespace System
{
    public class StyleType
    {
        public const string Danger = "danger",
        Success = "success",
        Warning = "warning",
        Information = "info";
    }
    public class Alert
    {
        public StyleType Style { get; set; }
        public string Message { get; set; }
    }
    public interface IMDResponse 
    {
        List<string> Errors { get; set; }
        List<Alert> Alerts { get; set; }
        bool HasNoErrors { get; }
        bool HasErrors { get; }
        bool HasNoAlerts { get; }
        bool HasAlerts { get; }
        void Error(string ex);
        void Error(Exception ex , object obj = null);
        void Error();
    }
    public class MDResponse : IMDResponse
    {
        public List<string> Errors { get; set; }
        public List<Alert> Alerts { get; set; }
        public bool HasNoErrors => Errors == null;
        public bool HasErrors => Errors != null;
        public bool HasNoAlerts => Alerts == null;
        public bool HasAlerts => Alerts != null;
        public static List<Action<Exception, object>> Handlers { get; set; }

        public static void RegisterErrorHandler(Action<Exception, object> handler)
        {
            if (Handlers == null) Handlers = new List<Action<Exception, object>>();
            Handlers.Push(handler);
        }

        public void Error(string ex)
        {
            if (Errors == null) Errors = new List<string>();
            Errors.Add(ex);
        }
        public void Error(Exception ex, object obj = null)
        {
            Error("فشلت العملية");
            CallErrorHandlers(ex, obj);
        }
        public void Error()
        {
            Error("فشلت العملية");
        }
        public static IMDResponse New()
        {
            return new MDResponse();
        }
        public static void CallErrorHandlers(Exception ex, object obj = null)
        {
            if (Handlers != null) foreach (var x in Handlers) x(ex, obj);
        }
    }
}
