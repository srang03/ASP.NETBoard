-- ====
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		����
-- Create date: 2022.06.24
-- Description:	user ȸ������ ���� ���ν���
-- /** EXECUTE createUser 'test@naver.com', '�̾�', '123456', '123456', '121.168.0.1' **/
-- =============================================
CREATE PROCEDURE createUser(
	@EMAIL			VARCHAR(50),
	@NAME			VARCHAR(50),
	@PASSWORD		VARCHAR(100),
	@RE_PASSWORD	VARCHAR(100),
	@CREATED_IP		VARCHAR(15)
	)
AS
BEGIN TRAN
	INSERT INTO dbo.Users (EMAIL, NAME, PASSWORD, RE_PASSWORD, CREATED_IP)
	VALUES (@EMAIL, @NAME, @PASSWORD, @RE_PASSWORD, @CREATED_IP)
COMMIT TRAN
GO
