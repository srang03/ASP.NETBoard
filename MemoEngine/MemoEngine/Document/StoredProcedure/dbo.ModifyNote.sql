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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ModifyNote
	@ID				INT,
	@NAME			NVARCHAR(25),
	@EMAIL			NVARCHAR(100),
	@TITLE			NVARCHAR(100),
	@MODIFYIP		NVARCHAR(15),
	@CONTENT		NTEXT,
	@PASSWORD		NVARCHAR(30),
	@ENCODING		NVARCHAR(10),
	@HOMEPAGE		NVARCHAR(100),
	@FILENAME		NVARCHAR(100),
	@FILESIZE		INT

AS
BEGIN TRAN
	DECLARE @Cnt	INT

	SELECT @Cnt = COUNT(*) FROM dbo.Note 
	WHERE ID = @ID AND PASSWORD = @PASSWORD

	IF @Cnt > 0
	BEGIN
		UPDATE dbo.Notes SET 
		NAME = @NAME, EMAIL = @EMAIL, TITLE = @TITLE,
		MODIFYIP = @MODIFYIP, MODIFYDATE = GETDATE(),
		CONTENT = @CONTENT, ENCODING = @ENCODING,
		HOMEPAGE = @HOMEPAGE, FILENAME = @FILENAME,
		FILESIZE = @FILESIZE
		WHERE ID = @ID
	SELECT '1'
	END

	ELSE
	SELECT '0'

COMMIT TRAN
GO
