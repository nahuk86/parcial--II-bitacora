using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerApp.Domain.Interfaces;
using LoggerApp.Domain.Models;

namespace LoggerApp.DAL.Loggers
{
    public class SqlLogger : ILogger
    {
        private readonly string _connectionString;

        public SqlLogger(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Store(Log log)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Logs (Message, Severity) VALUES (@message, @severity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@message", log.Message);
                command.Parameters.AddWithValue("@severity", log.LogSeverity.ToString());
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Log> GetAll()
        {
            List<Log> logs = new List<Log>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Message, Severity FROM Logs";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string message = reader.GetString(0);
                    Severity severity = (Severity)Enum.Parse(typeof(Severity), reader.GetString(1));
                    logs.Add(new Log(message, severity));
                }
            }

            return logs;
        }
    }
}
