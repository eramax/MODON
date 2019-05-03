using System;
using NLog;

namespace Helpers
{
    public static class MDLog  
    {
        private static Logger Log { get; } = LogManager.GetCurrentClassLogger();

        public static void Error(Exception x , object o = null )
        {
            if (o == null) Log.Error(x.Message);
            else Log.Error(x.Message, o.ToJson());
        }

        public static void Info(Exception x, object o = null)
        {
            if (o == null) Log.Info(x.Message);
            else Log.Info(x.Message, o.ToJson());
        }


    }
}
