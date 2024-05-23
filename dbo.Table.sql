CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [PublishYear] DATETIME NULL, 
    [Price] DECIMAL NOT NULL, 
    [AuthorId] INT NOT NULL
)
