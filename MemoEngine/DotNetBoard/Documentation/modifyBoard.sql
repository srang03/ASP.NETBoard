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
-- Author:		성우
-- Create date: 2022.06.24
-- Description:	user 게시판 글 수정 프로시저
-- =============================================
CREATE PROCEDURE modifyBoard(
	@ID				INT,
	@USER_ID		INT,
	@CATEGORY		VARCHAR(10),
	@TITLE			VARCHAR(50),
	@CONTENT		TEXT,
	@FILENAME		VARCHAR(50),
	@MODIFIED_IP	VARCHAR(15),
	@MODIFIED_DATE	DATETIME
)

AS
BEGIN TRAN
	UPDATE dbo.Board SET CATEGORY = @CATEGORY, TITLE = @TITLE, CONTENT = @CONTENT, 
	FILE_NAME = @FILENAME, MODIFIED_IP = @MODIFIED_IP, MODIFIED_DATE = GETDATE()
	WHERE ID = @ID AND USER_ID = @USER_ID;
COMMIT TRAN
GO
