USE [master]
GO
/****** Object:  Database [CiberCompany]    Script Date: 5/26/2021 9:05:18 AM ******/
CREATE DATABASE [CiberCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CiberCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CiberCompany.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CiberCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CiberCompany_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CiberCompany] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CiberCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CiberCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CiberCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CiberCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CiberCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CiberCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [CiberCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CiberCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CiberCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CiberCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CiberCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CiberCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CiberCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CiberCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CiberCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CiberCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CiberCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CiberCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CiberCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CiberCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CiberCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CiberCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CiberCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CiberCompany] SET RECOVERY FULL 
GO
ALTER DATABASE [CiberCompany] SET  MULTI_USER 
GO
ALTER DATABASE [CiberCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CiberCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CiberCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CiberCompany] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CiberCompany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CiberCompany] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CiberCompany', N'ON'
GO
ALTER DATABASE [CiberCompany] SET QUERY_STORE = OFF
GO
USE [CiberCompany]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/26/2021 9:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/26/2021 9:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/26/2021 9:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [float] NULL,
	[OrderDate] [date] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/26/2021 9:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductIdId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
	[Price] [float] NULL,
	[Description] [nvarchar](500) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductIdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (1, N'Cat1', N'Cat1')
INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (2, N'Cat2', N'Cat2')
INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (3, N'Cat3', N'Cat3')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [Name], [Address]) VALUES (1, N'Cus1', N'Ha Noi')
INSERT [dbo].[Customer] ([CustomerId], [Name], [Address]) VALUES (2, N'Cus2', N'Ho Chi Minh')
INSERT [dbo].[Customer] ([CustomerId], [Name], [Address]) VALUES (3, N'Cus3', N'Hai Duong')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (1, 1, 1, 2000, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (2, 1, 2, 1500, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (3, 2, 1, 3000, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (4, 2, 3, 2, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (6, 1, 1, 2, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (11, 2, 1, 2, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (12, 2, 1, 1, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (13, 2, 1, 3, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (14, 2, 3, 1, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (15, 1, 4, 56, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (16, 1, 1, 1, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [ProductId], [Amount], [OrderDate]) VALUES (17, 3, 3, 1, CAST(N'2021-05-26' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (1, N'Prod1', 1, 1000, N'Prod1', 7)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (2, N'Prod2', 1, 500, N'Prod2', 2)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (3, N'Prod3', 1, 200, N'Prod3', 1)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (4, N'Prod4', 2, 1000, N'Prod4', 10)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (5, N'Prod5', 2, 500, N'Prod5', 5)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (6, N'Prod6', 2, 200, N'Prod6', 3)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (7, N'Prod7', 3, 1000, N'Prod7', 10)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (8, N'Prod8', 3, 500, N'Prod8', 5)
INSERT [dbo].[Product] ([ProductIdId], [Name], [CategoryId], [Price], [Description], [Quantity]) VALUES (9, N'Prod9', 3, 200, N'Prod9', 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductIdId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [CiberCompany] SET  READ_WRITE 
GO
