using System;
using System.Configuration;
using LoggerApp.BLL.Loggers;
using LoggerApp.Domain.Interfaces;
using LoggerApp.Domain.Models;
using global::LoggerApp.Domain.Emus;

namespace LoggerApp.UI
{
        class Program
        {
            static void Main(string[] args)
            {
                // Leer las cadenas de conexión desde el archivo de configuración
                string sqlConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                string filePath = ConfigurationManager.ConnectionStrings["TXT"].ConnectionString;

                // Crear una instancia de LoggerFactory
                LoggerFactory loggerFactory = new LoggerFactory();

                // Crear instancias de los loggers utilizando la fábrica
                ILogger sqlLogger = loggerFactory.CreateLogger(LoggerType.SQL, sqlConnectionString);
                ILogger fileLogger = loggerFactory.CreateLogger(LoggerType.File, filePath);

                // Envolver solo uno de los loggers con el decorador de email
                ILogger emailLogger = new EmailLoggerDecorator(sqlLogger);

                bool continueLogging = true;

                while (continueLogging)
                {
                    // Leer el mensaje del usuario
                    System.Console.WriteLine("Ingrese el mensaje del log:");
                    string message = System.Console.ReadLine();

                    // Crear el log con severidad Info (puedes cambiar esto si necesitas diferentes severidades)
                    Log log = new Log(message, Severity.Info);

                    // Almacenar el log en ambos loggers
                    emailLogger.Store(log); // Decorador con envío de email
                    fileLogger.Store(log);  // Logger simple

                    // Preguntar al usuario si quiere continuar ingresando más logs
                    System.Console.WriteLine("¿Desea ingresar otro log? (s/n)");
                    string response = System.Console.ReadLine();
                    continueLogging = response.Equals("s", StringComparison.OrdinalIgnoreCase);
                }

                // Recuperar y mostrar todos los logs de ambos loggers
                var sqlLogs = emailLogger.GetAll();
                var fileLogs = fileLogger.GetAll();

                System.Console.WriteLine("SQL Logs:");
                foreach (var l in sqlLogs)
                {
                    System.Console.WriteLine($"{l.LogSeverity}: {l.Message}");
                }

                System.Console.WriteLine("File Logs:");
                foreach (var l in fileLogs)
                {
                    System.Console.WriteLine($"{l.LogSeverity}: {l.Message}");
                }

                // Añade esta línea para evitar que la consola se cierre automáticamente
                System.Console.WriteLine("Presiona cualquier tecla para cerrar...");
                System.Console.ReadLine();
            }
        }
    }
