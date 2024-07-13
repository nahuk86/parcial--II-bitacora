using System;
using System.Collections.Generic;
using System.IO;
using LoggerApp.Domain.Interfaces;
using LoggerApp.Domain.Models;


namespace LoggerApp.DAL.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Store(Log log)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"{log.LogSeverity}: {log.Message}");
            }
        }

        public List<Log> GetAll()
        {
            List<Log> logs = new List<Log>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        Severity severity = (Severity)Enum.Parse(typeof(Severity), parts[0]);
                        logs.Add(new Log(parts[1], severity));
                    }
                }
            }

            return logs;
        }
    }
}