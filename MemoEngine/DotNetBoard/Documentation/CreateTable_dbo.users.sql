CREATE TABLE dbo.Users (
	ID				INT			IDENTITY(1, 1)			PRIMARY KEY,
	EMAIL			VARCHAR(50)	NOT NULL,
	NAME			VARCHAR(50)	NOT NULL,
	PASSWORD		VARCHAR(100)	NOT NULL,
	RE_PASSWORD		VARCHAR(100)	NOT NULL,
	CREATED_DATE	DATETIME		Default(GetDate()),
	CREATED_IP		VARCHAR(15)		NOT NULL,
	MODIFIED_DATE	DATETIME		NULL,
	MODIFIED_IP		VARCHAR(15)		NULL,
	IS_DELETED		VARCHAR(2)		Default 'N'
);