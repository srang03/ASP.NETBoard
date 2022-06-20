-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		己快
-- Create date: 2022.06.17
-- Description:	Note 臂 积己
-- =============================================
CREATE PROCEDURE dbo.WriteNote	(
	@NAME			NVARCHAR(25),
	@EMAIL			NVARCHAR(100),
	@TITLE			NVARCHAR(100),			
	@POSTIP			NVARCHAR(15),
	@CONTENT		NTEXT,			
	@PASSWORD		NVARCHAR(50),
	@ENCODING		NVARCHAR(10),
	@HOMEPAGE		NVARCHAR(100),
	@FILENAME		NVARCHAR(100),
	@FILESIZE		INT
	)
AS
	DECLARE @MaxRef INT
	SELECT @MaxRef = Max(REF) FROM dbo.Notes

	IF @MaxRef is NULL
		SET @MaxRef = 1;
	ELSE 
		SET @MaxRef = @MaxRef + 1;

BEGIN  TRAN
	INSERT INTO dbo.Notes (NAME, EMAIL, TITLE, POSTIP, CONTENT, PASSWORD, ENCODING, HOMEPAGE, FILENAME, FILESIZE, REF) 
	VALUES (@NAME, @EMAIL, @TITLE, @POSTIP, @CONTENT, @PASSWORD, @ENCODING, @HOMEPAGE, @FILENAME, @FILESIZE, @MaxRef)
COMMIT TRAN
GO
