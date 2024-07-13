using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerApp.Domain.Models;
using LoggerApp.Domain.Interfaces;


namespace LoggerApp.BLL.Loggers

{
    public class EmailLoggerDecorator : ILogger
    {
        private readonly ILogger _logger;

        public EmailLoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public void Store(Log log)
        {
            _logger.Store(log);
            CheckAndSendEmail(log.Message);
        }

        public List<Log> GetAll()
        {
            return _logger.GetAll();
        }

        private void CheckAndSendEmail(string message)
        {
            if (message.Contains("CriticalError"))
            {
                System.Console.WriteLine($"Enviando email a soporteNivel1@email.com: {message}");
            }

            if (message.Contains("FatalError"))
            {
                System.Console.WriteLine($"Enviando email a soporteNivel1@email.com: {message}");
                System.Console.WriteLine($"Enviando copia a soporteNivel2@email.com: {message}");
            }
        }
    }
}
