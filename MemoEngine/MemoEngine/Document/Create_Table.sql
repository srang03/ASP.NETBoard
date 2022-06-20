CREATE TABLE dbo.Notes
(
	ID				INT			IDENTITY(1,1) PRIMARY KEY,			-- 번호
	NAME			NVARCHAR(25)	NOT NULL,						-- 이름
	EMAIL			NVARCHAR(100)	NULL,							-- 이메일
	TITLE			NVARCHAR(100)	NOT NULL,						-- 제목
	POSTDATE		DATETIME		DEFAULT GetDate() NOT NULL,		-- 작성일
	POSTIP			NVARCHAR(15)	NOT NULL,						-- 작성 IP
	CONTENT			NTEXT			NOT NULL,						-- 작성 내용
	PASSWORD		NVARCHAR(50)	NOT NULL,						-- 비밀번호
	READCOUNT		INT				DEFAULT 0,						-- 조회수
	ENCODING		NVARCHAR(10)	NOT NULL,						-- 인코딩(HTML/TEXT)
	HOMEPAGE		NVARCHAR(100)	NULL,							-- 홈페이지
	MODIFYDATE		DATETIME		NULL,							-- 수정일
	MODIFYIP		NVARCHAR(15)	NULL,							-- 수정 IP
	FILENAME		NVARCHAR(100)	NULL,							-- 파일명
	FILESIZE		INT				DEFAULT 0,						-- 파일 크기
	DOWNCOUNT		INT				DEFAULT	0,						-- 다운로드 수
	REF				INT				NOT NULL,						-- 참조 (부모글)
	STEP			INT				NOT NULL,						-- 답변 깊이 (레벨)
	REFORDER		INT				DEFAULT 0,						-- 답변 순서
	ANSWERNUM		INT				DEFAULT 0,						-- 답변 수
	PARENTNUM		INT				DEFAULT 0,						-- 부모글 번호
	COMMENTCOUNT	INT				DEFAULT 0,						-- 댓글 수
	CATEGORY		NVARCHAR(10)	NULL							-- 카테고리 (확장)
)
GO
