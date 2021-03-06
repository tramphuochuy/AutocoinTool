
CREATE TABLE [dbo].[CONFIG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PCID] [nvarchar](250) NOT NULL,
	[PROFILE] [nvarchar](50) NOT NULL,
	[STT] [nvarchar](10) NULL,
	[SCRYPT] [nvarchar](255) NULL,
	[X11] [nvarchar](255) NULL,
	[NFACTOR] [nvarchar](255) NULL,
	[X13] [nvarchar](255) NULL,
	[GROESTL] [nvarchar](255) NULL,
	[CDATETIME] [datetime] NULL,
 CONSTRAINT [PK_CONFIG_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHADOWMAN]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHADOWMAN](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PCID] [nvarchar](50) NULL,
	[PCNAME] [nvarchar](20) NULL,
	[STATUS] [nvarchar](50) NULL,
	[COMMAND] [nvarchar](30) NULL,
	[CDATETIME] [datetime] NULL,
	[TEAMVIEWER] [nvarchar](40) NULL,
	[IP] [nvarchar](50) NULL,
	[MD5] [nvarchar](30) NULL,
 CONSTRAINT [PK_SHADOWMAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COIN]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COIN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERCODE] [nvarchar](50) NULL,
	[COIN] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[AUTORESTART] [int] NULL,
	[FORCEUPDATE] [int] NULL,
	[ISMONITOR] [int] NULL,
	[PROFILEVERSION] [nvarchar](200) NULL,
	[CDATETIME] [datetime] NULL,
 CONSTRAINT [PK_COIN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILEDATA]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILEDATA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FILENAME] [nvarchar](200) NULL,
	[BINARY] [image] NULL,
	[TYPE] [nvarchar](50) NULL,
	[SIZE] [float] NULL,
	[VERSION] [nvarchar](50) NULL,
	[CDATETIME] [datetime] NULL,
	[USERCODE] [nvarchar](50) NULL,
	[MD5] [nvarchar](100) NULL,
	[FOLDER] [nvarchar](50) NULL,
	[ACTIVE] [nvarchar](10) NULL,
 CONSTRAINT [PK_UPDATES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONITOR_LOG]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONITOR_LOG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERCODE] [nvarchar](50) NULL,
	[COIN] [nvarchar](20) NULL,
	[URL] [nvarchar](100) NULL,
	[WORKER] [nvarchar](50) NULL,
	[ACCEPTS] [int] NULL,
	[ACCEPTS_TOTAL] [int] NULL,
	[STATUS] [nvarchar](50) NULL,
	[CDATETIME] [datetime] NULL,
	[VERSION] [nvarchar](150) NULL,
	[SPEED] [nvarchar](100) NULL,
	[TEAMVIEWERID] [nvarchar](30) NULL,
	[TEAMVIEWERPASSWORD] [nvarchar](30) NULL,
	[COMMAND] [nvarchar](50) NULL,
	[ISSTOP] [nvarchar](10) NULL,
	[MAXDIFF] [int] NULL,
	[MAXREJECT] [int] NULL,
	[MAXSECOND] [int] NULL,
	[STATS] [nvarchar](100) NULL,
	[MONITORDATA] [nvarchar](50) NULL,
	[RSS] [nvarchar](10) NULL,
	[IP] [nvarchar](30) NULL,
	[APIDIFF] [nvarchar](20) NULL,
	[APISPEED] [nvarchar](20) NULL,
	[HASHPOWER] [nvarchar](30) NULL,
	[GPUSTATS] [nvarchar](50) NULL,
	[TIME2KILL] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONITOR]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MONITOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERCODE] [nvarchar](50) NULL,
	[COIN] [nvarchar](20) NULL,
	[URL] [nvarchar](100) NULL,
	[WORKER] [nvarchar](50) NULL,
	[ACCEPTS] [int] NULL,
	[ACCEPTS_PLUS] [nvarchar](20) NULL,
	[ACCEPTS_TOTAL] [int] NULL,
	[STATUS] [nvarchar](50) NULL,
	[CDATETIME] [datetime] NULL,
	[VERSION] [nvarchar](150) NULL,
	[SPEED] [nvarchar](100) NULL,
	[TEAMVIEWERID] [nvarchar](30) NULL,
	[TEAMVIEWERPASSWORD] [nvarchar](30) NULL,
	[COMMAND] [nvarchar](50) NULL,
	[ISSTOP] [nvarchar](10) NULL,
	[MAXDIFF] [float] NULL,
	[MAXREJECT] [int] NULL,
	[MAXSECOND] [int] NULL,
	[STATS] [nvarchar](100) NULL,
	[MONITORDATA] [nvarchar](50) NULL,
	[RSS] [nvarchar](10) NULL,
	[IP] [nvarchar](30) NULL,
	[APIDIFF] [nvarchar](20) NULL,
	[APISPEED] [nvarchar](20) NULL,
	[HASHPOWER] [nvarchar](30) NULL,
	[GPUSTATS] [nvarchar](50) NULL,
	[TIME2KILL] [nvarchar](10) NULL,
	[GPUSTATS_MH] [nvarchar](150) NULL,
	[LAT] [datetime] NULL,
	[DIFF] [float] NULL,
	[CONFIG] [ntext] NULL,
	[PCID] [nvarchar](200) NULL,
	[MAC] [nvarchar](50) NULL,
	[WORKER_SUBFIX] [varchar](10) NULL,
	[ALGO] [nvarchar](30) NULL,
 CONSTRAINT [PK_COIN_TRACKING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[FileUpdate]    Script Date: 06/16/2014 18:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FileUpdate]
@ID INT = NULL,
@FILENAME NVARCHAR(200) = NULL,
@BINARY IMAGE = NULL,
@TYPE NVARCHAR(50) = NULL,
@SIZE FLOAT = NULL,
@VERSION NVARCHAR(50) = NULL,
@CDATETIME DATETIME = NULL,
@USERCODE DATETIME = NULL,
@MD5 nvarchar(100) = null
AS

DECLARE @RetCode int, @RetMsg varchar(10)
SET @RetCode = 1
set @RetMsg = 'MSG0003' --Update successfully

--CHECK DATA
if (isnull(@ID,0) = 0)
BEGIN
	SET @RetCode = 0
	set @RetMsg = 'MSG0006' --Missing mandatory data
	goto LEND
END

UPDATE [FILEDATA]
SET 
	[FILENAME] = @FILENAME,
	[BINARY] = @BINARY,
	[TYPE] = @TYPE,
	[SIZE] = @SIZE,
	[VERSION] = @VERSION,
	[CDATETIME] = @CDATETIME,
	[USERCODE] = @USERCODE,
	MD5 = @MD5
WHERE ([ID] = @ID) 

LEND:

--RETURN RESULT
SELECT @RetCode AS RetCode,@RetMsg as RetMsg
GO
/****** Object:  StoredProcedure [dbo].[FileInsert]    Script Date: 06/16/2014 18:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FileInsert]
@ID INT = NULL,
@FILENAME NVARCHAR(200) = NULL,
@BINARY IMAGE = NULL,
@TYPE NVARCHAR(50) = NULL,
@SIZE FLOAT = NULL,
@VERSION NVARCHAR(50) = NULL,
@CDATETIME DATETIME = NULL,
@USERCODE nvarchar(50) = NULL,
@MD5 nvarchar(100) = null
AS


DELETE FILEDATA WHERE FILENAME = @FILENAME
INSERT INTO [FILEDATA](
	
	[FILENAME],
	[BINARY],
	[TYPE],
	[SIZE],
	[VERSION],
	[CDATETIME],
	[USERCODE],
	MD5)
VALUES(
	@FILENAME,
	@BINARY,
	@TYPE,
	@SIZE,
	@VERSION,
	GETDATE(),
	@USERCODE,
	@MD5)
GO
/****** Object:  StoredProcedure [dbo].[FileDelete]    Script Date: 06/16/2014 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1 : SUCCESS
--0 : BEING IN USE

CREATE PROCEDURE [dbo].[FileDelete]
@ID INT = NULL
AS

DECLARE @RetCode int, @RetMsg varchar(10)

SET @RetCode = 1
set @RetMsg = 'MSG0002' --Delete successfully

--CHECK DATA
if (isnull(@ID,0) = 0)
BEGIN
	SET @RetCode = 0
	set @RetMsg = 'MSG0006' --Missing mandatory data
	goto LEND
END

--CHECK IF BEING IN USE OR NOT
--IF(EXISTS(SELECT * FROM ? WHERE ?))
--BEGIN
--	SET @RetCode = 0
--	set @RetMsg = 'MSG0005' --Data in use
--	goto LEND
--END

DELETE FROM [FILEDATA] 
WHERE ([ID] = @ID) 

LEND:

--RETURN RESULT
SELECT @RetCode AS RetCode,@RetMsg as RetMsg
GO
/****** Object:  StoredProcedure [dbo].[ConfigInsert]    Script Date: 06/16/2014 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConfigInsert] 
@PROFILE nvarchar(100) = NULL,
@PCID nvarchar(250) = null ,
@STT nvarchar(10) = null ,
@SCRYPT nvarchar(255) = null ,
@X11 nvarchar(255) = null ,
@NFACTOR nvarchar(255) = null ,
@X13 nvarchar(255) = null ,
@GROESTL nvarchar(255) = null
as

DELETE CONFIG WHERE PCID = @PCID
INSERT INTO CONFIG
           (
           PROFILE
           ,PCID
           ,STT
           ,SCRYPT
           ,X11
           ,NFACTOR
           ,X13
           ,GROESTL
           
           
           )
     VALUES
     (
     @PROFILE,
           @PCID
           ,@STT
           ,@SCRYPT
           ,@X11
           ,@NFACTOR
           ,@X13
           ,@GROESTL
        )
GO
/****** Object:  Table [dbo].[COIN_DETAIL]    Script Date: 06/16/2014 18:21:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COIN_DETAIL](
	[USERCODE] [nvarchar](50) NOT NULL,
	[COIN] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](max) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[CONFIG] [ntext] NULL,
	[AUTORESTART] [int] NULL,
	[AUTORESTARTSECOND] [int] NULL,
	[LINK] [nvarchar](200) NULL,
	[API_Price] [nvarchar](50) NULL,
	[COINADDRESS] [nvarchar](255) NULL,
	[USEADDRESS] [int] NULL,
	[USEMAXDIFF] [int] NULL,
	[MAXDIFF] [float] NULL,
	[MAXREJECT] [float] NULL,
	[MAXSECOND] [int] NULL,
	[REMARK] [nvarchar](40) NULL,
	[API] [nvarchar](200) NULL,
	[FLAGCREDIT] [float] NULL,
	[USESJ] [int] NULL,
	[USESJ2] [int] NULL,
	[USESJ3] [int] NULL,
	[USESJ4] [int] NULL,
	[ALGO] [nvarchar](20) NULL,
 CONSTRAINT [PK_COIN_DETAIL] PRIMARY KEY CLUSTERED 
(
	[USERCODE] ASC,
	[COIN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[MonitorLogByHour]    Script Date: 06/16/2014 18:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUnction [dbo].[MonitorLogByHour]( @DATE date , @MINUTE int )
RETURNS nvarchar(100)
AS

BEGIN
		DECLARE @KQ nvarchar(100)
		SET @KQ = ''
		SELECT TOP 1 @KQ = ISNULL(SPEED,'0') + '-' + ISNULL( APISPEED,'0')
						from monitor_log 
						where usercode = 'tramphuochuy' 
						and WORKER = 'tramphuochuy.R1' 
						AND  CONVERT(DATE,CDATETIME) = CONVERT(DATE,@DATE)
						AND   ABS ( ( DATEPART(HOUR,CDATETIME)* 60 + DATEPART(MINUTE,CDATETIME))- @MINUTE ) < 3
					
		RETURN  ISNULL(@KQ,'')
END


-- select dbo.MonitorLogByHour('3/4/2014',1)
GO
/****** Object:  StoredProcedure [dbo].[MonitorLog]    Script Date: 06/16/2014 18:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MonitorLog]( @USERCODE nvarchar(40), @WORKER nvarchar(50),@DATE date , @INTERVAL int )
AS

DECLARE @i int
SET @i = 0
DECLARE @H int = 0
DECLARE @M int = 0

Declare @T table
(
 TIME nvarchar(20),
 HOUR nvarchar(20),
 MINUTE nvarchar(100),
 SPEED int,
 ACCEPTS int

)


WHILE ( ISNULL(@i,0) <= 1440 )
BEGIN
	IF ( @i%@INTERVAL = 0 )
		BEGIN
			SET @H =  @i/60
			SET @M = @i%60
			
					DECLARE @SPEED nvarchar(20)='0'
					DECLARE @ACCEPTS nvarchar(20) ='0'
					SELECT TOP 1 @SPEED = ISNULL(REPLACE(SPEED,' KH/s',''),'0') , @ACCEPTS = ISNULL( APISPEED,'0')
						from monitor_log 
						where usercode = @USERCODE
						and WORKER = @WORKER
						AND  CONVERT(DATE,CDATETIME) = CONVERT(DATE,@DATE)
						AND   ABS ( ( DATEPART(HOUR,CDATETIME)* 60 + DATEPART(MINUTE,CDATETIME))- @i ) < 3
						
			INSERT INTO @T VALUES (  @i,@H,@M,CONVERT(int,@SPEED),CONVERT(int,@ACCEPTS))
		END
	SET @i = ISNULL(@i,0) + 1

END

SELECT * from @T


-- MonitorLog '3/4/2014',5
GO
/****** Object:  StoredProcedure [dbo].[MonitorInsert]    Script Date: 06/16/2014 18:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MonitorInsert]
@USERCODE nvarchar(200),
@COIN nvarchar(30),
@URL nvarchar(100),
@WORKER nvarchar(50),
@ACCEPTS int ,
@STATUS nvarchar(100),
@VERSION nvarchar(100) = null,
@SPEED nvarchar(100)  = null,
@TEAMVIEWERID nvarchar(30) = null,
@TEAMVIEWERPASSWORD nvarchar(20) = null,
@MAXDIFF float = null,
@MAXREJECT int = null,
@MAXSECOND int = null,
@STATS nvarchar(100) = null,
@MONITORDATA nvarchar(50) = null,
@RSS nvarchar(10) = null,
@IP nvarchar(30) = null,
@GPUSTATS nvarchar(50) = null,
@TIME2KILL nvarchar(10) = null,
@ACCEPTS_TOTAL int = null,
@GPUSTATS_MH nvarchar(150) = null,
@DIFF float = null,
@CONFIG ntext = null,
@PCID nvarchar(100) = null,
@MAC nvarchar(50) = null,
@WORKER_SUBFIX varchar(10) = null,
@ALGO nvarchar(30) = null
AS

IF ( EXISTS (SELECT * FROM MONITOR WHERE USERCODE= @USERCODE AND WORKER = @WORKER ) ) 
	BEGIN
			UPDATE MONITOR
			SET USERCODE = @USERCODE,
			COIN = @COIN,
			URL = @URL,
			WORKER = @WORKER,
			ACCEPTS = @ACCEPTS,
			STATUS = 'Monitored',
			CDATETIME  = getdate(),
			VERSION = @VERSION,
			SPEED = @SPEED,
			TEAMVIEWERID  = @TEAMVIEWERID,
			TEAMVIEWERPASSWORD = @TEAMVIEWERPASSWORD,
			MAXDIFF = @MAXDIFF,
			MAXREJECT = @MAXREJECT,
			MAXSECOND = @MAXSECOND,
			STATS = @STATS,
			MONITORDATA = @MONITORDATA,
			RSS = @RSS ,
			IP = @IP,
			GPUSTATS = @GPUSTATS,
			TIME2KILL = @TIME2KILL,
			ACCEPTS_TOTAL = @ACCEPTS_TOTAL,
			GPUSTATS_MH = @GPUSTATS_MH,
			DIFF = @DIFF,
			CONFIG = @CONFIG,
			PCID = @PCID,
			MAC = @MAC,
			WORKER_SUBFIX = @WORKER_SUBFIX,
			ALGO = @ALGO
			WHERE
			USERCODE = @USERCODE AND WORKER = @WORKER
	END

ELSE
	BEGIN

			INSERT INTO MONITOR (  USERCODE,COIN,URL,WORKER,ACCEPTS,STATUS,CDATETIME,VERSION,SPEED,TEAMVIEWERID,TEAMVIEWERPASSWORD ,MAXDIFF,MAXREJECT,MAXSECOND,STATS,MONITORDATA,RSS,IP,GPUSTATS,TIME2KILL,ACCEPTS_TOTAL,GPUSTATS_MH,DIFF,CONFIG , PCID , MAC,WORKER_SUBFIX ,ALGO) 
			VALUES (@USERCODE,@COIN,@URL,@WORKER,@ACCEPTS,'Monitored',getdate(),@VERSION,@SPEED,@TEAMVIEWERID,@TEAMVIEWERPASSWORD,@MAXDIFF,@MAXREJECT,@MAXSECOND,@STATS,@MONITORDATA,@RSS,@IP,@GPUSTATS,@TIME2KILL,@ACCEPTS_TOTAL,@GPUSTATS_MH,@DIFF,@CONFIG , @PCID , @MAC,@WORKER_SUBFIX,@ALGO)
	END
	
	
-- INSERT LOG

IF 	NOT EXISTS (SELECT * FROM MONITOR_LOG WHERE USERCODE= @USERCODE 
			AND WORKER = @WORKER 
		AND CONVERT(DATE,GETDATE()) = CONVERT(DATE,CDATETIME) 

			AND DATEPART(hh,GETDATE()) = DATEPART(hh,CDATETIME) 
			AND  ( DATEDIFF(mi,CDATETIME,GETDATE()) < 50  ) 
			
			)


	BEGIN
		INSERT INTO MONITOR_LOG (  USERCODE,COIN,URL,WORKER,ACCEPTS,STATUS,CDATETIME,VERSION,SPEED,TEAMVIEWERID,TEAMVIEWERPASSWORD ,MAXDIFF,MAXREJECT,MAXSECOND,STATS,MONITORDATA,RSS,IP,GPUSTATS,TIME2KILL,ACCEPTS_TOTAL) 
		VALUES (@USERCODE,@COIN,@URL,@WORKER,@ACCEPTS,'Monitored',getdate(),@VERSION,@SPEED,@TEAMVIEWERID,@TEAMVIEWERPASSWORD,@MAXDIFF,@MAXREJECT,@MAXSECOND,@STATS,@MONITORDATA,@RSS,@IP,@GPUSTATS,@TIME2KILL,@ACCEPTS_TOTAL)
	END
GO
/****** Object:  StoredProcedure [dbo].[ShadowmanInsert]    Script Date: 06/16/2014 18:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ShadowmanInsert]
			
@PCID nvarchar(100) = null,
@PCNAME nvarchar(100) = null,
@STATUS nvarchar(100) = null,
@TEAMVIEWER nvarchar(50) = null,
@IP nvarchar(50) = null,
@MD5 nvarchar(30) = null

           
           
AS 


IF ( EXISTS (SELECT * FROM SHADOWMAN WHERE PCID = @PCID ) ) 
	BEGIN
			UPDATE SHADOWMAN
			SET 
			
			PCNAME = @PCNAME ,
			STATUS = @STATUS ,
			TEAMVIEWER = @TEAMVIEWER,
			IP  = @IP,MD5 = @MD5,
			
			CDATETIME = GETDATE()
			WHERE
			PCID = @PCID
	END

ELSE
	BEGIN

		INSERT INTO SHADOWMAN(	PCID ,PCNAME ,STATUS ,TEAMVIEWER,IP,MD5)
		VALUES( @PCID ,@PCNAME ,@STATUS , @TEAMVIEWER,@IP,@MD5  )

END
GO
/****** Object:  View [dbo].[VW_LIST_COIN_DETAIL]    Script Date: 06/16/2014 18:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_LIST_COIN_DETAIL]
AS
SELECT     dbo.COIN_DETAIL.*
FROM         dbo.COIN_DETAIL
GO
/****** Object:  StoredProcedure [dbo].[CoinInsert]    Script Date: 06/16/2014 18:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CoinInsert] 
@USERCODE nvarchar(200),
@COIN nvarchar(300),
@URL nvarchar(300),
@USERNAME nvarchar(200),
@PASSWORD nvarchar(200),
@LINK nvarchar(max),
@ALGO nvarchar(20) = null

as

DECLARE @MAXDIFF int

IF ( @USERCODE IN ('tramphuochuy1','test','tramphuochuy3','tramphuochuy4','tramphuochuy2','hotanquang1') ) SET @MAXDIFF = 16
ELSE SET @MAXDIFF = 1024

INSERT INTO COIN_DETAIL
           ([USERCODE]
           ,[COIN]
           ,[URL]
           ,[USERNAME]
           ,[PASSWORD]
           ,[CONFIG]
           ,MAXDIFF
           ,ALGO
           
           )
     VALUES
     (
           @USERCODE,
           @COIN,
           @URL,
           @USERNAME,
           @PASSWORD,
           '',
           @MAXDIFF,
           @ALGO
        )
GO
/****** Object:  Default [DF_COIN_AUTORESTART]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN] ADD  CONSTRAINT [DF_COIN_AUTORESTART]  DEFAULT ((0)) FOR [AUTORESTART]
GO
/****** Object:  Default [DF_COIN_FORCEUPDATE]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN] ADD  CONSTRAINT [DF_COIN_FORCEUPDATE]  DEFAULT ((1)) FOR [FORCEUPDATE]
GO
/****** Object:  Default [DF_COIN_CDATETIME]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN] ADD  CONSTRAINT [DF_COIN_CDATETIME]  DEFAULT (getdate()) FOR [CDATETIME]
GO
/****** Object:  Default [DF_COIN_DETAIL_PASSWORD]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_PASSWORD]  DEFAULT (N'password') FOR [PASSWORD]
GO
/****** Object:  Default [DF_COIN_DETAIL_AUTORESTART]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_AUTORESTART]  DEFAULT ((0)) FOR [AUTORESTART]
GO
/****** Object:  Default [DF_COIN_DETAIL_AUTORESTARTSECOND]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_AUTORESTARTSECOND]  DEFAULT ((120)) FOR [AUTORESTARTSECOND]
GO
/****** Object:  Default [DF_COIN_DETAIL_LINK]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_LINK]  DEFAULT ('') FOR [LINK]
GO
/****** Object:  Default [DF_COIN_DETAIL_USERADDRESS]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USERADDRESS]  DEFAULT ((0)) FOR [USEADDRESS]
GO
/****** Object:  Default [DF_COIN_DETAIL_USEMAXDIFF]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USEMAXDIFF]  DEFAULT ((0)) FOR [USEMAXDIFF]
GO
/****** Object:  Default [DF_COIN_DETAIL_MAXDIFF]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_MAXDIFF]  DEFAULT ((1024)) FOR [MAXDIFF]
GO
/****** Object:  Default [DF_COIN_DETAIL_MAXREJECT]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_MAXREJECT]  DEFAULT ((25)) FOR [MAXREJECT]
GO
/****** Object:  Default [DF_COIN_DETAIL_MAXSECOND]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_MAXSECOND]  DEFAULT ((180)) FOR [MAXSECOND]
GO
/****** Object:  Default [DF_COIN_DETAIL_FLAGCREDIT]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_FLAGCREDIT]  DEFAULT ((0)) FOR [FLAGCREDIT]
GO
/****** Object:  Default [DF_COIN_DETAIL_USESJ]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USESJ]  DEFAULT ((0)) FOR [USESJ]
GO
/****** Object:  Default [DF_COIN_DETAIL_USESJ2]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USESJ2]  DEFAULT ((0)) FOR [USESJ2]
GO
/****** Object:  Default [DF_COIN_DETAIL_USESJ3]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USESJ3]  DEFAULT ((0)) FOR [USESJ3]
GO
/****** Object:  Default [DF_COIN_DETAIL_USESJ4]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_USESJ4]  DEFAULT ((0)) FOR [USESJ4]
GO
/****** Object:  Default [DF_COIN_DETAIL_ALGO]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[COIN_DETAIL] ADD  CONSTRAINT [DF_COIN_DETAIL_ALGO]  DEFAULT (N'SCRYPT') FOR [ALGO]
GO
/****** Object:  Default [DF_CONFIG_SCRYPT]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_SCRYPT]  DEFAULT ('') FOR [SCRYPT]
GO
/****** Object:  Default [DF_CONFIG_X11]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_X11]  DEFAULT ('') FOR [X11]
GO
/****** Object:  Default [DF_CONFIG_NFACTOR]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_NFACTOR]  DEFAULT ('') FOR [NFACTOR]
GO
/****** Object:  Default [DF_CONFIG_X13]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_X13]  DEFAULT ('') FOR [X13]
GO
/****** Object:  Default [DF_CONFIG_GROESTL]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_GROESTL]  DEFAULT ('') FOR [GROESTL]
GO
/****** Object:  Default [DF_CONFIG_CDATETIME]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[CONFIG] ADD  CONSTRAINT [DF_CONFIG_CDATETIME]  DEFAULT (getdate()) FOR [CDATETIME]
GO
/****** Object:  Default [DF_FILEDATA_FOLDER]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[FILEDATA] ADD  CONSTRAINT [DF_FILEDATA_FOLDER]  DEFAULT ('') FOR [FOLDER]
GO
/****** Object:  Default [DF_FILEDATA_HIDE]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[FILEDATA] ADD  CONSTRAINT [DF_FILEDATA_HIDE]  DEFAULT (N'Y') FOR [ACTIVE]
GO
/****** Object:  Default [DF_MONITOR_CDATETIME]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_CDATETIME]  DEFAULT (getdate()) FOR [CDATETIME]
GO
/****** Object:  Default [DF_MONITOR_RESETCOMMAND]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_RESETCOMMAND]  DEFAULT ('') FOR [COMMAND]
GO
/****** Object:  Default [DF_MONITOR_ISSTOP]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_ISSTOP]  DEFAULT (N'No') FOR [ISSTOP]
GO
/****** Object:  Default [DF_MONITOR_STATS]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_STATS]  DEFAULT ('') FOR [STATS]
GO
/****** Object:  Default [DF_MONITOR_APIDIFF]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_APIDIFF]  DEFAULT ('') FOR [APIDIFF]
GO
/****** Object:  Default [DF_MONITOR_APISPEED]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_APISPEED]  DEFAULT ('') FOR [APISPEED]
GO
/****** Object:  Default [DF_MONITOR_LAT]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_LAT]  DEFAULT (getdate()) FOR [LAT]
GO
/****** Object:  Default [DF_MONITOR_WORKER_SUBFIX]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[MONITOR] ADD  CONSTRAINT [DF_MONITOR_WORKER_SUBFIX]  DEFAULT ('') FOR [WORKER_SUBFIX]
GO
/****** Object:  Default [DF_SHADOWMAN_CDATETIME]    Script Date: 06/16/2014 18:21:08 ******/
ALTER TABLE [dbo].[SHADOWMAN] ADD  CONSTRAINT [DF_SHADOWMAN_CDATETIME]  DEFAULT (getdate()) FOR [CDATETIME]
GO


create trigger [dbo].[Monitor_Update]
ON [dbo].[MONITOR] for UPDATE

AS

BEGIN
DECLARE @ID int
DECLARE @PLUS int
DECLARE @OLD int
DECLARE @NEW int

DECLARE @WORKER nvarchar(50)
DECLARE @USERCODE nvarchar(50)

SELECT @OLD = ISNULL(ACCEPTS,0),@ID = ID , @WORKER = WORKER FROM DELETED

SELECT @NEW = ISNULL(ACCEPTS,0), @USERCODE = USERCODE FROM INSERTED

IF @NEW < @OLD SET @OLD = 0

UPDATE  MONITOR 
SET ACCEPTS_PLUS = '+ ' + CONVERT(nvarchar(20),@NEW - @OLD)
WHERE ID = @ID

IF  (( @NEW - @OLD ) > 0 )
BEGIN

	UPDATE  MONITOR 
	SET LAT = getdate()
	WHERE ID = @ID
END





END
