CREATE TABLE [dbo].[Personnel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DepartmentId] INT NULL, 
    [TitleId] INT NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [PhoneMain] NCHAR(11) NULL, 
    [PhoneMobile] NCHAR(11) NULL, 
    [Extension] NCHAR(5) NULL, 
    [Notes] NVARCHAR(MAX) NULL, 
    [IsExec] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [Department FK] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]), 
    CONSTRAINT [Title FK] FOREIGN KEY (TitleId) REFERENCES [Titles](Id)
)
