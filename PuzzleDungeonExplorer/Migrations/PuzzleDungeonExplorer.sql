CREATE DATABASE PuzzleDungeonExplorer;
GO
USE PuzzleDungeonExplorer;

/***********************************************
    Create Table for PuzzleDungeonExplorer
************************************************/

-- Create the Dungeons table first
CREATE TABLE Dungeons (
    DungeonId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);
GO

-- Then create the Rooms table, which references Dungeons
CREATE TABLE Rooms (
    RoomId INT PRIMARY KEY IDENTITY(1,1),
    RoomName NVARCHAR(100),
    Description NVARCHAR(255),
    DungeonId INT FOREIGN KEY REFERENCES Dungeons(DungeonId)
);
GO

-- Create the Puzzles table, which references Rooms
CREATE TABLE Puzzles (
    PuzzleId INT PRIMARY KEY IDENTITY(1,1),
    PuzzleType NVARCHAR(50),
    Difficulty NVARCHAR(50),
    Question NVARCHAR(255),
    Solution NVARCHAR(100),
    RoomId INT FOREIGN KEY REFERENCES Rooms(RoomId)
);
GO

-- Create the Traps table, which references Rooms
CREATE TABLE Traps (
    TrapId INT PRIMARY KEY IDENTITY(1,1),
    TrapType NVARCHAR(50),
    Damage INT,
    DisarmCondition NVARCHAR(255),
    RoomId INT FOREIGN KEY REFERENCES Rooms(RoomId)
);
GO

-- Finally, create the Players table
CREATE TABLE Players (
    PlayerId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Health INT,
    Score INT
);
GO

-- Insert a Dungeons
INSERT INTO Dungeons (Name) VALUES ('Mysterious Dungeon');
GO

-- Insert a room
INSERT INTO Rooms (RoomName, Description, DungeonId) 
VALUES ('Dark Chamber', 'A dimly lit room with a strange atmosphere.', 1);
GO

-- Insert a puzzle
INSERT INTO Puzzles (PuzzleType, Difficulty, Question, Solution, RoomId)
VALUES ('Math', 'Hard', 'What is 12 * 12?', '144', 1);
GO

-- Insert a trap
INSERT INTO Traps (TrapType, Damage, DisarmCondition, RoomId)
VALUES ('Spike Trap', 20, 'Carefully step over', 1);
GO

-- Insert a player
INSERT INTO Players (Name, Health, Score) 
VALUES ('Adventurer', 100, 0);
GO

SELECT * FROM Dungeons;
SELECT * FROM Rooms;
SELECT * FROM Puzzles;
SELECT * FROM Traps;
SELECT * FROM Players;