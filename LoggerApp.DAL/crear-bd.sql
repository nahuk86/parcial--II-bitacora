-- Script para crear la base de datos
CREATE DATABASE Bitacora_LegacyIV;
GO

-- Usar la base de datos recién creada
USE Bitacora_LegacyIV;
GO

-- Crear la tabla Logs
CREATE TABLE Logs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Message NVARCHAR(MAX) NOT NULL,
    Severity NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Insertar datos de ejemplo
INSERT INTO Logs (Message, Severity) VALUES 
('System started successfully', 'Info'),
('User logged in', 'Info'),
('User failed to login', 'Warning'),
('Database connection lost', 'Error');
GO
