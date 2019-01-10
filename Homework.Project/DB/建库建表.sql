use master
Create Database HomeworkDB
on
(
	name='HomeworkDB.mdf',
	filename='E:\Ruanmou\Study\Homework.Project\DB\HomeworkDB.mdf'
)
log on
(
	name='HomeworkDB_Log.ldf',
	filename='E:\Ruanmou\Study\Homework.Project\DB\HomeworkDB_Log.ldf'
)
go
use HomeworkDB

/****** 大家执行到自己的数据库环境 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2016/8/4 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [varchar](500) NULL,
	[SourcePath] [varchar](1000) NOT NULL,
	[State] [int] NOT NULL,
	[MenuLevel] [int] NOT NULL,
	[Sort] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2016/8/4 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
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
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserMenuMapping]    Script Date: 2016/8/4 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMenuMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_UserMenuMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Company] ON 

GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1, N'百捷03', CAST(0x0000A5D0015752A0 AS DateTime), 1, 1, CAST(0x0000A5D0015752A0 AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (2, N'东莞', CAST(0x0000A56A00000000 AS DateTime), 1, 1, CAST(0x0000A56A00000000 AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (3, N'东风日产', CAST(0x0000A56A00000000 AS DateTime), 1, 1, CAST(0x0000A56A00000000 AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (4, N'万达集团', CAST(0x0000A5CE01216BCC AS DateTime), 2, 0, CAST(0x0000A5CE01216BCC AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (5, N'万达集团', CAST(0x0000A5CE01216BCC AS DateTime), 2, 0, CAST(0x0000A5CE01216BCC AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1004, N'腾讯02', CAST(0x0000A5D00144EBB0 AS DateTime), 1, 1, CAST(0x0000A5D00144EBB0 AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1005, N'233', CAST(0x0000A63C00000000 AS DateTime), 12, NULL, NULL)
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1006, N'my''ganme', CAST(0x0000A63C00000000 AS DateTime), 12, NULL, NULL)
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1007, N'12345', CAST(0x0000A63C00000000 AS DateTime), 23, NULL, NULL)
GO
INSERT [dbo].[Company] ([Id], [Name], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (2004, N'ruanmou', CAST(0x0000A634014E16EF AS DateTime), 1, 1, CAST(0x0000A634014E185E AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (1, 0, N'单据管理', N'用户单据管理', N'.', N'root/1', 0, 1, 200, CAST(0x0000A56C00000000 AS DateTime), 1, 2, CAST(0x0000A57500830B44 AS DateTime))
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (3, 0, N'系统监控', N'管理员系统监控', NULL, N'root/3', 0, 1, 180, CAST(0x0000A56C00000000 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (6, 0, N'系统配置', N'用户管理', NULL, N'root/6', 0, 1, 160, CAST(0x0000A56C00000000 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (7, 1, N'单据导入', N'用户导入单据', N'/Order/Index', N'root/1/123', 0, 2, 200, CAST(0x0000A56C00000000 AS DateTime), 1, 2, CAST(0x0000A57500830B44 AS DateTime))
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (9, 3, N'系统日志', N'观看系统日志', N'/Record/Index', N'root/3/44', 0, 2, 200, CAST(0x0000A56C00000000 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (10, 6, N'用户管理', N'用户管理的', N'/User/Index', N'root/6/123', 0, 2, 200, CAST(0x0000A56C00000000 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Description], [Url], [SourcePath], [State], [MenuLevel], [Sort], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (11, 3, N'单据历史', N'管理员查看单据', N'/Record/List', N'root/3/123', 0, 2, 180, CAST(0x0000A56C00000000 AS DateTime), 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Password], [Email], [Mobile], [CompanyId], [CompanyName], [State], [UserType], [LastLoginTime], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (2, N'小新', N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'555@q.com', N'11', 1, N'百捷', 0, 2, CAST(0x0000A5FB014F9AFA AS DateTime), CAST(0x0000A56C00000000 AS DateTime), 1, 1, CAST(0x0000A5750081335F AS DateTime))
GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Password], [Email], [Mobile], [CompanyId], [CompanyName], [State], [UserType], [LastLoginTime], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (4, N'123456', N'TestUser', N'e10adc3949ba59abbe56e057f20f883e', N'231@qq.com', N'18664876671', 2, N'东莞', 1, 2, CAST(0x0000A5750081335F AS DateTime), CAST(0x0000A572008621C6 AS DateTime), 2, 3, CAST(0x0000A5750081335F AS DateTime))
GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Password], [Email], [Mobile], [CompanyId], [CompanyName], [State], [UserType], [LastLoginTime], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (5, N'1234567', N'1234567', N'c4ca4238a0b923820dcc509a6f75849b', N'11@11.cc', N'12345678901', 3, N'东风日产', 1, 2, CAST(0x0000A5750081335F AS DateTime), CAST(0x0000A5750081335F AS DateTime), 2, 2, CAST(0x0000A57500814175 AS DateTime))
GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Password], [Email], [Mobile], [CompanyId], [CompanyName], [State], [UserType], [LastLoginTime], [CreateTime], [CreatorId], [LastModifierId], [LastModifyTime]) VALUES (7, N'Eleven', N'12345678', N'123456', N'11@d', N'12', NULL, NULL, 1, 2, NULL, CAST(0x0000A63200000000 AS DateTime), 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMenuMapping] ON 

GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (1, 2, 1)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (2, 2, 7)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (3, 2, 3)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (4, 2, 9)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (5, 2, 11)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (6, 2, 6)
GO
INSERT [dbo].[UserMenuMapping] ([Id], [UserId], [MenuId]) VALUES (7, 2, 10)
GO
SET IDENTITY_INSERT [dbo].[UserMenuMapping] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级path/datetime+random' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'SourcePath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态  0正常 1冻结 2删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态  0正常 1冻结 2删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型  1 普通用户 2管理员 4超级管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
