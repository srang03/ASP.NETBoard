CREATE TABLE dbo.Notes
(
	ID				INT			IDENTITY(1,1) PRIMARY KEY,			-- ��ȣ
	NAME			NVARCHAR(25)	NOT NULL,						-- �̸�
	EMAIL			NVARCHAR(100)	NULL,							-- �̸���
	TITLE			NVARCHAR(100)	NOT NULL,						-- ����
	POSTDATE		DATETIME		DEFAULT GetDate() NOT NULL,		-- �ۼ���
	POSTIP			NVARCHAR(15)	NOT NULL,						-- �ۼ� IP
	CONTENT			NTEXT			NOT NULL,						-- �ۼ� ����
	PASSWORD		NVARCHAR(50)	NOT NULL,						-- ��й�ȣ
	READCOUNT		INT				DEFAULT 0,						-- ��ȸ��
	ENCODING		NVARCHAR(10)	NOT NULL,						-- ���ڵ�(HTML/TEXT)
	HOMEPAGE		NVARCHAR(100)	NULL,							-- Ȩ������
	MODIFYDATE		DATETIME		NULL,							-- ������
	MODIFYIP		NVARCHAR(15)	NULL,							-- ���� IP
	FILENAME		NVARCHAR(100)	NULL,							-- ���ϸ�
	FILESIZE		INT				DEFAULT 0,						-- ���� ũ��
	DOWNCOUNT		INT				DEFAULT	0,						-- �ٿ�ε� ��
	REF				INT				NOT NULL,						-- ���� (�θ��)
	STEP			INT				NOT NULL,						-- �亯 ���� (����)
	REFORDER		INT				DEFAULT 0,						-- �亯 ����
	ANSWERNUM		INT				DEFAULT 0,						-- �亯 ��
	PARENTNUM		INT				DEFAULT 0,						-- �θ�� ��ȣ
	COMMENTCOUNT	INT				DEFAULT 0,						-- ��� ��
	CATEGORY		NVARCHAR(10)	NULL							-- ī�װ� (Ȯ��)
)
GO
