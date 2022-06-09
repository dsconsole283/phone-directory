CREATE TABLE [dbo].[Personnel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DepartmentId] INT NOT NULL, 
    [TitleId] INT NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [PhoneMain] NVARCHAR(50) NULL, 
    [PhoneMobile] NVARCHAR(11) NULL, 
    [Extension] NVARCHAR(5) NULL, 
    [Notes] NVARCHAR(MAX) NULL, 
    [IsExec] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [Department FK] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]), 
    CONSTRAINT [Title FK] FOREIGN KEY (TitleId) REFERENCES [Titles](Id)
)
