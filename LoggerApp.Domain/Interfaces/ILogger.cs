using System.Collections.Generic;
using LoggerApp.Domain.Models;

namespace LoggerApp.Domain.Interfaces
{
    public interface ILogger
    {
        void Store(Log log);
        List<Log> GetAll();
    }
}