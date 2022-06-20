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
CREATE PROCEDURE dbo.ReplyNote
	-- Add the parameters for the stored procedure here
	@NAME		NVARCHAR(25),
	@EMAIL		NVARCHAR(100),
	@TITLE		NVARCHAR(100),
	@POSTIP		NVARCHAR(15),
	@CONTENT	NTEXT,
	@PASSWORD	NVARCHAR(100),
	@ENCODING	NVARCHAR(10),
	@HOMEPAGE	NVARCHAR(100),
	@PARENTNUM	INT,
	@FILENAME	NVARCHAR(100),
	@FILESIZE	INT
AS

DECLARE		@MaxRefOrder	INT
DECLARE		@MaxRefAnswerNum	INT
DECLARE		@ParentRef			INT
DECLARE		@ParentStep			INT
DECLARE		@ParentRefOrder		INT

BEGIN TRAN
	UPDATE dbo.Notes SET ANSWERNUM = ANSWERNUM + 1 WHERE ID = @PARENTNUM;

	SELECT @MAXREFORDER = REFORDER, @MaxRefAnswerNum = ANSWERNUM FROM dbo.Notes
	WHERE 
		PARENTNUM = @PARENTNUM AND
		REFORDER = (SELECT MAX(REFORDER) FROM dbo.NOTES WHERE PARENTNUM = @PARENTNUM)

	IF @MaxRefOrder IS NULL
	BEGIN
		SELECT @MaxRefOrder = REFORDER FROM NOTES WHERE ID = @PARENTNUM
		SET @MAXREFANSWERNUM = 0
	END

	SELECT @PARENTREF = Ref, @PARENTSTEP = STEP FROM dbo.Notes WHERE ID = @PARENTNUM

	UPDATE dbo.Notes SET REFORDER = REFORDER + 1
	WHERE REF = @PARENTREF AND REFORDER > (@MaxRefOrder + @MaxRefAnswerNum)

	INSERT INTO dbp.Notes
	(	
		NAME, EMAIL, TITLE, POSTIP, CONTENT, PASSWORD, ENCODING, 
		HOMEPAGE, REF, STEP, REFORDER, PARENTNUM, FILENAME, FILESIZE
	)
	VALUES 
	(
		@NAME, @EMAIL, @TITLE, @POSTIP, @CONTENT, @PASSWORD, @ENCODING, @HOMEPAGE, @ParentRef, @ParentStep +1,
		@MaxRefOrder+ @MaxRefAnswerNum + 1, @PARENTNUM, @FILENAME, @FILESIZE
	)
COMMIT TRAN
GO
