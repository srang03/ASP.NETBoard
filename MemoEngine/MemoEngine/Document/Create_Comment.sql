CREATE TABLE dbo.NoteComments
(
	ID			INT		IDENTITY(1, 1)
								NOT NULL PRIMARY KEY,	
	BOARDNAME	VARCHAR(50)		NULL,
	BOARDID		INT				NOT NULL,
	NAME		NVARCHAR(50)	NOT NULL,
	OPINION		NVARCHAR(1000)  NOT NULL,
	POSTDATE	SMALLDATETIME	DEFAULT(GetDate()),
	PASSWORD	NVARCHAR(50)	NOT NULL
)
GO