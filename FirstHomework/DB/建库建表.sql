use master
go
create database Homework
on
(
	name='Homework',
	filename='E:\Ruanmou\Study\FirstHomework\DB\Homework.mdf'
)
log on
(
	name='Homework_log',
	filename='E:\Ruanmou\Study\FirstHomework\DB\Homework_log.ldf'
)
go
use Homework

CREATE TABLE [dbo].[Company]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
	 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO																																				
																																						
INSERT INTO [dbo].[Company]([Name],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime])
VALUES('百捷','2015-12-10',1,1,'2015-12-10')																										
																																						
INSERT INTO [dbo].[Company]([Name],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime])
VALUES('东莞','2015-12-10',1,1,'2015-12-10')
																																				
INSERT INTO [dbo].[Company]([Name],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime])
VALUES('东风日产','2015-12-10',1,1,'2015-12-10')

go
																																						
CREATE TABLE [dbo].[User]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Account] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](200) NULL,
	[Mobile] [varchar](30) NULL,
	[CompanyId] [int] NULL,
	[CompanyName] [nvarchar](500) NULL,
	[State] [int] NOT NULL,
	[UserType] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
	 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO																																				
INSERT INTO [dbo].[User]([Name],[Account],[Password],[Email],[Mobile],
[CompanyId] ,[CompanyName],[State],[UserType],[LastLoginTime],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime])
VALUES('小新','admin','e10adc3949ba59abbe56e057f20f883e','12','133'	,'1','百捷',0,2,'2015-12-12','2015-12-12',1,1,'2015-12-12')
GO
