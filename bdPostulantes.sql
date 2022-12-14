USE [master]
GO
/****** Object:  Database [VSWEBTA1]    Script Date: 9/08/2022 22:36:05 ******/
CREATE DATABASE [VSWEBTA1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VSWEBTA1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VSWEBTA1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VSWEBTA1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VSWEBTA1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VSWEBTA1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VSWEBTA1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VSWEBTA1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VSWEBTA1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VSWEBTA1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VSWEBTA1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VSWEBTA1] SET ARITHABORT OFF 
GO
ALTER DATABASE [VSWEBTA1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VSWEBTA1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VSWEBTA1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VSWEBTA1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VSWEBTA1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VSWEBTA1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VSWEBTA1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VSWEBTA1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VSWEBTA1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VSWEBTA1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VSWEBTA1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VSWEBTA1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VSWEBTA1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VSWEBTA1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VSWEBTA1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VSWEBTA1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VSWEBTA1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VSWEBTA1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VSWEBTA1] SET  MULTI_USER 
GO
ALTER DATABASE [VSWEBTA1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VSWEBTA1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VSWEBTA1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VSWEBTA1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VSWEBTA1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VSWEBTA1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VSWEBTA1] SET QUERY_STORE = OFF
GO
USE [VSWEBTA1]
GO
/****** Object:  Table [dbo].[especialidad]    Script Date: 9/08/2022 22:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidad](
	[especialidadId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_especialidad] PRIMARY KEY CLUSTERED 
(
	[especialidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[postulante]    Script Date: 9/08/2022 22:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[postulante](
	[postulanteId] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [varchar](80) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[fechaPostulacion] [datetime] NOT NULL,
	[especialidadId] [int] NOT NULL,
 CONSTRAINT [PK_postulante] PRIMARY KEY CLUSTERED 
(
	[postulanteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 9/08/2022 22:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[rolId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 9/08/2022 22:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[usuarioId] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[bloqueado] [bit] NOT NULL,
	[rolId] [int] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[especialidad] ON 

INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (2, N'AERONAUTICA', N'Ingeniería Aeronáutica y del Espacio')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (3, N'ELECTRICA', N'Ingeniería Eléctrica')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (4, N'INDUSTRIAL', N'Ingeniería Industrial')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (5, N'MECANICA', N'Ingeniería Mecánica')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (6, N'SISTEMAS', N'Ingeniería de Sistemas')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (7, N'INFORMATICA', N'Ingeniería en Computación e Informática')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (8, N'MINAS', N'Ingeniería en Minas y Metalurgia (editado)')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (9, N'NAVAL', N'Ingeniería Naval')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (10, N'QUIMICA', N'Ingeniería Química y Biotecnología')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (11, N'CIVIL', N'Ingeniería Civil')
INSERT [dbo].[especialidad] ([especialidadId], [nombre], [descripcion]) VALUES (13, N'TELECOM', N'Ingeniería de Telecomunicaciones')
SET IDENTITY_INSERT [dbo].[especialidad] OFF
GO
SET IDENTITY_INSERT [dbo].[postulante] ON 

INSERT [dbo].[postulante] ([postulanteId], [nombreCompleto], [dni], [telefono], [fechaPostulacion], [especialidadId]) VALUES (1, N'Angel Marthans Ruiz', N'40813771', N'66666666', CAST(N'2019-11-22T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[postulante] ([postulanteId], [nombreCompleto], [dni], [telefono], [fechaPostulacion], [especialidadId]) VALUES (2, N'Tony Stark', N'66666666', N'965874588', CAST(N'2022-08-24T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[postulante] ([postulanteId], [nombreCompleto], [dni], [telefono], [fechaPostulacion], [especialidadId]) VALUES (7, N'Steve Rogers', N'58585858', N'10000001', CAST(N'2022-08-06T00:00:00.000' AS DateTime), 11)
SET IDENTITY_INSERT [dbo].[postulante] OFF
GO
SET IDENTITY_INSERT [dbo].[rol] ON 

INSERT [dbo].[rol] ([rolId], [nombre], [descripcion]) VALUES (1, N'ADM', N'Administrador')
INSERT [dbo].[rol] ([rolId], [nombre], [descripcion]) VALUES (2, N'REC', N'Recepcionista')
SET IDENTITY_INSERT [dbo].[rol] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([usuarioId], [codigo], [email], [nombre], [apellido], [password], [bloqueado], [rolId]) VALUES (1, N'user1', N'user1@gmail.com', N'Usuario', N'Uno', N'123456', 0, 1)
INSERT [dbo].[usuario] ([usuarioId], [codigo], [email], [nombre], [apellido], [password], [bloqueado], [rolId]) VALUES (2, N'user2', N'user2@gmail.com', N'Usuario', N'Dos', N'123456', 0, 2)
INSERT [dbo].[usuario] ([usuarioId], [codigo], [email], [nombre], [apellido], [password], [bloqueado], [rolId]) VALUES (3, N'user3', N'user3@gmail.com', N'Usuario', N'Tres', N'123456', 1, 2)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[postulante]  WITH CHECK ADD  CONSTRAINT [FK_postulante_especialidad] FOREIGN KEY([especialidadId])
REFERENCES [dbo].[especialidad] ([especialidadId])
GO
ALTER TABLE [dbo].[postulante] CHECK CONSTRAINT [FK_postulante_especialidad]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([rolId])
REFERENCES [dbo].[rol] ([rolId])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
USE [master]
GO
ALTER DATABASE [VSWEBTA1] SET  READ_WRITE 
GO
