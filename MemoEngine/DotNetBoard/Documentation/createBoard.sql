USE [DEV_BOARD]
GO
/****** Object:  StoredProcedure [dbo].[createBoard]    Script Date: 2022-06-24 오전 10:21:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		성우
-- Create date: 2022.06.24
-- Description:	user 게시판 글 입력 프로시저
-- =============================================
ALTER PROCEDURE [dbo].[createBoard]
(
	@CATEGORY		VARCHAR(10),
	@TITLE			VARCHAR(50),
	@CONTENT		TEXT,
	@FILENAME		VARCHAR(50),
	@CRAETED_IP		VARCHAR(15),
	@USER_ID		INT
)
AS
BEGIN TRAN
	INSERT INTO dbo.Board (CATEGORY, TITLE, CONTENT, FILE_NAME, CREATED_IP, USER_ID) 
	VALUES
	(@CATEGORY, @TITLE, @CONTENT, @FILENAME, @CRAETED_IP, @USER_ID);
COMMIT TRAN
