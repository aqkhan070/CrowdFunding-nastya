USE [master]
GO
/****** Object:  Database [Crowdfundingnastya]    Script Date: 01/05/2024 12:14:08 PM ******/
CREATE DATABASE [Crowdfundingnastya]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Crowdfunding-nastya', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Crowdfundingnastya_f69e1cb4996547a785241f5e4b0ef8ce.mdf' , SIZE = 8192KB , MAXSIZE = 10240000KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Crowdfunding-nastya_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Crowdfundingnastya_0ca0165151524bb38dc8b1c3e72c9be8.ldf' , SIZE = 8192KB , MAXSIZE = 10240000KB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Crowdfundingnastya] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Crowdfundingnastya].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Crowdfundingnastya] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET ARITHABORT OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Crowdfundingnastya] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Crowdfundingnastya] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Crowdfundingnastya] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Crowdfundingnastya] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET RECOVERY FULL 
GO
ALTER DATABASE [Crowdfundingnastya] SET  MULTI_USER 
GO
ALTER DATABASE [Crowdfundingnastya] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Crowdfundingnastya] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Crowdfundingnastya] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Crowdfundingnastya] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Crowdfundingnastya] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Crowdfundingnastya] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Crowdfundingnastya', N'ON'
GO
ALTER DATABASE [Crowdfundingnastya] SET QUERY_STORE = OFF
GO
USE [Crowdfundingnastya]
GO
/****** Object:  User [Crowdfundingnastya]    Script Date: 01/05/2024 12:14:09 PM ******/
CREATE USER [Crowdfundingnastya] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[Crowdfundingnastya]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Crowdfundingnastya]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Crowdfundingnastya]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Crowdfundingnastya]
GO
/****** Object:  Schema [Crowdfundingnastya]    Script Date: 01/05/2024 12:14:09 PM ******/
CREATE SCHEMA [Crowdfundingnastya]
GO
/****** Object:  Table [dbo].[tblAccessLevel]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccessLevel](
	[AccessId] [int] IDENTITY(1,1) NOT NULL,
	[EditAccess] [bit] NULL,
	[DeleteAccess] [bit] NULL,
	[CreateAccess] [bit] NULL,
	[MenuId] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK__tblAcces__4130D05F29B78AE5] PRIMARY KEY CLUSTERED 
(
	[AccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBlog]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBlog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](250) NOT NULL,
	[ThumbnailImage] [nvarchar](250) NULL,
	[BlogDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CategoryId] [int] NULL,
	[PriorityId] [int] NULL,
	[BlogTypeId] [int] NULL,
	[AttachedFileId] [int] NULL,
 CONSTRAINT [PK_Tlb_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBlogAttachedFiles]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBlogAttachedFiles](
	[AttachedFileId] [int] IDENTITY(1,1) NOT NULL,
	[AttachedFiles] [nvarchar](250) NULL,
	[BlogId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblAttachedFiles] PRIMARY KEY CLUSTERED 
(
	[AttachedFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCareer]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCareer](
	[CareerId] [int] IDENTITY(1,1) NOT NULL,
	[CareerTitle] [nvarchar](250) NOT NULL,
	[CareerThumbnailImage] [nvarchar](250) NULL,
	[CareerDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[EditBy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CategoryId] [int] NULL,
	[PriorityId] [int] NULL,
	[BlogTypeId] [int] NULL,
 CONSTRAINT [PK_tblCareer] PRIMARY KEY CLUSTERED 
(
	[CareerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime2](7) NULL,
	[isActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblContact]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContact](
	[Contact_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Subject] [nvarchar](250) NULL,
	[Message] [nvarchar](max) NULL,
	[Sent_Date] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED 
(
	[Contact_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEditPages]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEditPages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[About] [nvarchar](max) NULL,
	[TermsCondition] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[Privacy] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Facebook] [nvarchar](500) NULL,
	[Instagram] [nvarchar](500) NULL,
	[Google] [nvarchar](500) NULL,
	[Linkdin] [nvarchar](500) NULL,
	[Twitter] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblEditPages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLog]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Action] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMenu]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMenu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[ControllerName] [nvarchar](150) NULL,
	[ActionName] [nvarchar](150) NULL,
	[isParent] [bit] NULL,
	[ParentId] [int] NULL,
	[FontAwesome] [nvarchar](150) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NULL,
	[isDeleted] [bit] NULL,
	[ElementId] [nvarchar](500) NULL,
	[OrderBy] [int] NULL,
 CONSTRAINT [PK__tblMenu__C99ED230C55FB33D] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNotification]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNotification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tblNotification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPriority]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPriority](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblPriority] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProject]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProject](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Located] [nvarchar](150) NULL,
	[PostCode] [nvarchar](150) NULL,
	[FundraisingFor] [nvarchar](150) NULL,
	[Phone] [nvarchar](150) NULL,
	[Description] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](150) NULL,
	[story] [nvarchar](1500) NULL,
	[Goal] [nvarchar](500) NULL,
	[Deadline] [datetime] NULL,
	[Value] [float] NULL,
	[RaisedAmount] [float] NULL,
	[Skills] [nvarchar](1500) NULL,
	[VerificationCodeTo] [nvarchar](150) NULL,
	[PriorityId] [int] NULL,
	[StatusId] [int] NULL,
	[TypeId] [int] NULL,
	[CategoryId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_tblProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRole]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](500) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__tblRole__8AFACE1AF86C603A] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSetting]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSetting](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Port] [int] NULL,
	[SMTP] [nvarchar](max) NULL,
	[IsAdminReceived] [bit] NULL,
	[AdminEmail] [nvarchar](500) NULL,
	[clientId] [nvarchar](max) NULL,
	[clientSecret] [nvarchar](max) NULL,
	[AccountType] [varchar](100) NULL,
	[AdditionalCost] [float] NULL,
	[Feetype] [nvarchar](50) NULL,
	[FeeAmount] [float] NULL,
	[Editby] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_tblSetting] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblProjectStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubscriber]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubscriber](
	[SubscriberID] [int] IDENTITY(1,1) NOT NULL,
	[SubsName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Created_Date] [datetime] NULL,
 CONSTRAINT [PK_tblSubscriber] PRIMARY KEY CLUSTERED 
(
	[SubscriberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTransaction]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDateTime] [datetime] NULL,
	[PaypalPaymentId] [nvarchar](50) NULL,
	[PayerEmail] [nvarchar](50) NULL,
	[PayerFirstName] [nvarchar](50) NULL,
	[PayerLastName] [nvarchar](50) NULL,
	[PayerId] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[Currency] [nvarchar](50) NULL,
	[Comission] [float] NULL,
	[ComissionType] [nvarchar](50) NULL,
	[ComissionAmount] [float] NULL,
	[PaidAmount] [float] NULL,
	[AdditionalCharges] [float] NULL,
	[PaymentDescription] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[ProjectId] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[UserFirstName] [nvarchar](150) NULL,
	[UserLastName] [nvarchar](150) NULL,
	[UserEmail] [nvarchar](150) NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblType]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nchar](100) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[Phone] [nvarchar](150) NULL,
	[ImagePath] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[Description] [nvarchar](max) NULL,
	[Balance] [float] NULL,
	[RoleId] [int] NULL,
	[LastLogin] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK__tblUser__1788CC4CF61B627F] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVerificationCode]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVerificationCode](
	[VerificationCodeId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[ExpiryDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[isActive] [bit] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_tblVerificationCode] PRIMARY KEY CLUSTERED 
(
	[VerificationCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWithdraw]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWithdraw](
	[WithdrawId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 0) NULL,
	[AccountTitle] [nvarchar](255) NULL,
	[BankName] [nvarchar](255) NULL,
	[AccountDetail] [nvarchar](500) NULL,
	[ImagePath] [nvarchar](500) NULL,
	[TransactionNo] [nvarchar](500) NULL,
	[Reason] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [date] NULL,
	[EditBy] [int] NULL,
	[EditDate] [date] NULL,
 CONSTRAINT [PK_tblWithdraw] PRIMARY KEY CLUSTERED 
(
	[WithdrawId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWithdrawStatus]    Script Date: 01/05/2024 12:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWithdrawStatus](
	[WithdrawStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblWithdrawStatus] PRIMARY KEY CLUSTERED 
(
	[WithdrawStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblBlog] ON 

INSERT [dbo].[tblBlog] ([BlogId], [BlogTitle], [ThumbnailImage], [BlogDescription], [IsActive], [PublishDate], [CreatedDate], [CreatedBy], [EditDate], [EditBy], [IsDeleted], [CategoryId], [PriorityId], [BlogTypeId], [AttachedFileId]) VALUES (1, N'Many Children Are Suffering A Lot For Food.', N'/assets/admin/images/faq-img.png', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ‘Content here, content here’, making it look like readable English. Many desktop publishing packages and web page editors now.</p><p>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ‘Content here, content here’, making it look like readable English. Many desktop publishing packages and web page editors now.</p><h2><strong>Help the helpless who need you.</strong></h2><p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ‘Content here, content here’, making it look like readable English. Many desktop publishing packages and web page editors now.</p><p>Which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum genera tors on the Internet tend to repeat predefined chunks as necessary, making this the first true genera tor on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence</p>', 1, CAST(N'2024-01-03T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblBlog] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCareer] ON 

INSERT [dbo].[tblCareer] ([CareerId], [CareerTitle], [CareerThumbnailImage], [CareerDescription], [IsActive], [PublishDate], [CreatedDate], [CreatedBy], [EditDate], [EditBy], [IsDeleted], [CategoryId], [PriorityId], [BlogTypeId]) VALUES (1, N'Software Engineer', N'/assets/assets/img/demo-1.png', N'<p>In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.&nbsp;</p>', 1, CAST(N'2024-01-03T00:00:00.000' AS DateTime), CAST(N'2024-01-03T17:52:46.810' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[tblCareer] ([CareerId], [CareerTitle], [CareerThumbnailImage], [CareerDescription], [IsActive], [PublishDate], [CreatedDate], [CreatedBy], [EditDate], [EditBy], [IsDeleted], [CategoryId], [PriorityId], [BlogTypeId]) VALUES (2, N'Front End Developer', N'/assets/assets/img/demo-3.png', N'<p>In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.</p>', 1, CAST(N'2024-01-03T00:00:00.000' AS DateTime), CAST(N'2024-01-03T18:19:19.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[tblCareer] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [IsDeleted]) VALUES (1, N'Donation                                                                                            ', NULL, CAST(N'2024-01-03T22:20:03.8500000' AS DateTime2), 1, CAST(N'2024-01-04T22:32:18.9395099' AS DateTime2), 1, 0)
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [IsDeleted]) VALUES (2, N'Food                                                                                                ', NULL, CAST(N'2024-01-03T22:20:14.8533333' AS DateTime2), NULL, NULL, 1, 0)
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [IsDeleted]) VALUES (3, N'Club                                                                                                ', NULL, CAST(N'2024-01-03T22:20:22.6266667' AS DateTime2), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblContact] ON 

INSERT [dbo].[tblContact] ([Contact_ID], [Name], [Email], [Subject], [Message], [Sent_Date], [Status]) VALUES (0, N'Abdul Qadeer', N'abdulqadeerkhan070@gmail.com', N'03212121066', N'In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblContact] OFF
GO
SET IDENTITY_INSERT [dbo].[tblEditPages] ON 

INSERT [dbo].[tblEditPages] ([ID], [About], [TermsCondition], [Contact], [Privacy], [Email], [Phone], [Address], [Facebook], [Instagram], [Google], [Linkdin], [Twitter]) VALUES (1, N'<h2><strong>Welcome to My Business Shower – Where Ideas Take Flight!</strong></h2><p><br data-cke-filler="true"></p><p>Were delighted to celebrate the birth of your new business venture and assist you in launching your entrepreneurial journey with flair. Similar to a traditional baby shower that welcomes a new life, My Business Shower is dedicated to embracing and supporting your business with love and encouragement. Create a business shower by narrating your story, setting your goal, and sharing it with family and friends.</p><p><br data-cke-filler="true"></p><p><strong>About us:</strong><br>My Business Shower is created for those who want to make significant changes in their lives. Whether youre already an entrepreneur or aspire to be one, youve found the right platform. Sometimes all you need are funds to kickstart your journey or an extra push to elevate your existing small business. Create a virtual business shower, share it with friends and family, and let the momentum begin!</p><p><br data-cke-filler="true"></p><p><strong>Everything starts with a click!</strong><br>Established in 2024 in London, United Kingdom, My Business Shower was founded by a young female marketing professional. Her goal is to assist like-minded individuals in their journeys.</p><p><br data-cke-filler="true"></p><p><strong>Our Vision:</strong><br>We envision a world where innovative ideas, whether big or small, have the chance to thrive and leave a lasting impact. Our mission is to simplify the funding process through a secure and inclusive platform. We aim to empower individuals from all walks of life, allowing them to bring their passionate projects to life.</p><p><br data-cke-filler="true"></p><p><strong>Who We Are:</strong><br>Our team is a diverse collective of dreamers, thinkers, and doers, bound by a shared passion for innovation and progress. From tech enthusiasts and seasoned investors to creative minds and industry experts, we unite to support cutting-edge projects. Together, we strive to build a global community of change-makers and entrepreneurs.</p><p><br data-cke-filler="true"></p><p><strong>What Sets Us Apart:</strong><br>Our team is a diverse collective of dreamers, thinkers, and doers, bound by a shared passion for innovation and progress. From tech enthusiasts and seasoned investors to creative minds and industry experts, we unite to support cutting-edge projects. Together, we strive to build a global community of change-makers and entrepreneurs.</p><p><br data-cke-filler="true"></p><p><strong>Curated Projects:</strong><br>Ensuring the highest quality, each project on My Business Shower undergoes a rigorous evaluation process. We collaborate with industry experts to select ventures with the most significant potential for success.</p><p><br data-cke-filler="true"></p><p><strong>Global Reach:</strong><br>Innovation knows no boundaries, and neither do we. My Business Shower connects backers and creators from all corners of the world, fostering a collaborative environment that transcends geographical barriers.</p><p><br data-cke-filler="true"></p><p><strong>Secure Funding:</strong><br>We prioritize the security of your investments. Our platform incorporates the latest technology and best practices to ensure that your contributions are protected</p><p><br data-cke-filler="true"></p><p><strong>How it Works:</strong></p><ol><li>Create Your Business Shower: Explore a diverse range of projects across various industries and find the ones that resonate with you.</li><li>Tell Your Story: Back projects that ignite your passion and align with your investment goals. Every contribution, no matter the size, makes a difference.</li><li>Share with Friends &amp; Family: Connect with project creators, fellow backers, and industry experts. Share your insights, ask questions, and be an active part of the journey.</li><li>Withdraw the Funds and Invest in Your Business/Start-Up: Utilize the funds to bring your business dreams to life.</li></ol><p>Join us at My Business Shower and be part of a movement that leverages the collective power of the crowd to drive innovation, foster creativity, and build a brighter future for all. Together, lets turn dreams into reality!</p><p>Remember, every great idea begins with a single step – and that step starts with you.</p><p>Welcome to My Business Shower – Where Ideas Take Flight!</p>', N'<h2><strong>Welcome to My Business Shower–Where Ideas Take Flight!</strong></h2><p><br data-cke-filler="true"></p><p>Were thrilled to celebrate the birth of your new business venture and help you kickstart your entrepreneurial journey in style. Just like a traditional baby shower welcomes a new life into the world, My Business Shower is all about embracing your business and supporting it with love and encouragement. Create a business shower by simply telling your story, setting your goal and haring it with family &amp; friends.</p><p><br data-cke-filler="true"></p><p><strong>About us:</strong><br>My Business Shower is created for those who want to make big changes in their life. If you are or if you want to be an entrepreneur, you’re at the right platform. Sometimes you only need some funds to start, or you need an extra amount to boost your current small business. Create a virtual business shower, share it with friends and family and make the ball runs!</p><p><br data-cke-filler="true"></p><p><strong>Everything starts with a click!</strong><br>My business shower has been created in 2023 in London, United Kingdom from a young female marketing professional who wants to change not only her own life, but to helps other likeminded to change their life. She only needed a couple of grants to create her website.</p><p><br data-cke-filler="true"></p><p><strong>Our Vision:</strong><br>We envision a world where innovative ideas, big or small, have the opportunity to thrive and make a lasting impact. By providing a secure and inclusive platform, we aim to make the funding process as simple and easier as possible, and empower individuals from all walks of life to bring into reality to projects they believe in and they are passionate about.</p><p><br data-cke-filler="true"></p><p><strong>Who We Are:</strong><br>Our team consists of a diverse group of dreamers, thinkers, and doers, united by a common passion for innovation and progress. From tech enthusiasts and seasoned investors to creative minds and industry experts, we come together to support cutting-edge projects and create a global community of change makers and entrepreneurs.</p><p><br data-cke-filler="true"></p><p><strong>What Sets Us Apart:</strong><br>Transparency: We believe in complete transparency throughout the crowdfunding journey. From project selection to fund allocation, we keep our community informed at every step of the process.</p><p><br data-cke-filler="true"></p><p><strong>Curated Projects:</strong><br>To ensure the highest quality, each project on MyBusinessShower undergoes a rigorous evaluation process. We collaborate with industry experts to select ventures with the most significant potential for success.</p><p><br data-cke-filler="true"></p><p><strong>Global Reach:</strong><br>Innovation knows no boundaries, and neither do we. My Business Shower connects backers and creators from all corners of the world, fostering a collaborative environment that transcends geographical barriers.</p><p><br data-cke-filler="true"></p><p><strong>Secure Funding:</strong><br>We priorities the security of your investments. Our platform incorporates the latest technology and best practices to ensure that your contributions are protected.</p><p><br data-cke-filler="true"></p><p><strong>How its works:</strong></p><ol><li>Create your Business Shower: Explore a diverse range of projects across various industries and find the ones that resonate with you.</li><li>Tell your story: Back projects that ignite your passion and align with your investment goals. Every contribution, no matter the size, makes a difference.</li><li>Share with friend &amp; family: Connect with project creators, fellow backers, and industry experts. Share your insights, ask questions, and be an active part of the journey.</li><li>Withdraw the funds and invest it in your business/Start-Up</li><li>Find an investor &amp; expand: we have a wide portfolio of investors who are constantly looking for invest in startups</li></ol><p>Join us at My Business Shower and be part of a movement that leverages the collective power of the crowd to drive innovation, foster creativity, and build a brighter future for all. Together, lets make dreams a reality!</p><p>Remember, every great idea begins with a single step – and that step starts with you.</p><p>Welcome to My Business Shower – Where Ideas Take Flight!</p>', NULL, N'<h2><strong>Welcome to My Business Shower–Where Ideas Take Flight!</strong></h2><p><br data-cke-filler="true"></p><p>Were thrilled to celebrate the birth of your new business venture and help you kickstart your entrepreneurial journey in style. Just like a traditional baby shower welcomes a new life into the world, My Business Shower is all about embracing your business and supporting it with love and encouragement. Create a business shower by simply telling your story, setting your goal and haring it with family &amp; friends.</p><p><br data-cke-filler="true"></p><p><strong>About us:</strong><br>My Business Shower is created for those who want to make big changes in their life. If you are or if you want to be an entrepreneur, you’re at the right platform. Sometimes you only need some funds to start, or you need an extra amount to boost your current small business. Create a virtual business shower, share it with friends and family and make the ball runs!</p><p><br data-cke-filler="true"></p><p><strong>Everything starts with a click!</strong><br>My business shower has been created in 2023 in London, United Kingdom from a young female marketing professional who wants to change not only her own life, but to helps other likeminded to change their life. She only needed a couple of grants to create her website.</p><p><br data-cke-filler="true"></p><p><strong>Our Vision:</strong><br>We envision a world where innovative ideas, big or small, have the opportunity to thrive and make a lasting impact. By providing a secure and inclusive platform, we aim to make the funding process as simple and easier as possible, and empower individuals from all walks of life to bring into reality to projects they believe in and they are passionate about.</p><p><br data-cke-filler="true"></p><p><strong>Who We Are:</strong><br>Our team consists of a diverse group of dreamers, thinkers, and doers, united by a common passion for innovation and progress. From tech enthusiasts and seasoned investors to creative minds and industry experts, we come together to support cutting-edge projects and create a global community of change makers and entrepreneurs.</p><p><br data-cke-filler="true"></p><p><strong>What Sets Us Apart:</strong><br>Transparency: We believe in complete transparency throughout the crowdfunding journey. From project selection to fund allocation, we keep our community informed at every step of the process.</p><p><br data-cke-filler="true"></p><p><strong>Curated Projects:</strong><br>To ensure the highest quality, each project on MyBusinessShower undergoes a rigorous evaluation process. We collaborate with industry experts to select ventures with the most significant potential for success.</p><p><br data-cke-filler="true"></p><p><strong>Global Reach:</strong><br>Innovation knows no boundaries, and neither do we. My Business Shower connects backers and creators from all corners of the world, fostering a collaborative environment that transcends geographical barriers.</p><p><br data-cke-filler="true"></p><p><strong>Secure Funding:</strong><br>We prioritise the security of your investments. Our platform incorporates the latest technology and best practices to ensure that your contributions are protected.</p><p><br data-cke-filler="true"></p><p><strong>How its works:</strong></p><ol><li>Create your Business Shower: Explore a diverse range of projects across various industries and find the ones that resonate with you.</li><li>Tell your story: Back projects that ignite your passion and align with your investment goals. Every contribution, no matter the size, makes a difference.</li><li>Share with friend &amp; family: Connect with project creators, fellow backers, and industry experts. Share your insights, ask questions, and be an active part of the journey.</li><li>Withdraw the funds and invest it in your business/Start-Up</li><li>Find an investor &amp; expand: we have a wide portfolio of investors who are constantly looking for invest in startups</li></ol><p>Join us at My Business Shower and be part of a movement that leverages the collective power of the crowd to drive innovation, foster creativity, and build a brighter future for all. Together, lets make dreams a reality!</p><p>Remember, every great idea begins with a single step – and that step starts with you.</p><p>Welcome to My Business Shower – Where Ideas Take Flight!</p>', N'info@gmail.com', N'+(548) 1234-456-7890', N'4517 Washington Ave. Manchester Kentucky 39495', N'https://www.facebook.com/', N'https://www.instagram.com/', NULL, N'https://linkedin.com/', N'https://twitter.com/')
SET IDENTITY_INSERT [dbo].[tblEditPages] OFF
GO
SET IDENTITY_INSERT [dbo].[tblLog] ON 

INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (1, 1, N'Add User', CAST(N'2024-01-02T16:53:41.907' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (2, 1, N'Add User', CAST(N'2024-01-02T18:20:29.610' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (3, 1, N'Update User', CAST(N'2024-01-02T18:23:52.223' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (4, 1, N'Change Password', CAST(N'2024-01-02T19:14:08.170' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (5, 1, N'Change Password', CAST(N'2024-01-02T19:16:43.633' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (6, 1, N'Delete user', CAST(N'2024-01-03T15:59:27.317' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (7, 1, N'Login', CAST(N'2024-01-04T12:32:36.630' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (8, 1, N'Login', CAST(N'2024-01-04T12:45:32.197' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (9, 1, N'Login', CAST(N'2024-01-04T14:30:02.350' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (10, 1, N'Login', CAST(N'2024-01-04T14:33:23.440' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (11, 1, N'Login', CAST(N'2024-01-04T14:34:01.577' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (12, 1, N'Login', CAST(N'2024-01-04T14:35:55.150' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (13, 1, N'Login', CAST(N'2024-01-04T14:37:42.867' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (14, 1, N'Add Project', CAST(N'2024-01-04T14:38:13.767' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (15, 1, N'Login', CAST(N'2024-01-04T16:03:15.920' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (16, 1, N'Login', CAST(N'2024-01-04T16:58:13.147' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (17, 1, N'Login', CAST(N'2024-01-04T17:45:51.783' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (18, 1, N'Login', CAST(N'2024-01-04T18:47:11.097' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (19, 1, N'Login', CAST(N'2024-01-04T19:11:01.910' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (20, 1, N'Login', CAST(N'2024-01-04T19:42:28.283' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (21, 1, N'Login', CAST(N'2024-01-04T20:15:49.450' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (22, 1, N'Login', CAST(N'2024-01-04T20:20:58.340' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (23, 1, N'Login', CAST(N'2024-01-04T20:42:45.013' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (24, 1, N'Login', CAST(N'2024-01-04T20:43:32.620' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (25, 1, N'Login', CAST(N'2024-01-04T20:48:05.167' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (26, 1, N'Login', CAST(N'2024-01-04T20:58:04.283' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (27, 1, N'Login', CAST(N'2024-01-04T20:59:32.887' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (28, 1, N'Update User', CAST(N'2024-01-04T21:00:12.177' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (29, 1, N'Login', CAST(N'2024-01-04T21:04:49.763' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (30, 1, N'Login', CAST(N'2024-01-04T21:08:46.060' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (31, 1, N'Login', CAST(N'2024-01-04T21:32:22.930' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (32, 1, N'Update Project', CAST(N'2024-01-04T21:41:26.537' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (33, 1, N'Update Project', CAST(N'2024-01-04T21:41:36.757' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (34, 1, N'Update User', CAST(N'2024-01-04T22:49:44.300' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (35, 1, N'Login', CAST(N'2024-01-04T22:58:25.210' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (36, 1, N'Login', CAST(N'2024-01-04T23:04:05.773' AS DateTime))
INSERT [dbo].[tblLog] ([LogId], [UserId], [Action], [CreatedDate]) VALUES (37, 1, N'Login', CAST(N'2024-01-04T23:10:41.920' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblLog] OFF
GO
SET IDENTITY_INSERT [dbo].[tblPriority] ON 

INSERT [dbo].[tblPriority] ([PriorityId], [Priority], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [IsDeleted]) VALUES (1, N'High', NULL, CAST(N'2024-01-03T17:20:12.1966667' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[tblPriority] ([PriorityId], [Priority], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [IsDeleted]) VALUES (2, N'Medium', NULL, CAST(N'2024-01-03T17:20:17.4500000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[tblPriority] ([PriorityId], [Priority], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [IsDeleted]) VALUES (3, N'Low', NULL, CAST(N'2024-01-03T17:20:20.8800000' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[tblPriority] OFF
GO
SET IDENTITY_INSERT [dbo].[tblProject] ON 

INSERT [dbo].[tblProject] ([ProjectId], [Title], [Located], [PostCode], [FundraisingFor], [Phone], [Description], [ImagePath], [story], [Goal], [Deadline], [Value], [RaisedAmount], [Skills], [VerificationCodeTo], [PriorityId], [StatusId], [TypeId], [CategoryId], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (1, N'Test', NULL, NULL, NULL, NULL, N'<p>On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain.</p><p>These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided.</p><p>But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures.</p><h3><strong>We want to ensure the education for the kids.</strong></h3><p>These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure.</p><ul><li>The wise man therefore always holds in these matters.</li><li>In a free hour, when our power of choice and when nothing.</li><li>Else he endures pains to avoid worse pains.</li><li>We denounce with righteous indignation and dislike men.</li><li>Which is the same as saying through.</li></ul><p>But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures.</p>', N'\Uploading\Project\Project04012024143813.png', NULL, NULL, NULL, 15000, 674.91899999999987, N'Edu', NULL, 2, 5, NULL, 2, 1, CAST(N'2024-01-04T14:38:00.000' AS DateTime), 1, CAST(N'2024-01-04T21:41:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tblProject] OFF
GO
SET IDENTITY_INSERT [dbo].[tblRole] ON 

INSERT [dbo].[tblRole] ([RoleId], [Role], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (1, N'Admin', NULL, CAST(N'2024-01-02T15:12:15.730' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[tblRole] ([RoleId], [Role], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (2, N'Donee', NULL, CAST(N'2024-01-02T15:13:08.120' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[tblRole] ([RoleId], [Role], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (3, N'Donner ', NULL, CAST(N'2024-01-02T15:13:43.543' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[tblRole] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSetting] ON 

INSERT [dbo].[tblSetting] ([SettingId], [Email], [Password], [Port], [SMTP], [IsAdminReceived], [AdminEmail], [clientId], [clientSecret], [AccountType], [AdditionalCost], [Feetype], [FeeAmount], [Editby], [EditDate], [isActive]) VALUES (1, N'demo@technosolx.com', N'=^T1-KFmLA4v', 587, N'technosolx.com', NULL, NULL, N'ASSfieOXVGsRes3XQGvqMY0akWYgnxur_IeC4mT5TgXH6HWgmoU-x5JnXIbx2BSvAUso2TvSCptQyXyG', N'EPl8ktJj38jks_CpU2xB1IZvyfvikiwhoWlNxqYrI_mUjmIVmAgicTiGlhf2PQ_mPhRUwUEqFG_93mpi', N'Sandbox', 1, N'Fixed', 2, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblSetting] OFF
GO
SET IDENTITY_INSERT [dbo].[tblStatus] ON 

INSERT [dbo].[tblStatus] ([StatusId], [Status], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (5, N'Pending', NULL, CAST(N'2024-01-03T22:20:03.850' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[tblStatus] ([StatusId], [Status], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (9, N'Approved', NULL, CAST(N'2024-01-03T22:20:03.850' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[tblStatus] ([StatusId], [Status], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (10, N'Rejected', NULL, CAST(N'2024-01-03T22:20:03.850' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[tblStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSubscriber] ON 

INSERT [dbo].[tblSubscriber] ([SubscriberID], [SubsName], [Email], [Created_Date]) VALUES (0, NULL, N'abdulqadeerkhan070@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[tblSubscriber] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTransaction] ON 

INSERT [dbo].[tblTransaction] ([Id], [PaymentDateTime], [PaypalPaymentId], [PayerEmail], [PayerFirstName], [PayerLastName], [PayerId], [State], [Amount], [Currency], [Comission], [ComissionType], [ComissionAmount], [PaidAmount], [AdditionalCharges], [PaymentDescription], [UserId], [ProjectId], [Status], [UserFirstName], [UserLastName], [UserEmail], [Comment]) VALUES (2, CAST(N'2024-01-04T16:48:11.243' AS DateTime), N'PAYID-MWLJVZQ8BT90184MK844911B', N'sb-aen2018068512@business.example.com', N'John', N'Doe', N'QN94F2JTXLSGU', NULL, 600, NULL, 0.027, N'Fixed', 0.027, 599.973, NULL, NULL, NULL, 1, N'Successfull', N'Test', N'User', N'test@gmail.com', N'Fund')
INSERT [dbo].[tblTransaction] ([Id], [PaymentDateTime], [PaypalPaymentId], [PayerEmail], [PayerFirstName], [PayerLastName], [PayerId], [State], [Amount], [Currency], [Comission], [ComissionType], [ComissionAmount], [PaidAmount], [AdditionalCharges], [PaymentDescription], [UserId], [ProjectId], [Status], [UserFirstName], [UserLastName], [UserEmail], [Comment]) VALUES (3, CAST(N'2024-01-04T16:54:38.753' AS DateTime), N'PAYID-MWLJY3Q4V764120A2322453R', N'sb-aen2018068512@business.example.com', N'John', N'Doe', N'QN94F2JTXLSGU', NULL, 50, NULL, 0.027, N'Fixed', 0.027, 49.973, NULL, NULL, NULL, 1, N'Successfull', N'', N'', N'', N'')
INSERT [dbo].[tblTransaction] ([Id], [PaymentDateTime], [PaypalPaymentId], [PayerEmail], [PayerFirstName], [PayerLastName], [PayerId], [State], [Amount], [Currency], [Comission], [ComissionType], [ComissionAmount], [PaidAmount], [AdditionalCharges], [PaymentDescription], [UserId], [ProjectId], [Status], [UserFirstName], [UserLastName], [UserEmail], [Comment]) VALUES (4, CAST(N'2024-01-04T16:59:01.520' AS DateTime), N'PAYID-MWLJ25A0FU74645K9191183A', N'sb-aen2018068512@business.example.com', N'John', N'Doe', N'QN94F2JTXLSGU', NULL, 25, NULL, 0.027, N'Fixed', 0.027, 24.973, NULL, NULL, 1, 1, N'Successfull', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblTransaction] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([UserId], [username], [LastName], [FirstName], [Email], [Password], [Phone], [ImagePath], [Address], [Description], [Balance], [RoleId], [LastLogin], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (1, NULL, N'Admin', N'Admin', N'admin@gmail.com', N'MTIz', N'123456', N'\Uploading\User\User04012024210012.jpg', NULL, N'Test Admin', 175.02700000000004, 1, CAST(N'2024-01-04T23:10:41.913' AS DateTime), NULL, CAST(N'2024-01-02T16:50:09.690' AS DateTime), 1, CAST(N'2024-01-04T22:49:00.000' AS DateTime), 1, 0)
INSERT [dbo].[tblUser] ([UserId], [username], [LastName], [FirstName], [Email], [Password], [Phone], [ImagePath], [Address], [Description], [Balance], [RoleId], [LastLogin], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (2, NULL, N'Adame', N'Dave', N'daveadame@velzon.com', N'MTIzNA==', N'+(1) 987 6543', N'\Uploading\User\User02012024165316.jpg', NULL, N'Hi I''m Anna Adame,It will be as simple as Occidental; in fact, it will be Occidental. To an English person, it will seem like simplified English, as a skeptical Cambridge friend of mine told me what Occidental is European languages are members of the same family.', NULL, 2, NULL, 1, CAST(N'2024-01-02T16:53:00.000' AS DateTime), 1, CAST(N'2024-01-03T15:59:00.000' AS DateTime), 1, 1)
INSERT [dbo].[tblUser] ([UserId], [username], [LastName], [FirstName], [Email], [Password], [Phone], [ImagePath], [Address], [Description], [Balance], [RoleId], [LastLogin], [CreatedBy], [CreatedDate], [EditBy], [EditDate], [isActive], [isDeleted]) VALUES (3, NULL, N'Donner', N'Donner', N'Donner@gmail.com', N'MTIzNA==', N'2323324', NULL, NULL, N'Test Donner', NULL, 3, NULL, 1, CAST(N'2024-01-02T18:20:00.000' AS DateTime), 1, CAST(N'2024-01-02T00:00:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
SET IDENTITY_INSERT [dbo].[tblWithdraw] ON 

INSERT [dbo].[tblWithdraw] ([WithdrawId], [Amount], [AccountTitle], [BankName], [AccountDetail], [ImagePath], [TransactionNo], [Reason], [Status], [CreatedBy], [CreatedDate], [EditBy], [EditDate]) VALUES (1, CAST(100 AS Decimal(18, 0)), N'Abdul', N'CA', N'123', N'\Uploading\Slip\Slip04012024195221.png', N'125', NULL, 2, 1, CAST(N'2024-01-04' AS Date), 1, CAST(N'2024-01-04' AS Date))
INSERT [dbo].[tblWithdraw] ([WithdrawId], [Amount], [AccountTitle], [BankName], [AccountDetail], [ImagePath], [TransactionNo], [Reason], [Status], [CreatedBy], [CreatedDate], [EditBy], [EditDate]) VALUES (2, CAST(100 AS Decimal(18, 0)), N'Abdul', N'CA', N'123', NULL, NULL, N'NO', 3, 1, CAST(N'2024-01-04' AS Date), 1, CAST(N'2024-01-04' AS Date))
SET IDENTITY_INSERT [dbo].[tblWithdraw] OFF
GO
SET IDENTITY_INSERT [dbo].[tblWithdrawStatus] ON 

INSERT [dbo].[tblWithdrawStatus] ([WithdrawStatusId], [Status]) VALUES (1, N'Pending')
INSERT [dbo].[tblWithdrawStatus] ([WithdrawStatusId], [Status]) VALUES (2, N'Approved')
INSERT [dbo].[tblWithdrawStatus] ([WithdrawStatusId], [Status]) VALUES (3, N'Rejected')
SET IDENTITY_INSERT [dbo].[tblWithdrawStatus] OFF
GO
ALTER TABLE [dbo].[tblAccessLevel] ADD  CONSTRAINT [DF_tblAccessLevel_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblAccessLevel] ADD  CONSTRAINT [DF_tblAccessLevel_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblAccessLevel] ADD  CONSTRAINT [DF_tblAccessLevel_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tblBlog] ADD  CONSTRAINT [DF_tblBlog_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblBlog] ADD  CONSTRAINT [DF_tblBlog_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblBlogAttachedFiles] ADD  CONSTRAINT [DF_tblBlogAttachedFiles_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblBlogAttachedFiles] ADD  CONSTRAINT [DF_tblBlogAttachedFiles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblCareer] ADD  CONSTRAINT [DF_tblCareer_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblPriority] ADD  CONSTRAINT [DF_tblPriority_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblPriority] ADD  CONSTRAINT [DF_tblPriority_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblProject] ADD  CONSTRAINT [DF_tblProject_RaisedAmount]  DEFAULT ((0)) FOR [RaisedAmount]
GO
ALTER TABLE [dbo].[tblProject] ADD  CONSTRAINT [DF_tblProject_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblProject] ADD  CONSTRAINT [DF_tblProject_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblProject] ADD  CONSTRAINT [DF_tblProject_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tblRole] ADD  CONSTRAINT [DF_tblRole_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblRole] ADD  CONSTRAINT [DF_tblRole_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblRole] ADD  CONSTRAINT [DF_tblRole_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tblType] ADD  CONSTRAINT [DF_tblType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblType] ADD  CONSTRAINT [DF_tblType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tblAccessLevel]  WITH CHECK ADD  CONSTRAINT [FK_AccessManu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[tblMenu] ([MenuId])
GO
ALTER TABLE [dbo].[tblAccessLevel] CHECK CONSTRAINT [FK_AccessManu]
GO
ALTER TABLE [dbo].[tblAccessLevel]  WITH CHECK ADD  CONSTRAINT [FK_AccessRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tblRole] ([RoleId])
GO
ALTER TABLE [dbo].[tblAccessLevel] CHECK CONSTRAINT [FK_AccessRole]
GO
ALTER TABLE [dbo].[tblBlog]  WITH CHECK ADD  CONSTRAINT [FK_tblBlog_tblBlogAttachedFiles] FOREIGN KEY([AttachedFileId])
REFERENCES [dbo].[tblBlogAttachedFiles] ([AttachedFileId])
GO
ALTER TABLE [dbo].[tblBlog] CHECK CONSTRAINT [FK_tblBlog_tblBlogAttachedFiles]
GO
ALTER TABLE [dbo].[tblBlog]  WITH CHECK ADD  CONSTRAINT [FK_tblBlog_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[tblBlog] CHECK CONSTRAINT [FK_tblBlog_tblCategory]
GO
ALTER TABLE [dbo].[tblBlog]  WITH CHECK ADD  CONSTRAINT [FK_tblBlog_tblPriority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[tblPriority] ([PriorityId])
GO
ALTER TABLE [dbo].[tblBlog] CHECK CONSTRAINT [FK_tblBlog_tblPriority]
GO
ALTER TABLE [dbo].[tblBlog]  WITH CHECK ADD  CONSTRAINT [FK_tblBlog_tblType] FOREIGN KEY([BlogTypeId])
REFERENCES [dbo].[tblType] ([TypeId])
GO
ALTER TABLE [dbo].[tblBlog] CHECK CONSTRAINT [FK_tblBlog_tblType]
GO
ALTER TABLE [dbo].[tblBlogAttachedFiles]  WITH CHECK ADD  CONSTRAINT [FK_tblAttachedFiles_tblBlog] FOREIGN KEY([BlogId])
REFERENCES [dbo].[tblBlog] ([BlogId])
GO
ALTER TABLE [dbo].[tblBlogAttachedFiles] CHECK CONSTRAINT [FK_tblAttachedFiles_tblBlog]
GO
ALTER TABLE [dbo].[tblCareer]  WITH CHECK ADD  CONSTRAINT [FK_tblCareer_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[tblCareer] CHECK CONSTRAINT [FK_tblCareer_tblCategory]
GO
ALTER TABLE [dbo].[tblCareer]  WITH CHECK ADD  CONSTRAINT [FK_tblCareer_tblPriority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[tblPriority] ([PriorityId])
GO
ALTER TABLE [dbo].[tblCareer] CHECK CONSTRAINT [FK_tblCareer_tblPriority]
GO
ALTER TABLE [dbo].[tblCareer]  WITH CHECK ADD  CONSTRAINT [FK_tblCareer_tblType] FOREIGN KEY([BlogTypeId])
REFERENCES [dbo].[tblType] ([TypeId])
GO
ALTER TABLE [dbo].[tblCareer] CHECK CONSTRAINT [FK_tblCareer_tblType]
GO
ALTER TABLE [dbo].[tblNotification]  WITH CHECK ADD  CONSTRAINT [FK_tblNotification_tblUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([UserId])
GO
ALTER TABLE [dbo].[tblNotification] CHECK CONSTRAINT [FK_tblNotification_tblUser]
GO
ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_tblProject_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_tblProject_tblCategory]
GO
ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_tblProject_tblPriority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[tblPriority] ([PriorityId])
GO
ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_tblProject_tblPriority]
GO
ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_tblProject_tblStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[tblStatus] ([StatusId])
GO
ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_tblProject_tblStatus]
GO
ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_tblProject_tblType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[tblType] ([TypeId])
GO
ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_tblProject_tblType]
GO
ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblProject] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[tblProject] ([ProjectId])
GO
ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblProject]
GO
ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([UserId])
GO
ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblUser]
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tblRole] ([RoleId])
GO
ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblRole]
GO
ALTER TABLE [dbo].[tblWithdraw]  WITH CHECK ADD  CONSTRAINT [FK_tblWithdraw_tblUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tblUser] ([UserId])
GO
ALTER TABLE [dbo].[tblWithdraw] CHECK CONSTRAINT [FK_tblWithdraw_tblUser]
GO
ALTER TABLE [dbo].[tblWithdraw]  WITH CHECK ADD  CONSTRAINT [FK_tblWithdraw_tblUser1] FOREIGN KEY([EditBy])
REFERENCES [dbo].[tblUser] ([UserId])
GO
ALTER TABLE [dbo].[tblWithdraw] CHECK CONSTRAINT [FK_tblWithdraw_tblUser1]
GO
ALTER TABLE [dbo].[tblWithdraw]  WITH CHECK ADD  CONSTRAINT [FK_tblWithdraw_tblWithdrawStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[tblWithdrawStatus] ([WithdrawStatusId])
GO
ALTER TABLE [dbo].[tblWithdraw] CHECK CONSTRAINT [FK_tblWithdraw_tblWithdrawStatus]
GO
USE [master]
GO
ALTER DATABASE [Crowdfundingnastya] SET  READ_WRITE 
GO
