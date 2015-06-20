using System;
using System.Diagnostics;

namespace CommonUtils
{
    public class EventLogger : ILogger
    {
        public void LogMessage(Exception exception)
        {

            var log = new EventLog();

            string sSource = "ECommerce application";
            string sLog = "Application";
            string sEvent = exception.InnerException.Message;

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent);
            EventLog.WriteEntry(sSource, sEvent,
                EventLogEntryType.Error, 234);
        }
    }
}
