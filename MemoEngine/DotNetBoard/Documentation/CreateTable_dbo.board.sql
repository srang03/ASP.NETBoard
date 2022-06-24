CREATE TABLE dbo.Board 
(
	ID				INT			IDENTITY(1, 1) PRIMARY KEY,
	CATEGORY		VARCHAR(10)	NOT NULL,
	TITLE			VARCHAR(50) NOT NULL,
	CONTENT			TEXT		NOT NULL,
	FILE_NAME		VARCHAR(50) NULL,
	CREATED_DATE	DATETIME	DEFAULT(GETDATE()),
	CREATED_IP		VARCHAR(15)	NOT NULL,
	MODIFIED_DATE	DATETIME	DEFAULT(GETDATE()),
	MODIFIED_IP		VARCHAR(15)	NULL
)