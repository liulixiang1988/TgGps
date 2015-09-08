CREATE TABLE [dbo].[tbUser]
(
	[Id] BIGINT identity(1,1) NOT NULL PRIMARY KEY, 
    [OrgCode] NVARCHAR(200) NULL, 
    [UserId] NVARCHAR(20) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(200) NULL, 
    [IsActive] CHAR(10) NULL, 
    [IsSuperuser] BIT NULL, 
    [IsStuff] BIT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [LastLogin] DATETIME NULL
)
