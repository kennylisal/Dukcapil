IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DukcapilDb')
BEGIN
    CREATE DATABASE DukcapilDb;
END
GO