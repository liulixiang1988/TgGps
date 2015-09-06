CREATE TABLE [dbo].[tbGps]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [UserId] VARCHAR(50) NULL, 
    [Latitude] VARCHAR(50) NULL, 
    [Longitude] VARCHAR(50) NULL, 
    [LocationTime] DATETIME NULL, 
    [Accuracy] VARCHAR(50) NULL, 
    [Altitude] VARCHAR(50) NULL, 
    [Speed] VARCHAR(50) NULL
)
