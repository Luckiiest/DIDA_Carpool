/*
 Navicat Premium Data Transfer

 Source Server         : sqlserver
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : localhost:1433
 Source Catalog        : DIDA_DB
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 08/03/2022 20:26:19
*/

use master

go

if DB_ID('DIDA_DB') is not null
    drop database DIDA_DB
    
go

create database DIDA_DB

go

use DIDA_DB

go


-- ----------------------------
-- Table structure for Application
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type IN ('U'))
	DROP TABLE [dbo].[Application]
GO

CREATE TABLE [dbo].[Application] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [UserID] int  NOT NULL,
  [LineID] int  NOT NULL,
  [ShowOrLong] int  NOT NULL,
  [Status] varchar(255) COLLATE Chinese_PRC_CI_AS DEFAULT 2 NULL
)
GO

ALTER TABLE [dbo].[Application] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途申请表ID',
'SCHEMA', N'dbo',
'TABLE', N'Application',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请用户ID',
'SCHEMA', N'dbo',
'TABLE', N'Application',
'COLUMN', N'UserID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请的线路ID',
'SCHEMA', N'dbo',
'TABLE', N'Application',
'COLUMN', N'LineID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长短途ID，0为长，1为短',
'SCHEMA', N'dbo',
'TABLE', N'Application',
'COLUMN', N'ShowOrLong'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请状态 rejected失败（0） or fulfilled成功（1） or pending无状态（2）',
'SCHEMA', N'dbo',
'TABLE', N'Application',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户申请线路表',
'SCHEMA', N'dbo',
'TABLE', N'Application'
GO


-- ----------------------------
-- Records of Application
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Application] ON
GO

SET IDENTITY_INSERT [dbo].[Application] OFF
GO


-- ----------------------------
-- Table structure for ApplicationStatus
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationStatus]') AND type IN ('U'))
	DROP TABLE [dbo].[ApplicationStatus]
GO

CREATE TABLE [dbo].[ApplicationStatus] (
  [ID] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Name] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[ApplicationStatus] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请状态',
'SCHEMA', N'dbo',
'TABLE', N'ApplicationStatus',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态名称',
'SCHEMA', N'dbo',
'TABLE', N'ApplicationStatus',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请线路状态表',
'SCHEMA', N'dbo',
'TABLE', N'ApplicationStatus'
GO


-- ----------------------------
-- Records of ApplicationStatus
-- ----------------------------
INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'0', N'失败')
GO

INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'0-', N'已读失败')
GO

INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'1', N'成功')
GO

INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'1-', N'已读成功')
GO

INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'2', N'无状态')
GO

INSERT INTO [dbo].[ApplicationStatus] ([ID], [Name]) VALUES (N'2-', N'座位已满')
GO


-- ----------------------------
-- Table structure for CarType
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CarType]') AND type IN ('U'))
	DROP TABLE [dbo].[CarType]
GO

CREATE TABLE [dbo].[CarType] (
  [CarID] int  NOT NULL,
  [CarName] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[CarType] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'汽车类型ID',
'SCHEMA', N'dbo',
'TABLE', N'CarType',
'COLUMN', N'CarID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'汽车类型名称',
'SCHEMA', N'dbo',
'TABLE', N'CarType',
'COLUMN', N'CarName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'汽车类型表',
'SCHEMA', N'dbo',
'TABLE', N'CarType'
GO


-- ----------------------------
-- Records of CarType
-- ----------------------------
INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'1', N'其他')
GO

INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'2', N'轿车')
GO

INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'3', N'MPV')
GO

INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'4', N'SUV')
GO

INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'5', N'跑车')
GO

INSERT INTO [dbo].[CarType] ([CarID], [CarName]) VALUES (N'6', N'客车')
GO


-- ----------------------------
-- Table structure for LineMembers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[LineMembers]') AND type IN ('U'))
	DROP TABLE [dbo].[LineMembers]
GO

CREATE TABLE [dbo].[LineMembers] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [LineID] int  NOT NULL,
  [ShowOrLong] int  NOT NULL,
  [Members] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[LineMembers] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'线路成员表ID',
'SCHEMA', N'dbo',
'TABLE', N'LineMembers',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'线路ID',
'SCHEMA', N'dbo',
'TABLE', N'LineMembers',
'COLUMN', N'LineID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途 0/短途 1',
'SCHEMA', N'dbo',
'TABLE', N'LineMembers',
'COLUMN', N'ShowOrLong'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请的成员的用户ID',
'SCHEMA', N'dbo',
'TABLE', N'LineMembers',
'COLUMN', N'Members'
GO

EXEC sp_addextendedproperty
'MS_Description', N'线路成员汇总表',
'SCHEMA', N'dbo',
'TABLE', N'LineMembers'
GO


-- ----------------------------
-- Records of LineMembers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[LineMembers] ON
GO

SET IDENTITY_INSERT [dbo].[LineMembers] OFF
GO


-- ----------------------------
-- Table structure for LongInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[LongInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[LongInfo]
GO

CREATE TABLE [dbo].[LongInfo] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [UserTypeID] int  NOT NULL,
  [UserID] int  NOT NULL,
  [OpenCity] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CloseCity] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [DepartureTime] datetime  NOT NULL,
  [HoldNumberPeople] int  NOT NULL,
  [NumberParticipants] int  NOT NULL,
  [NumberApplicants] int  NOT NULL,
  [CarID] int  NOT NULL,
  [Message] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ReleaseTime] datetime  NOT NULL,
  [Price] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[LongInfo] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途信息ID',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户类型ID',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'UserTypeID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户ID',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'UserID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出发城市',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'OpenCity'
GO

EXEC sp_addextendedproperty
'MS_Description', N'目的城市',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'CloseCity'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出发时间',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'DepartureTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'可容纳人数',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'HoldNumberPeople'
GO

EXEC sp_addextendedproperty
'MS_Description', N'报名人数',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'NumberParticipants'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请人数',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'NumberApplicants'
GO

EXEC sp_addextendedproperty
'MS_Description', N'汽车类型',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'CarID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途留言',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'Message'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发布时间',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'ReleaseTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'价格',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo',
'COLUMN', N'Price'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途发布信息表',
'SCHEMA', N'dbo',
'TABLE', N'LongInfo'
GO


-- ----------------------------
-- Records of LongInfo
-- ----------------------------
SET IDENTITY_INSERT [dbo].[LongInfo] ON
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'27', N'1', N'38', N'邯郸', N'北京', N'2022-03-11 00:00:00.000', N'4', N'15', N'10', N'2', N'', N'2022-03-03 09:37:00.000', N'15')
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'38', N'1', N'38', N'邯郸', N'北京', N'2022-03-15 00:00:00.000', N'4', N'2', N'1', N'2', N'', N'2022-03-08 07:49:36.000', N'面议')
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'39', N'1', N'38', N'邯郸', N'南京', N'2022-03-11 00:00:00.000', N'4', N'3', N'1', N'4', N'', N'2022-03-08 07:50:17.000', N'面议')
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'40', N'1', N'38', N'邯郸', N'北京', N'2022-03-09 00:00:00.000', N'4', N'2', N'0', N'2', N'', N'2022-03-08 13:45:01.000', N'面议')
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'41', N'1', N'38', N'邯郸', N'北京', N'2022-03-09 00:00:00.000', N'4', N'2', N'0', N'1', N'', N'2022-03-08 13:47:54.000', N'面议')
GO

INSERT INTO [dbo].[LongInfo] ([ID], [UserTypeID], [UserID], [OpenCity], [CloseCity], [DepartureTime], [HoldNumberPeople], [NumberParticipants], [NumberApplicants], [CarID], [Message], [ReleaseTime], [Price]) VALUES (N'42', N'1', N'38', N'邯郸', N'南京', N'2022-03-08 00:00:00.000', N'4', N'2', N'0', N'2', N'', N'2022-03-08 20:05:20.000', N'15')
GO

SET IDENTITY_INSERT [dbo].[LongInfo] OFF
GO


-- ----------------------------
-- Table structure for ShowInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ShowInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[ShowInfo]
GO

CREATE TABLE [dbo].[ShowInfo] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [UserID] int  NOT NULL,
  [CarID] int  NOT NULL,
  [UserTypeID] int  NOT NULL,
  [OpenCity] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CloseCity] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [DepartureTime] datetime  NOT NULL,
  [Price] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [NumberParticipants] int  NOT NULL,
  [NumberApplicants] int  NOT NULL,
  [HoldNumberPeople] int  NOT NULL,
  [ReleaseTime] datetime  NOT NULL,
  [Message] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ShowInfo] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'短途信息ID',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户ID',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'UserID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'汽车类型ID',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'CarID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户类型ID',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'UserTypeID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出发地址',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'OpenCity'
GO

EXEC sp_addextendedproperty
'MS_Description', N'目的地址',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'CloseCity'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出发时间',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'DepartureTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'价格',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'Price'
GO

EXEC sp_addextendedproperty
'MS_Description', N'报名人数',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'NumberParticipants'
GO

EXEC sp_addextendedproperty
'MS_Description', N'申请人数',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'NumberApplicants'
GO

EXEC sp_addextendedproperty
'MS_Description', N'可容纳人数',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'HoldNumberPeople'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发布时间',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo',
'COLUMN', N'ReleaseTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'短途发布信息表',
'SCHEMA', N'dbo',
'TABLE', N'ShowInfo'
GO


-- ----------------------------
-- Records of ShowInfo
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ShowInfo] ON
GO

INSERT INTO [dbo].[ShowInfo] ([ID], [UserID], [CarID], [UserTypeID], [OpenCity], [CloseCity], [DepartureTime], [Price], [NumberParticipants], [NumberApplicants], [HoldNumberPeople], [ReleaseTime], [Message]) VALUES (N'4', N'38', N'1', N'1', N'中盛商城', N'天景路', N'2022-03-09 00:00:00.000', N'2', N'0', N'0', N'4', N'2022-03-08 13:46:15.000', N'')
GO

INSERT INTO [dbo].[ShowInfo] ([ID], [UserID], [CarID], [UserTypeID], [OpenCity], [CloseCity], [DepartureTime], [Price], [NumberParticipants], [NumberApplicants], [HoldNumberPeople], [ReleaseTime], [Message]) VALUES (N'5', N'38', N'1', N'1', N'南京路', N'天景路', N'2022-03-09 00:00:00.000', N'2', N'0', N'0', N'4', N'2022-03-08 19:44:36.000', N'')
GO

INSERT INTO [dbo].[ShowInfo] ([ID], [UserID], [CarID], [UserTypeID], [OpenCity], [CloseCity], [DepartureTime], [Price], [NumberParticipants], [NumberApplicants], [HoldNumberPeople], [ReleaseTime], [Message]) VALUES (N'6', N'38', N'3', N'1', N'中盛商城', N'天景路', N'2022-03-09 00:00:00.000', N'222', N'3', N'2', N'4', N'2022-03-08 13:46:15.000', N'')
GO

INSERT INTO [dbo].[ShowInfo] ([ID], [UserID], [CarID], [UserTypeID], [OpenCity], [CloseCity], [DepartureTime], [Price], [NumberParticipants], [NumberApplicants], [HoldNumberPeople], [ReleaseTime], [Message]) VALUES (N'7', N'38', N'4', N'1', N'南京路', N'天景路', N'2022-03-08 00:00:00.000', N'2', N'0', N'0', N'4', N'2022-03-08 20:00:01.000', N'')
GO

SET IDENTITY_INSERT [dbo].[ShowInfo] OFF
GO


-- ----------------------------
-- Table structure for ShowOrLong
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ShowOrLong]') AND type IN ('U'))
	DROP TABLE [dbo].[ShowOrLong]
GO

CREATE TABLE [dbo].[ShowOrLong] (
  [ID] int  NOT NULL,
  [Name] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[ShowOrLong] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'区分长途短途',
'SCHEMA', N'dbo',
'TABLE', N'ShowOrLong',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途/短途',
'SCHEMA', N'dbo',
'TABLE', N'ShowOrLong',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'长途 / 短途 区分表',
'SCHEMA', N'dbo',
'TABLE', N'ShowOrLong'
GO


-- ----------------------------
-- Records of ShowOrLong
-- ----------------------------
INSERT INTO [dbo].[ShowOrLong] ([ID], [Name]) VALUES (N'0', N'长途')
GO

INSERT INTO [dbo].[ShowOrLong] ([ID], [Name]) VALUES (N'1', N'短途')
GO


-- ----------------------------
-- Table structure for UserInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[UserInfo]
GO

CREATE TABLE [dbo].[UserInfo] (
  [UserID] int  IDENTITY(1,1) NOT NULL,
  [UserName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Phone] varchar(11) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [PassWord] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[UserInfo] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户ID',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'UserID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户呢称',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'UserName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户电话',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'Phone'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户密码',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'PassWord'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户信息表',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo'
GO


-- ----------------------------
-- Records of UserInfo
-- ----------------------------
SET IDENTITY_INSERT [dbo].[UserInfo] ON
GO

INSERT INTO [dbo].[UserInfo] ([UserID], [UserName], [Phone], [PassWord]) VALUES (N'36', N'abcd', N'13780066903', N'123456a')
GO

INSERT INTO [dbo].[UserInfo] ([UserID], [UserName], [Phone], [PassWord]) VALUES (N'38', N'abcdefgs', N'15533323694', N'123456a')
GO

SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO


-- ----------------------------
-- Table structure for UserType
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserType]') AND type IN ('U'))
	DROP TABLE [dbo].[UserType]
GO

CREATE TABLE [dbo].[UserType] (
  [UserTypeId] int  NOT NULL,
  [UserTypeName] varchar(5) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[UserType] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户类型ID',
'SCHEMA', N'dbo',
'TABLE', N'UserType',
'COLUMN', N'UserTypeId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户类型名称',
'SCHEMA', N'dbo',
'TABLE', N'UserType',
'COLUMN', N'UserTypeName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户类型表',
'SCHEMA', N'dbo',
'TABLE', N'UserType'
GO


-- ----------------------------
-- Records of UserType
-- ----------------------------
INSERT INTO [dbo].[UserType] ([UserTypeId], [UserTypeName]) VALUES (N'1', N'车主')
GO

INSERT INTO [dbo].[UserType] ([UserTypeId], [UserTypeName]) VALUES (N'2', N'乘客')
GO


-- ----------------------------
-- procedure structure for pass_application
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[pass_application]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[pass_application]
GO

CREATE PROCEDURE [dbo].[pass_application] ( @lineID INT, --线路ID
		@userID VARCHAR ( 10 ), --用户ID
		@showOrLong INT, --长途Or短途
		@status VARCHAR ( 10 ) --状态
		) AS BEGIN TRANSACTION -- 获取lineMembers中是否存在此线路
	SELECT
		* 
	FROM
		LineMembers 
	WHERE
		LineID =@lineID 
		AND ShowOrLong =@showOrLong
	IF
		@@ROWCOUNT <= 0 BEGIN--是否插入成员表成功
			INSERT INTO LineMembers ( LineID, ShowOrLong, Members )
		VALUES
			( @lineID,@showOrLong,@userID )
		IF
			@@ERROR <= 0 BEGIN--更改申请表中申请状态
				UPDATE Application 
				SET Status =@status 
			WHERE
				lineID =@lineID 
				AND UserID =@userID 
				AND ShowOrLong =@showOrLong
			IF
				@@ERROR <= 0 BEGIN--申请线路通过之后更改已通过人数
				IF
					@showOrLong = '0' BEGIN--长途更改通过人数
						UPDATE LongInfo 
						SET NumberParticipants = NumberParticipants + 1 
					WHERE
						ID =@lineID
					IF
						@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
						END --短途更改通过人数
					ELSE
					IF
						@showOrLong = '1' BEGIN
							UPDATE ShowInfo 
							SET NumberParticipants = NumberParticipants + 1 
						WHERE
							ID =@lineID
						IF
							@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
						END 
					END ELSE ROLLBACK TRANSACTION 
				END ELSE ROLLBACK TRANSACTION 
					END ELSE BEGIN--如果该线路已经有人申请过，则更改添加线路成员
					UPDATE LineMembers 
					SET Members = Members + '、' + @userID 
				WHERE
					LineID = @lineID 
					AND ShowOrLong = showOrLong
				IF
					@@ERROR <= 0 BEGIN--更改申请表中申请状态
						UPDATE Application 
						SET Status =@status 
					WHERE
						lineID =@lineID 
						AND UserID =@userID 
						AND ShowOrLong =@showOrLong
					IF
						@@ERROR <= 0 BEGIN--申请线路通过之后更改已通过人数
						IF
							@showOrLong = '0' BEGIN--长途更改通过人数
								UPDATE LongInfo 
								SET NumberParticipants = NumberParticipants + 1 
							WHERE
								ID =@lineID
							IF
								@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
								END --短途更改通过人数
							ELSE
							IF
								@showOrLong = '1' BEGIN
									UPDATE ShowInfo 
									SET NumberParticipants = NumberParticipants + 1 
								WHERE
									ID =@lineID
								IF
									@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
								END 
							END ELSE ROLLBACK TRANSACTION 
						END ELSE ROLLBACK TRANSACTION 
END
GO


-- ----------------------------
-- procedure structure for proc_checkLogin
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_checkLogin]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[proc_checkLogin]
GO

CREATE PROCEDURE [dbo].[proc_checkLogin]
(
	@phone varchar(11),
	@password varchar(50)
)
as
select * from UserInfo where Phone=phone and Password=@password
-- if @@rowcount>0
-- 	return 1
-- else
-- 	return 0

--例：
--exec proc_checkLogin "admin","password"
GO


-- ----------------------------
-- Auto increment value for Application
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Application]', RESEED, 50)
GO


-- ----------------------------
-- Checks structure for table Application
-- ----------------------------
ALTER TABLE [dbo].[Application] ADD CONSTRAINT [CK__LongAppli__ShowO__05D8E0BE] CHECK ([ShowOrLong]=(0) OR [ShowOrLong]=(1))
GO


-- ----------------------------
-- Primary Key structure for table Application
-- ----------------------------
ALTER TABLE [dbo].[Application] ADD CONSTRAINT [PK__LongAppl__3214EC27A1B85EA1] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table ApplicationStatus
-- ----------------------------
ALTER TABLE [dbo].[ApplicationStatus] ADD CONSTRAINT [PK__Applicat__3214EC27E8EDBA26] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CarType
-- ----------------------------
ALTER TABLE [dbo].[CarType] ADD CONSTRAINT [PK__CarType__68A0340E1F6C6864] PRIMARY KEY CLUSTERED ([CarID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for LineMembers
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[LineMembers]', RESEED, 53)
GO


-- ----------------------------
-- Primary Key structure for table LineMembers
-- ----------------------------
ALTER TABLE [dbo].[LineMembers] ADD CONSTRAINT [PK__LineMemb__3214EC271C817EF7] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for LongInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[LongInfo]', RESEED, 42)
GO


-- ----------------------------
-- Primary Key structure for table LongInfo
-- ----------------------------
ALTER TABLE [dbo].[LongInfo] ADD CONSTRAINT [PK__LongInfo__19DD81D0C51D06BF] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ShowInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ShowInfo]', RESEED, 7)
GO


-- ----------------------------
-- Primary Key structure for table ShowInfo
-- ----------------------------
ALTER TABLE [dbo].[ShowInfo] ADD CONSTRAINT [PK__ShowInfo__6DE3E0D2604C77F8] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table ShowOrLong
-- ----------------------------
ALTER TABLE [dbo].[ShowOrLong] ADD CONSTRAINT [PK__ShowOrLo__3214EC2782ECB162] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for UserInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[UserInfo]', RESEED, 39)
GO


-- ----------------------------
-- Indexes structure for table UserInfo
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [idx_userinfo_phone]
ON [dbo].[UserInfo] (
  [Phone] ASC
)
GO


-- ----------------------------
-- Uniques structure for table UserInfo
-- ----------------------------
ALTER TABLE [dbo].[UserInfo] ADD CONSTRAINT [UQ__UserInfo__5C7E359E89BF7B0A] UNIQUE NONCLUSTERED ([Phone] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UserInfo
-- ----------------------------
ALTER TABLE [dbo].[UserInfo] ADD CONSTRAINT [PK__UserInfo__1788CCAC1606BA97] PRIMARY KEY CLUSTERED ([UserID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UserType
-- ----------------------------
ALTER TABLE [dbo].[UserType] ADD CONSTRAINT [PK__UserType__40D2D8161C84A570] PRIMARY KEY CLUSTERED ([UserTypeId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Application
-- ----------------------------
ALTER TABLE [dbo].[Application] ADD CONSTRAINT [FK__Applicati__ShowO__1BC821DD] FOREIGN KEY ([ShowOrLong]) REFERENCES [dbo].[ShowOrLong] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Application] ADD CONSTRAINT [FK__Applicati__Statu__208CD6FA] FOREIGN KEY ([Status]) REFERENCES [dbo].[ApplicationStatus] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table LongInfo
-- ----------------------------
ALTER TABLE [dbo].[LongInfo] ADD CONSTRAINT [FK__LongInfo__UserTy__2C3393D0] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([UserTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[LongInfo] ADD CONSTRAINT [FK__LongInfo__CarID__2E1BDC42] FOREIGN KEY ([CarID]) REFERENCES [dbo].[CarType] ([CarID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[LongInfo] ADD CONSTRAINT [FK__LongInfo__UserID__2D27B809] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserInfo] ([UserID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ShowInfo
-- ----------------------------
ALTER TABLE [dbo].[ShowInfo] ADD CONSTRAINT [FK__ShowInfo__CarID__32E0915F] FOREIGN KEY ([CarID]) REFERENCES [dbo].[CarType] ([CarID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[ShowInfo] ADD CONSTRAINT [FK__ShowInfo__UserTy__37A5467C] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([UserTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[ShowInfo] ADD CONSTRAINT [FK__ShowInfo__UserID__31EC6D26] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserInfo] ([UserID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

