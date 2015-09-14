CREATE TABLE [dbo].[tbGps]
(
	[Id] BIGINT identity(1,1) NOT NULL PRIMARY KEY, 
	[OrgCode] NVARCHAR(100) NULL,
	[AppCode] NVARCHAR(100) NULL,
    [UserId] NVARCHAR(50) NULL, 
    [Latitude] NVARCHAR(50) NULL, 
    [Longitude] NVARCHAR(50) NULL, 
    [LocationTime] DATETIME NULL, 
    [Accuracy] NVARCHAR(50) NULL, 
    [Altitude] NVARCHAR(50) NULL, 
    [Speed] NVARCHAR(50) NULL
)
