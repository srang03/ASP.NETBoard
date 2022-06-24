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
-- Description:	user 게시판 글 검색 프로시저
-- =============================================
CREATE PROCEDURE searchBoard
	@SEARCH_FIELD	VARCHAR(50),
	@SEARCH_VALUE	VARCHAR(50)
AS
	Declare @strSql VARCHAR(150)
	SET @strSql = 
	' 	
		SELECT ID, USER_ID, CATEGORY, TITLE, CONTENT, FILE_NAME, MODIFIED_DATE FROM dbo.Board
		WHERE ' + @SEARCH_FIELD + ' LIKE '' %' + @SEARCH_VALUE + ' %'' ORDER BY ID DESC;
	'
BEGIN
	EXECUTE(@strSql)
END
GO
