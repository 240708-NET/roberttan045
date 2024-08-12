CREATE DATABASE BattleShipApp;
GO
USE BattleShipApp;

/***********************************************
    Create Table for Players
************************************************/

CREATE TABLE Players (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);
GO

SELECT * FROM Players;

/***********************************************
    Create Table for Games
************************************************/

CREATE TABLE Games (
    Id INT PRIMARY KEY IDENTITY,         
    Player1Id INT NOT NULL,              
    Player2Id INT NOT NULL,              
    IsPlayer1Turn BIT NOT NULL,          
    StartTime DATETIME2 NOT NULL,        
    CONSTRAINT FK_Games_Players_Player1Id FOREIGN KEY (Player1Id) REFERENCES Players(Id),
    CONSTRAINT FK_Games_Players_Player2Id FOREIGN KEY (Player2Id) REFERENCES Players(Id)
);
GO

SELECT * FROM Games;