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
-- Description:	user 게시판 글 삭제 프로시저
-- =============================================
CREATE PROCEDURE deleteBoard
	@ID				INT,
	@USER_ID		INT
AS
BEGIN TRAN
	DELETE FROM dbo.Board WHERE ID  = @ID AND @USER_ID = @USER_ID;
COMMIT TRAN
GO
