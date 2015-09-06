CREATE TABLE [dbo].[tbUser]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [OrgCode] VARCHAR(200) NULL, 
    [UserId] VARCHAR(20) NULL, 
    [UserName] VARCHAR(50) NULL, 
    [Password] VARCHAR(200) NULL, 
    [IsActive] CHAR(10) NULL, 
    [IsSuperuser] BIT NULL, 
    [IsStuff] BIT NULL, 
    [Email] VARCHAR(50) NULL, 
    [LastLogin] DATETIME NULL
)
