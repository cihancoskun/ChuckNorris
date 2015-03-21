using System;
using System.Web;

using NLog;

namespace App.Infrastructure.Logging
{
    public class LogUtility
    {
        public static string BuildExceptionMessage(Exception ex)
        {
            Exception logException = ex;
            if (ex.InnerException != null)
                logException = ex.InnerException;
             
            string strErrorMsg = Environment.NewLine + "Error in Path :" + HttpContext.Current.Request.Path;

            // Get the QueryString along with the Virtual Path
            strErrorMsg = Environment.NewLine + "Raw Url :" + HttpContext.Current.Request.RawUrl;

            // Get the error message
            strErrorMsg = Environment.NewLine + "Message :" + logException.Message;

            // Source of the message
            strErrorMsg = Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error

            strErrorMsg = Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            strErrorMsg = Environment.NewLine + "TargetSite :" + logException.TargetSite;

            return strErrorMsg;
        }

        public static LogEventInfo GetLogEvent(Logger logger, LogLevel level, Exception exception, string format, object[] args)
        {
            string assemblyProp = string.Empty;
            string classProp = string.Empty;
            string methodProp = string.Empty;
            string messageProp = string.Empty;
            string innerMessageProp = string.Empty;

            var logEvent = new LogEventInfo
                (level, logger.Name, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;

                try
                {
                    classProp = exception.TargetSite.DeclaringType.FullName;
                    methodProp = exception.TargetSite.Name;
                }
                catch (Exception)
                {
                    // ignored
                }

                messageProp = exception.Message;
                logEvent.Exception = exception;

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.InnerException.Message;
                }
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }
    }
}
