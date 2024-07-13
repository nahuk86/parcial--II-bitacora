using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp.Domain.Models
{
    public enum Severity
    {
        Info,
        Warning,
        Error
    }

    public class Log
    {
        public string Message { get; set; }
        public Severity LogSeverity { get; set; }

        public Log(string message, Severity severity)
        {
            Message = message;
            LogSeverity = severity;
        }
    }
}
