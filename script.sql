USE [Proje]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_CompanyUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimType]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Claim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShiftNumber] [int] NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userr]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCompany]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAnnouncement]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAnnouncement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnnouncementId] [int] NULL,
	[UserId] [int] NULL,
	[Details] [nvarchar](250) NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserAnnouncement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShiftPrice]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShiftId] [int] NULL,
	[Price] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ShiftPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[CardNumber] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyShift]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyShift](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[ShiftId] [int] NULL,
 CONSTRAINT [PK_CompanyShift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyAnnouncement]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyAnnouncement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[AnnouncementId] [int] NULL,
 CONSTRAINT [PK_CompanyAnnouncement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeShift]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeShift](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShiftId] [int] NULL,
	[EmployeeId] [int] NULL,
	[Start] [smalldatetime] NULL,
	[Finish] [smalldatetime] NULL,
 CONSTRAINT [PK_EmployeeShift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeClaim]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimTypeId] [int] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_EmployeeClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimOther]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimOther](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeClaimId] [int] NULL,
	[Details] [nvarchar](250) NULL,
 CONSTRAINT [PK_ClaimOther] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimHoliday]    Script Date: 05/23/2018 00:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimHoliday](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeClaimId] [int] NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
 CONSTRAINT [PK_ClaimHoliday] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ClaimHoliday_EmployeeClaim]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[ClaimHoliday]  WITH CHECK ADD  CONSTRAINT [FK_ClaimHoliday_EmployeeClaim] FOREIGN KEY([EmployeeClaimId])
REFERENCES [dbo].[EmployeeClaim] ([Id])
GO
ALTER TABLE [dbo].[ClaimHoliday] CHECK CONSTRAINT [FK_ClaimHoliday_EmployeeClaim]
GO
/****** Object:  ForeignKey [FK_ClaimOther_EmployeeClaim1]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[ClaimOther]  WITH CHECK ADD  CONSTRAINT [FK_ClaimOther_EmployeeClaim1] FOREIGN KEY([EmployeeClaimId])
REFERENCES [dbo].[EmployeeClaim] ([Id])
GO
ALTER TABLE [dbo].[ClaimOther] CHECK CONSTRAINT [FK_ClaimOther_EmployeeClaim1]
GO
/****** Object:  ForeignKey [FK_CompanyAnnouncement_Announcement]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[CompanyAnnouncement]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAnnouncement_Announcement] FOREIGN KEY([AnnouncementId])
REFERENCES [dbo].[Announcement] ([Id])
GO
ALTER TABLE [dbo].[CompanyAnnouncement] CHECK CONSTRAINT [FK_CompanyAnnouncement_Announcement]
GO
/****** Object:  ForeignKey [FK_CompanyAnnouncement_Company]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[CompanyAnnouncement]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAnnouncement_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[CompanyAnnouncement] CHECK CONSTRAINT [FK_CompanyAnnouncement_Company]
GO
/****** Object:  ForeignKey [FK_CompanyShift_Company1]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[CompanyShift]  WITH CHECK ADD  CONSTRAINT [FK_CompanyShift_Company1] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[CompanyShift] CHECK CONSTRAINT [FK_CompanyShift_Company1]
GO
/****** Object:  ForeignKey [FK_CompanyShift_Shift1]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[CompanyShift]  WITH CHECK ADD  CONSTRAINT [FK_CompanyShift_Shift1] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[CompanyShift] CHECK CONSTRAINT [FK_CompanyShift_Shift1]
GO
/****** Object:  ForeignKey [FK_Employee_Company]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Company]
GO
/****** Object:  ForeignKey [FK_Employee_CompanyUser]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_CompanyUser] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_CompanyUser]
GO
/****** Object:  ForeignKey [FK_EmployeeClaim_Claim]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[EmployeeClaim]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeClaim_Claim] FOREIGN KEY([ClaimTypeId])
REFERENCES [dbo].[ClaimType] ([Id])
GO
ALTER TABLE [dbo].[EmployeeClaim] CHECK CONSTRAINT [FK_EmployeeClaim_Claim]
GO
/****** Object:  ForeignKey [FK_EmployeeClaim_Employee1]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[EmployeeClaim]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeClaim_Employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeClaim] CHECK CONSTRAINT [FK_EmployeeClaim_Employee1]
GO
/****** Object:  ForeignKey [FK_EmployeeShift_Employee]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[EmployeeShift]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeShift_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeShift] CHECK CONSTRAINT [FK_EmployeeShift_Employee]
GO
/****** Object:  ForeignKey [FK_EmployeeShift_Shift]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[EmployeeShift]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeShift_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[EmployeeShift] CHECK CONSTRAINT [FK_EmployeeShift_Shift]
GO
/****** Object:  ForeignKey [FK_ShiftPrice_Shift]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[ShiftPrice]  WITH CHECK ADD  CONSTRAINT [FK_ShiftPrice_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[ShiftPrice] CHECK CONSTRAINT [FK_ShiftPrice_Shift]
GO
/****** Object:  ForeignKey [FK_UserAnnouncement_Announcement]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserAnnouncement]  WITH CHECK ADD  CONSTRAINT [FK_UserAnnouncement_Announcement] FOREIGN KEY([AnnouncementId])
REFERENCES [dbo].[Announcement] ([Id])
GO
ALTER TABLE [dbo].[UserAnnouncement] CHECK CONSTRAINT [FK_UserAnnouncement_Announcement]
GO
/****** Object:  ForeignKey [FK_UserAnnouncement_User]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserAnnouncement]  WITH CHECK ADD  CONSTRAINT [FK_UserAnnouncement_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserAnnouncement] CHECK CONSTRAINT [FK_UserAnnouncement_User]
GO
/****** Object:  ForeignKey [FK_UserCompany_Company]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserCompany]  WITH CHECK ADD  CONSTRAINT [FK_UserCompany_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[UserCompany] CHECK CONSTRAINT [FK_UserCompany_Company]
GO
/****** Object:  ForeignKey [FK_UserCompany_Userr]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserCompany]  WITH CHECK ADD  CONSTRAINT [FK_UserCompany_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserCompany] CHECK CONSTRAINT [FK_UserCompany_Userr]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 05/23/2018 00:56:28 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
