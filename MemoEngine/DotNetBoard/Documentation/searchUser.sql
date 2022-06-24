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
-- Description:	user 유저 정보 출력 프로시저
-- =============================================
CREATE PROCEDURE searchUser
	@ID			INT
AS
BEGIN
	SELECT EMAIL, NAME FROM dbo.Users WHERE ID = @ID;
END
GO
