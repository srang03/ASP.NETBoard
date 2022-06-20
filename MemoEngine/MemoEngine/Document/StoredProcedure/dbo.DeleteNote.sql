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
CREATE PROCEDURE dbo.DeleteNote
	@ID				INT,
	@PASSWORD		NVARCHAR(50)
AS
BEGIN TRAN
	DECLARE		@cnt	INT
	SELECT @cnt = COUNT(*) FROM dbo.Notes WHERE ID = @ID AND PASSWORD = @PASSWORD
	
	IF(@cnt > 0)
		BEGIN 
			DECLARE		@AnswerNum		INT
			DECLARE		@RefOrder		INT
			DECLARE		@Ref			INT
			DECLARE		@ParentNum		INT

			SELECT      @AnswerNum = ANSWERNUM,		@RefOrder = REFORDER,
						@Ref = Ref,					@ParentNum = PARENTNUM
						FROM dbo.Notes WHERE ID = @ID
			
			IF @AnswerNum = 0
			BEGIN
				IF @RefOrder > 0 
				BEGIN
					UPDATE dbo.Notes SET REFORDER = REFORDER - 1
					WHERE REF = @Ref AND REFORDER > @RefORder;

					UPDATE dbo.Notes SET ANSWERNUM = ANSWERNUM -1 WHERE ID = @ParentNum
				END
				DELETE FROM dbo.Notes WHERE ID = @ID;
				DELETE FROM dbo.Notes WHERE ID = @ParentNum AND MODIFYIP = N'((DELETED))' AND ANSWERNUM = 0;
			END
			ELSE
			BEGIN
				UPDATE dbo.Notes SET 
				NAME = N'(Unknown)', EMAIL = '', PASSWORD ='',
				TITLE = N'삭제된 글',
				CONTENT = N'현재 답변이 포함되어 있어 내용만 삭제되었습니다',
				MODIFYIP = N'((DELETED))', FileName = '',
				FILESIZE = 0, COMMENTCOUNT = 0
				WHERE ID = @ID
			END
		END
	ELSE
		BEGIN
			RETURN 0
		END
	
COMMIT TRAN
GO
