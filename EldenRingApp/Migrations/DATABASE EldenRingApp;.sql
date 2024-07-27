CREATE DATABASE EldenRingApp;
GO
USE EldenRingApp;

/***********************************************
    Create Table for EldenRing
************************************************/
CREATE TABLE CHARACTER 
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Class NVARCHAR(100) NOT NULL,
    Level INT NOT NULL
);
GO

/************************************************
   Populate Tables
*************************************************/
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish1', 'Hero', 7);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish2', 'Bandit', 5);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish3', 'Astrologer/Mage', 6);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish4', 'Warrior', 8);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish5', 'Prisoner', 9);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish6', 'Confessor', 10);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish7', 'Wretch', 1);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish8', 'VagaBond/Knight', 9);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish9', 'Prophet', 7);
INSERT INTO Characters (Name, Class, Level) VALUES ('Tarnish10', 'Samurai', 9);

SELECT * FROM [EldenRingApp].[dbo].[Characters];