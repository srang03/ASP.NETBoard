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
-- Author:		����
-- Create date: 2022.06.24
-- Description:	user �Խ��� �� �󼼺��� ���ν���
-- =============================================
CREATE PROCEDURE browseBoard
(
	@ID		INT
)
AS
BEGIN TRAN
	SELECT ID, USER_ID, CATEGORY, TITLE, CONTENT, FILE_NAME, MODIFIED_DATE FROM dbo.Board WHERE ID = @ID;
COMMIT TRAN
GO
