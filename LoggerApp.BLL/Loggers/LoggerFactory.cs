using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerApp.Domain.Interfaces;
using LoggerApp.DAL.Loggers;
using LoggerApp.Domain.Models;
using LoggerApp.Domain.Emus;



namespace LoggerApp.BLL.Loggers
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(LoggerType type, string connectionStringOrPath)
        {
            switch (type)
            {
                case LoggerType.SQL:
                    return new EmailLoggerDecorator(new SqlLogger(connectionStringOrPath));
                case LoggerType.File:
                    return new EmailLoggerDecorator(new FileLogger(connectionStringOrPath));
                default:
                    throw new ArgumentException("Invalid logger type");
            }
        }
    }
}
