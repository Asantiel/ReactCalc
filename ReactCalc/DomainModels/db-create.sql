CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [Login] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [FIO] NVARCHAR(MAX) NULL
)

CREATE TABLE [dbo].[Operation]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FullName] NVARCHAR(MAX) NOT NULL
)


CREATE TABLE [dbo].[OperationResult]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [Author] BIGINT NOT NULL, 
    [Operation] BIGINT NOT NULL, 
    [InputData] NVARCHAR(50) NULL, 
    [Result] FLOAT NULL, 
    [ExecutionTime] INT NULL, 
    [ExecutionDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_OperationResult_ToUsers] FOREIGN KEY ([Author]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_OperationResult_ToOperation] FOREIGN KEY ([Operation]) REFERENCES [Operation]([Id])
)


CREATE TABLE [dbo].[UserFavoriteResult]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [User] BIGINT NOT NULL, 
    [Result] BIGINT NOT NULL, 
    CONSTRAINT [FK_UFR_ToOResultTable] FOREIGN KEY ([Result]) REFERENCES [OperationResult]([Id]), 
    CONSTRAINT [FK_UFR_ToUsers] FOREIGN KEY ([User]) REFERENCES [Users]([Id])
)
