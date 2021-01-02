USE [master]
GO
/****** Object:  Database [PR_r0675759]    Script Date: 2/01/2021 21:35:56 ******/
CREATE DATABASE [PR_r0675759]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PR_r0675759mdf', FILENAME = N'C:\DATA\PR_r0675759.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PR_r0675759ldf', FILENAME = N'C:\DATA\PR_r0675759_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PR_r0675759] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PR_r0675759].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PR_r0675759] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PR_r0675759] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PR_r0675759] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PR_r0675759] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PR_r0675759] SET ARITHABORT OFF 
GO
ALTER DATABASE [PR_r0675759] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PR_r0675759] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PR_r0675759] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PR_r0675759] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PR_r0675759] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PR_r0675759] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PR_r0675759] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PR_r0675759] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PR_r0675759] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PR_r0675759] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PR_r0675759] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PR_r0675759] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PR_r0675759] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PR_r0675759] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PR_r0675759] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PR_r0675759] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PR_r0675759] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PR_r0675759] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PR_r0675759] SET  MULTI_USER 
GO
ALTER DATABASE [PR_r0675759] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PR_r0675759] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PR_r0675759] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PR_r0675759] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PR_r0675759] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PR_r0675759', N'ON'
GO
ALTER DATABASE [PR_r0675759] SET QUERY_STORE = OFF
GO
USE [PR_r0675759]
GO
/****** Object:  User [pr__r0675759]    Script Date: 2/01/2021 21:35:56 ******/
CREATE USER [pr__r0675759] FOR LOGIN [pr__r0675759] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [pr__r0675759]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Voornaam] [nvarchar](max) NULL,
	[Achternaam] [nvarchar](max) NULL,
	[Geboortedatum] [datetime2](7) NULL,
	[Straat] [nvarchar](max) NULL,
	[Huisnummer] [nvarchar](max) NULL,
	[Postcode] [nvarchar](max) NULL,
	[Gemeente] [nvarchar](max) NULL,
	[Licentiecode] [nvarchar](max) NULL,
	[Rekeningnummer] [nvarchar](max) NULL,
	[Land] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klanten]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klanten](
	[PersoonID] [int] NOT NULL,
	[KlantID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Klanten] PRIMARY KEY CLUSTERED 
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log_Oefeningen]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Oefeningen](
	[Log_OefeningID] [int] IDENTITY(1,1) NOT NULL,
	[OefeningID] [int] NOT NULL,
	[LogID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Log_Oefeningen] PRIMARY KEY CLUSTERED 
(
	[Log_OefeningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[KlantID] [int] NOT NULL,
	[Review] [nvarchar](max) NULL,
	[Trainer] [nvarchar](max) NULL,
	[TrainerNodig] [bit] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[klant_PersoonID] [int] NULL,
 CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oefeningen]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oefeningen](
	[OefeningID] [int] IDENTITY(1,1) NOT NULL,
	[Videolink] [nvarchar](max) NULL,
	[Afbeelding] [varbinary](max) NULL,
	[Naam] [nvarchar](max) NOT NULL,
	[Omschrijving] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Oefeningen] PRIMARY KEY CLUSTERED 
(
	[OefeningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Orderdatum] [datetime2](7) NOT NULL,
	[Leverdatum] [datetime2](7) NULL,
	[Betalingsdatum] [datetime2](7) NOT NULL,
	[CustomUserID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personen]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personen](
	[PersoonID] [int] IDENTITY(1,1) NOT NULL,
	[Profielfoto] [varbinary](max) NULL,
	[Voornaam] [nvarchar](max) NULL,
	[Achternaam] [nvarchar](max) NULL,
	[Wachtwoord] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Adres] [nvarchar](max) NULL,
	[Postcode] [nvarchar](max) NULL,
	[Gemeente] [nvarchar](max) NULL,
	[Land] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Personen] PRIMARY KEY CLUSTERED 
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producten]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producten](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NULL,
	[Omschrijving] [nvarchar](max) NULL,
	[Licentiecode] [nvarchar](max) NULL,
	[Prijs] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Producten] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserveringen]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserveringen](
	[ReserveringID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[Tijdstip] [datetime2](7) NOT NULL,
	[Tijdsduur] [int] NOT NULL,
 CONSTRAINT [PK_Reserveringen] PRIMARY KEY CLUSTERED 
(
	[ReserveringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tijdslots]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tijdslots](
	[TijdslotID] [int] IDENTITY(1,1) NOT NULL,
	[ReserveringID] [int] NOT NULL,
	[CustomUserID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Tijdslots] PRIMARY KEY CLUSTERED 
(
	[TijdslotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[PersoonID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
	[Functie] [nvarchar](max) NOT NULL,
	[Specialisatie] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Trainers] PRIMARY KEY CLUSTERED 
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Werkgevers]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Werkgevers](
	[PersoonID] [int] NOT NULL,
	[WerkgeverID] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Werkgevers] PRIMARY KEY CLUSTERED 
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workouts]    Script Date: 2/01/2021 21:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workouts](
	[WorkoutID] [int] IDENTITY(1,1) NOT NULL,
	[Videolink] [nvarchar](max) NULL,
	[Afbeelding] [varbinary](max) NULL,
	[Naam] [nvarchar](max) NULL,
	[Omschrijving] [nvarchar](max) NULL,
 CONSTRAINT [PK_Workouts] PRIMARY KEY CLUSTERED 
(
	[WorkoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201124233121_InitialCreate', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201209133514_Updateworkouts', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201227112738_UpdateItems', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201227122138_Updateuser', N'3.1.10')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202012061450238_InitialCreate', N'Fitnessclub_DAL.Migrations.Configuration', 0x1F8B0800000000000400DD5CCD6EE33812BE2FB0EF20E834B3C8D849F76526886790763A03A3F38738DDBD37839668471B89F28A7426C1629F6C0EFB48FB0A4BFD51FC93444AB29D0DFA1293E2576455B1582C56F57FFFFCCFD96F2F51E83CC30407319AB827A363D781C88BFD00AD27EE96AC7EFAD9FDEDD7BFFEE5ECB31FBD38DFCAEF3EA6DFD191084FDC474236A7E331F61E6104F0280ABC24C6F18A8CBC381A033F1E7F383EFE657C72328614C2A5588E7376BF45248860F683FE9CC6C8831BB205E175ECC31017EDB4679EA13A37208278033C38712F038220C65EB85D2E2ECEAF5CE73C0C009DC61C862BD70108C504103AC9D3AF18CE4912A3F57C431B40F8F0BA81F4BB1508312C267F5A7D6EBA8EE30FE93AC6D5C012CADB6212479680271F0BC68CE5E19DD8EB32C651D67DA62C26AFE9AA33F64DDC2F2140C475644AA7D33049BF52583BCA8531CAC61D3952EF11D306AA34E9BF2367BA0DC936811304B72401E19173B75D8681F705BE3EC44F104DD0360C5DE713C030A7978A6C74475162BA5E6EEA74F27749BC810979E5A73EBB709D7CE00C918F1F5CE786E28165089950C722C80D780ED6D91A25B8AB788D5DE71E8659277E0C36C56468C7E22967D3651247F771987F9D372E1E40B286B4EF21967BE6F136F1A4199C8D2B11340A86C274100B1D35985044BED13EA18193C73D5C55934E0522B17C2C8F9525590C6B9623C785398913F83B44300104FA77801098D0BD35F361C645650283288E04720F9F03F84789418D0A358EAE730D5EAE205A93C7894BFFA40A13BC40BF6C2970BFA280DA523A8824DB56320F0908E83AF745E7861AF97549EC534C151A206BD65C00B28D4A10FA033E50B3DE6367169BCF7E6B961B50DD9AE5A6B5300E8B5BB88288721FA2DAB9949F2CB2DD2B4E89EFD31A0DE183BEB683A17533226CF881AD099B4747B3228CDF977D31A7D98C6364162D34B8BFDAEA369456AF4D675569A9666A0232BFFBAA19D67CA2ECAFBAEF7A6DB31E5BEC2D6CAF3E5BEB10DBEA5BE0C3380CD0D3CE0FC3F3D512C2D0CFC08BA3304020793523D58C7D034034C0022C4DC96D44EF0A49F08F676E4D3BA4DEE71CEDB1EB65F3D4661D3AEDFAF26E62BFE98B91C3DD9ACE9798F67AA4104B071B504CA98B09E086EECB02D09FAB80EA484CE2E137E6B7384ED0309BB3C5BA788FE9B2F741EA3BA0B4FEA00BF3F76F723E472008F74FF6DC4F20DE3963EF624CD2AF774EE8771841BA39764FE80AA02194A4934965975C6B935A8C3C6C20AA98445F77FF728B3C120C21694BC2F30DF402100618EC81BCB1527C87C9D31A3E77520B36F6B08AC1A6D1573566F8DC8F02641798A9E3F439C6319577CA48CE2BCBC328E22C3E23DFA98DA954BCC86E8DD7948BC186F28D529CB87F5356A4C362B7B40AAB88478B68C7A3D189BC366E15ED8B132EB84DF3D2DF7685A5729115BB35EB03408D6C3C716517EE165DC01012E89C7BF983C214600FF8AA0651E1FB620BF5FA60923A5A209C528F9BA4568BA82E6280BC6003C296894BE3CCA3C1E9D41811B9E7026E204A9DC11691F4A2CE88480C6BE38F85CED5DD61EAD4A3F5425369499DF60DAA2AED33D3EBAFC5DEE8A48D2D7C32518BFAA8879566B6F0A5FF4C06D7D2FC30A06348E6AD944E47753C661F04A9F3AC9CB75F312C8E5CACBD6BE6D8734884B7B4EAF8E12D9C622395A18BEF71F2146F490D04A7642D587CF440413246C98E7AA4C560B10009821381B8B2E2B182EB575E32644D683A84D9544B962B7AD474EC72A3AB35CAB6415C8AE132C580B27EB5F567B2D9A92CAE9DD399161E688FE116467660436D184BE586D16961755E70CBE1493770A6CDCE1B72BB8151A53BCA2C5095D031CE333ACACC8F714DEAC7D935D86CE8B4B85490A2C599E77920D39FE6F63912518E31F6B0265582CD9651227102D650EAA5A4E94C2F8304930B40C012A4CEF8D48F94CF74F6B6C6FC9414252BA4CAB0344AE580F46FC5BA67D7A32F3A0B53B1F192AE2C4ACFB82C4EC7893C1BA7D2CEC6CE3D1082A43E38388DC36D845AC28D4D58ECB99E47628D2ACED9585A8E72B62A2CB3E1E90CA77FDFAE7E90995B2CEEC70EFCD5DE26F7C55F21AA2AA0F11DE67855209507AB5ACD91F848298FC5B79BA3F1C1501E8D6F37472BC29B3C50D164B1BE3C56292C2D6FB2901E8B440AA263ADE64855A89147AA5ACD91F258228F92B7EC7DAFCA5BB40C34DAEFD062243ECC16E5228C3C16D76C8EC5C28C3C126B34C791A2863C9AD47570B157A1447BC1B3B10712BD104314CC16DF618EC742893C166B1C5E54657FE5D018B93B9917DE47E69A5B8581B4B5A36ACD5C1E6112EC9C3EE8548F61EBDCD4E194E9883C4CD9666D67B456A6034E914DA8012B7ACC118B9C421EAA687A4B2A5BDD8B7AAA6E15E3E8A4C30DC31B9459489693B4BA2111AF09B50EB11B9ACD863B9012345EDFCD55A087F8ED453FAC90B8342DC1FFAF9A2D1C642E114BF092B97673B41BE5227163798510D3A8045E093DFB574731ECA21AA622F0D86C748A8F0C0EC53472A43120427C51E5818DB3944335B84CD9B345896533BDDAC7829E36A77142D318F941F64234C3E9AB2D7BB1B558B31C5C53154189B1C99F303564B13629A67656C4B7DA6BAE948057FE89EB50163CD3CD9ED07BC02B26301AA51F8CE6FF0CA7610053FD2A3FB8062858414CF26776F7C3F1C907A972EBED54518D31F6434D7C50931828CA6CEF697801DBC24D89769609089ACCBB67902CB3E4BB1F22F0F2238F68926E2467DB210AE73D82A413989A51D70B4ECD9AAB85B3CF84EB072564B7F55AA49CC1D60B4CCE52EB05C667A259005955D675D8A343D4B6ED646F4AE56C198D5EC56CBDA42715AC0D812514A52D03FBE50905693EE53A312A48D395A12DF4F65679319F211FBE4CDC7F65634F9DD9DF17D2F023E736A167E0A973ECFC7B38C5AEB9F81DB2DE6A273A5F43C6400CD5C83A09D8D76699D2CE065990B5AF44EA20F561CB8076226DA5F2A79FB7A054F7F473656E4CFC8ECE553A3688C6FAA27DCF3D90AB6AB06F5A8DE66ECE49DBFC75F925FF9DF353497BEFE2794849EFFDF68F36917D271BA8EE55E8BDCB5C93D1DE45EA523E7BBB4F37642E7B69FC94B4F3B4AD2DF1DC91D2C9EC13E13B25BED626E0D8689763997A6D44CD204EB787846B9B24FFBD26DDEB730FF79D376D2ACC6133F6DF6D9AFE2113F20FA94656821D28D1DE5AA1F69C56AF6AD597FC11844AA6425AA4C5EBA5955C3CC40BBD075E89996596EBB2CD6545AB3FA1FA9E759DD4A4369B716787D560C7E31ED4A3709BDB14A4E64E31B886303A3C4ED5F87E74A43E83EF0D2A09F3B3DBD4A4F62232B8A270947824BEF9FD284B53D6DFC1D5455FC9A51620C892D49435C58D554DF98BEEC4F597E9AB5F7E39BBABAB14D21472D59580E970B56537BAE2B0CAC769290EABA12214E318169035968FE9E858D060C7B14282F5E828B0CE16F8CA942BF855978E40D5DB4281B7000A0DBE534785EFDF4B119DC46EA1BCA5A5744CAE827A93C5726D936CB84CD4E510FE9F14C369CBDEDEC4F2AD6E041A9E74BF51E81D014DE551139B2CB64C07E6D8FAC31AFEF472A90761916C65C59A91FE4CEAE20F6A18D5DBAD1C8459EA8121575AECA4AA54CD6CA33E18F77F8E53271007EB0A22CDD943D013BC2FF6CD0CADE2D20F9466547E22C5BCAF21013E75CDCE1312AC804768B70731CE2CCC37106E619A28B484FE0CDD6EC9664BE89261B40C85FF142D75269BE867A5B3E29CCF6E37D97FB037C412E83483347DE2167DDA06A1CFE67DA909D8D740A45E6AF1329CCA92A42FC4EB578674435D4B33A0827DCCB97E80D126A460F816CDC133EC32B7AF185EC135F05ECB04C57A907641886C3FBB08C03A01112E30AAF1F427D5613F7AF9F57FE2DA77467A5F0000, N'6.4.4')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9cc254bf-f3be-4170-9bda-730bebac3ef4', N'Member', N'MEMBER', N'dd1bafe3-47c0-44c6-9eb7-0036865d61f7')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd46e24e1-2f7b-4536-b5d5-194c6f557cf1', N'Admin', N'ADMIN', N'66b93aa0-ca3b-439c-8a6f-1332401d434b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3058cc75-7364-435e-bc8a-2a04ec47c912', N'9cc254bf-f3be-4170-9bda-730bebac3ef4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8bf38168-c50d-4b01-91f0-d1d148b44534', N'9cc254bf-f3be-4170-9bda-730bebac3ef4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'809f95aa-71f7-4cb4-85d6-f6158bfc449c', N'd46e24e1-2f7b-4536-b5d5-194c6f557cf1')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Voornaam], [Achternaam], [Geboortedatum], [Straat], [Huisnummer], [Postcode], [Gemeente], [Licentiecode], [Rekeningnummer], [Land]) VALUES (N'3058cc75-7364-435e-bc8a-2a04ec47c912', N'Alain', N'ALAIN', N'alain.vandoninck@gmail.com', N'ALAIN.VANDONINCK@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFbszsVK0wLgOSb/S6lP8/gQ2WZNqEiCcOFaPJI3hLM3SehNZuUXpbJa8KNoRrMQsg==', N'FQM3XX44NZGNZNNGKY5DBQTF2XI6XT7T', N'0471278d-5365-41e0-a6c7-95d7a2132aeb', NULL, 0, 0, NULL, 1, 0, N'Alain', N'Vandoninck', CAST(N'1971-01-17T00:00:00.0000000' AS DateTime2), N'Berkstraat', N'15', N'2350', N'Geel', NULL, N'BE789456123', N'België')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Voornaam], [Achternaam], [Geboortedatum], [Straat], [Huisnummer], [Postcode], [Gemeente], [Licentiecode], [Rekeningnummer], [Land]) VALUES (N'809f95aa-71f7-4cb4-85d6-f6158bfc449c', N'Dajo', N'DAJO', N'dajo.vandoninck99@gmail.com', N'DAJO.VANDONINCK99@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFogk0y15K9G9Me1pzUZpzl8LGw85fDD8qfvLiC2lOzcNZrF79cOFa1hTtC+JjiMzA==', N'UBL56HRRVSVQ5YFMS2SEFYQYDIMAEWWF', N'2bf6c084-96cf-4a35-82f4-359fd5fb4532', NULL, 0, 0, NULL, 1, 0, N'Dajo', N'Vandoninck', CAST(N'1998-10-23T00:00:00.0000000' AS DateTime2), N'Drogebroodstraat', N'27', N'2250', N'Olen', NULL, N'BE177887787999', N'België')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Voornaam], [Achternaam], [Geboortedatum], [Straat], [Huisnummer], [Postcode], [Gemeente], [Licentiecode], [Rekeningnummer], [Land]) VALUES (N'8bf38168-c50d-4b01-91f0-d1d148b44534', N'leen.francis@gmail.com', N'LEEN.FRANCIS@GMAIL.COM', N'leen.francis@gmail.com', N'LEEN.FRANCIS@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEB3MRPlHrYd1YeYYRhQ+88VvB1CgXs4ht7lTNX+BDIai0bbIGYFh77lBDUi6yuakCw==', N'YLVZO5UZCEZFWRXZKLXSMOWIM22OPNIZ', N'924eacc7-9030-4119-bda3-0e7df9e6bfc4', NULL, 0, 0, NULL, 1, 0, N'Leen', N'Francis', CAST(N'1998-10-23T00:00:00.0000000' AS DateTime2), N'Kwaadbonder ', N'5', N'3338', N'Wellen', NULL, N'BE999999999', N'België')
INSERT [dbo].[Klanten] ([PersoonID], [KlantID]) VALUES (8, 0)
INSERT [dbo].[Klanten] ([PersoonID], [KlantID]) VALUES (9, 0)
INSERT [dbo].[Klanten] ([PersoonID], [KlantID]) VALUES (10, 0)
SET IDENTITY_INSERT [dbo].[Log_Oefeningen] ON 

INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1, 6, 1)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (2, 8, 2)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (3, 2, 3)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (4, 4, 4)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (5, 3, 5)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (6, 5, 6)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (7, 2, 7)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (9, 7, 9)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (10, 6, 10)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (11, 3, 11)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1002, 4, 1002)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1007, 3, 1007)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1008, 8, 1008)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1009, 2, 1009)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1013, 4, 1013)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1014, 3, 1014)
INSERT [dbo].[Log_Oefeningen] ([Log_OefeningID], [OefeningID], [LogID]) VALUES (1015, 4, 1015)
SET IDENTITY_INSERT [dbo].[Log_Oefeningen] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1, 8, N'', N'Kaat De sutter', 1, CAST(N'2020-12-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (2, 8, N'', N'/', 0, CAST(N'2020-12-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (3, 9, N'Heel slechte dag!', N'/', 0, CAST(N'2020-12-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (4, 9, N'Spierpijn....', N'/', 0, CAST(N'2020-12-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (5, 9, N'', N'Pieter Declerq', 1, CAST(N'2020-12-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (6, 9, N'Veel bijgeleerd van Alexander!', N'Alexander Verbeeck', 1, CAST(N'2020-12-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (7, 10, N'', N'Jeff Vanhoof', 1, CAST(N'2020-12-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (9, 10, N'Ging perfect!', N'/', 0, CAST(N'2020-12-09T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (10, 10, N'', N'/', 0, CAST(N'2020-12-09T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (11, 10, N'', N'Sander Jans', 1, CAST(N'2020-12-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1002, 9, N'goed gelukt', N'Alexander Verbeeck', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1007, 9, N'Blessure', N'Alexander Verbeeck', 1, CAST(N'2021-05-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1008, 9, N'', N'Kaat De sutter', 1, CAST(N'2021-02-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1009, 9, N'', N'Nog te bepalen!', 1, CAST(N'2021-02-12T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1013, 9, N'', N'/', 0, CAST(N'2021-02-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1014, 9, N'', N'Nog te bepalen!', 1, CAST(N'2021-02-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Logs] ([LogID], [KlantID], [Review], [Trainer], [TrainerNodig], [Datum], [klant_PersoonID]) VALUES (1015, 9, N'', N'Nog te bepalen!', 1, CAST(N'2021-02-28T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Oefeningen] ON 

INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (1, NULL, NULL, N'Leg Press', N'De legpress is een samengestelde krachttraining waarbij het individu een gewicht of weerstand van zich af duwt met behulp van de benen.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (2, NULL, NULL, N'Bench press', N'Bench press is een oefening waarbij een bepaalde weerstand, een gewicht, moet worden overwonnen, liggende op een speciale bank.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (3, NULL, NULL, N'Dumbbell curls', N'Dumbbell curls is een oefening die vaak door krachtsporters zoals bij bodybuilding, powerlifting, krachttraining, fitness en andere sporten wordt gebruikt ter versterking of vergroting van vooral de biceps.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (4, NULL, NULL, N'Bicep barbell curl', N'Barbell biceps curls worden vaak met een EZ curl bar uitgevoerd. Bij deze stang staan je handen iets ...')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (5, NULL, NULL, N'Leg curl', N'De beenkrul, ook wel de hamstringspier genoemd, is een isolatieoefening die zich richt op de hamstrings. De oefening omvat het buigen van het onderbeen tegen weerstand naar de billen.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (6, NULL, NULL, N'Crunch', N'De crunch is een van de meest voorkomende buikspieroefeningen. Hij werkt vooral op de rechte buikspier.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (7, NULL, NULL, N'Chin-up', N'Optrekken, ook chin-up, pull-up, of "chin" genoemd, is een oefening om vooral de armen en de rugspieren te trainen.')
INSERT [dbo].[Oefeningen] ([OefeningID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (8, NULL, NULL, N'Push-ups', N'Opdrukken, ook wel "push-ups" genoemd, is eenzelfde soort oefening als bankdrukken. De oefening gebruikt echter alleen het eigen lichaam als weerstand.')
SET IDENTITY_INSERT [dbo].[Oefeningen] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [Orderdatum], [Leverdatum], [Betalingsdatum], [CustomUserID]) VALUES (5, CAST(N'2020-12-30T15:33:33.9031781' AS DateTime2), NULL, CAST(N'2020-12-30T15:33:33.9030681' AS DateTime2), N'809f95aa-71f7-4cb4-85d6-f6158bfc449c')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Personen] ON 

INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (1, NULL, N'Admin', N'Vandoninck', N'LLt/m9nRr9lw46d9rVKp1g==', N'fitness@admin.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (2, NULL, N'Alexander', N'Verbeeck', N'LLt/m9nRr9lw46d9rVKp1g==', N'alexander@trainer.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (3, NULL, N'Pieter', N'Declerq', N'LLt/m9nRr9lw46d9rVKp1g==', N'pieter@trainer.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (4, NULL, N'Jordi', N'Verloy', N'LLt/m9nRr9lw46d9rVKp1g==', N'jordi@trainer.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (5, NULL, N'Kaat', N'De sutter', N'LLt/m9nRr9lw46d9rVKp1g==', N'kaat@dieet.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (6, NULL, N'Jeff', N'Vanhoof', N'LLt/m9nRr9lw46d9rVKp1g==', N'jeff@trainer.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (7, NULL, N'Sander', N'Jans', N'LLt/m9nRr9lw46d9rVKp1g==', N'sander@trainer.com', NULL, NULL, NULL, NULL)
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (8, 0x453A5C50696374757265735C43616D6572615C494D475F393533382E4A5047, N'Leen', N'Francis', N'B6vsq1oNuye6k3w1ZBHjfQ==', N'francisleen1999@gmail.com', N'Kwaadbonder 5', N'3830', N'Wellen', N'België')
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (9, 0x453A5C50696374757265735C44616A6F5C494D475F303039322E4A5047, N'Dajo', N'Vandoninck', N'x5sdgF4mm7EBKeDdMzj+CA==', N'dajo.vandoninck99@gmail.com', N'Drogebroodstraat 27', N'2250', N'Olen', N'België')
INSERT [dbo].[Personen] ([PersoonID], [Profielfoto], [Voornaam], [Achternaam], [Wachtwoord], [Email], [Adres], [Postcode], [Gemeente], [Land]) VALUES (10, 0x453A5C50696374757265735C44616A6F5C454A4A51393331332E4A5047, N'Sander', N'Kelchtermans', N'dpcSEYvxGVCSQIQ3GyUSdw==', N'sanderpatat@gmail.com', N'Daalstraat 7', N'6543', N'Gruitrode', N'België')
SET IDENTITY_INSERT [dbo].[Personen] OFF
SET IDENTITY_INSERT [dbo].[Producten] ON 

INSERT [dbo].[Producten] ([ProductID], [Naam], [Omschrijving], [Licentiecode], [Prijs]) VALUES (1, N'Comfort', N'"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', N'COM', CAST(19.00 AS Decimal(8, 2)))
INSERT [dbo].[Producten] ([ProductID], [Naam], [Omschrijving], [Licentiecode], [Prijs]) VALUES (2, N'Premium', N'"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', N'PREM', CAST(29.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Producten] OFF
SET IDENTITY_INSERT [dbo].[Reserveringen] ON 

INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1, CAST(N'2020-12-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-25T17:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (2, CAST(N'1998-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-25T03:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (3, CAST(N'2020-11-18T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-25T18:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (4, CAST(N'0001-01-17T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-25T00:03:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (5, CAST(N'0001-01-03T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-25T04:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (6, CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-26T12:15:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (7, CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-08T18:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1002, CAST(N'2020-01-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T15:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1003, CAST(N'2020-01-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T15:00:00.0000000' AS DateTime2), 30)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1004, CAST(N'2022-02-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T03:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1005, CAST(N'2022-02-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T03:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1006, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T15:00:00.0000000' AS DateTime2), 55)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1007, CAST(N'2021-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T15:00:00.0000000' AS DateTime2), 55)
INSERT [dbo].[Reserveringen] ([ReserveringID], [Datum], [Tijdstip], [Tijdsduur]) VALUES (1008, CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-28T15:00:00.0000000' AS DateTime2), 55)
SET IDENTITY_INSERT [dbo].[Reserveringen] OFF
SET IDENTITY_INSERT [dbo].[Tijdslots] ON 

INSERT [dbo].[Tijdslots] ([TijdslotID], [ReserveringID], [CustomUserID]) VALUES (3, 5, N'809f95aa-71f7-4cb4-85d6-f6158bfc449c')
INSERT [dbo].[Tijdslots] ([TijdslotID], [ReserveringID], [CustomUserID]) VALUES (1006, 1008, N'8bf38168-c50d-4b01-91f0-d1d148b44534')
SET IDENTITY_INSERT [dbo].[Tijdslots] OFF
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (2, 1, N'Personal Trainer', N'Legs')
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (3, 2, N'Personal Trainer', N'Triceps')
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (4, 3, N'Personal Trainer', N'Biceps')
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (5, 4, N'Dieet Trainer', N'Dieet')
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (6, 5, N'Personal Trainer', N'Schouder')
INSERT [dbo].[Trainers] ([PersoonID], [TrainerID], [Functie], [Specialisatie]) VALUES (7, 6, N'Personal Trainer', N'Knie')
INSERT [dbo].[Werkgevers] ([PersoonID], [WerkgeverID], [IsAdmin]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[Workouts] ON 

INSERT [dbo].[Workouts] ([WorkoutID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (2, N'https://www.youtube.com/watch?v=oAPCPjnU1wA', NULL, N'20 MINUTE FULL BODY WORKOUT', NULL)
INSERT [dbo].[Workouts] ([WorkoutID], [Videolink], [Afbeelding], [Naam], [Omschrijving]) VALUES (3, N'https://www.youtube.com/watch?v=GVZZi-Gth_M', NULL, N'8 MIN STRETCH FOR SPLITS', NULL)
SET IDENTITY_INSERT [dbo].[Workouts] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/01/2021 21:35:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/01/2021 21:35:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Items_OrderID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_Items_OrderID] ON [dbo].[Items]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Items_ProductID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_Items_ProductID] ON [dbo].[Items]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersoonID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_PersoonID] ON [dbo].[Klanten]
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LogID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_LogID] ON [dbo].[Log_Oefeningen]
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OefeningID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_OefeningID] ON [dbo].[Log_Oefeningen]
(
	[OefeningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_klant_PersoonID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_klant_PersoonID] ON [dbo].[Logs]
(
	[klant_PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_CustomUserID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CustomUserID] ON [dbo].[Orders]
(
	[CustomUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tijdslots_CustomUserID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tijdslots_CustomUserID] ON [dbo].[Tijdslots]
(
	[CustomUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tijdslots_ReserveringID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tijdslots_ReserveringID] ON [dbo].[Tijdslots]
(
	[ReserveringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersoonID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_PersoonID] ON [dbo].[Trainers]
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersoonID]    Script Date: 2/01/2021 21:35:59 ******/
CREATE NONCLUSTERED INDEX [IX_PersoonID] ON [dbo].[Werkgevers]
(
	[PersoonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Orders_OrderID]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Producten_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Producten] ([ProductID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Producten_ProductID]
GO
ALTER TABLE [dbo].[Klanten]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Klanten_dbo.Personen_PersoonID] FOREIGN KEY([PersoonID])
REFERENCES [dbo].[Personen] ([PersoonID])
GO
ALTER TABLE [dbo].[Klanten] CHECK CONSTRAINT [FK_dbo.Klanten_dbo.Personen_PersoonID]
GO
ALTER TABLE [dbo].[Log_Oefeningen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Log_Oefeningen_dbo.Logs_LogID] FOREIGN KEY([LogID])
REFERENCES [dbo].[Logs] ([LogID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Log_Oefeningen] CHECK CONSTRAINT [FK_dbo.Log_Oefeningen_dbo.Logs_LogID]
GO
ALTER TABLE [dbo].[Log_Oefeningen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Log_Oefeningen_dbo.Oefeningen_OefeningID] FOREIGN KEY([OefeningID])
REFERENCES [dbo].[Oefeningen] ([OefeningID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Log_Oefeningen] CHECK CONSTRAINT [FK_dbo.Log_Oefeningen_dbo.Oefeningen_OefeningID]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Logs_dbo.Klanten_klant_PersoonID] FOREIGN KEY([klant_PersoonID])
REFERENCES [dbo].[Klanten] ([PersoonID])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_dbo.Logs_dbo.Klanten_klant_PersoonID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_CustomUserID] FOREIGN KEY([CustomUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_CustomUserID]
GO
ALTER TABLE [dbo].[Tijdslots]  WITH CHECK ADD  CONSTRAINT [FK_Tijdslots_AspNetUsers_CustomUserID] FOREIGN KEY([CustomUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Tijdslots] CHECK CONSTRAINT [FK_Tijdslots_AspNetUsers_CustomUserID]
GO
ALTER TABLE [dbo].[Tijdslots]  WITH CHECK ADD  CONSTRAINT [FK_Tijdslots_Reserveringen_ReserveringID] FOREIGN KEY([ReserveringID])
REFERENCES [dbo].[Reserveringen] ([ReserveringID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tijdslots] CHECK CONSTRAINT [FK_Tijdslots_Reserveringen_ReserveringID]
GO
ALTER TABLE [dbo].[Trainers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Trainers_dbo.Personen_PersoonID] FOREIGN KEY([PersoonID])
REFERENCES [dbo].[Personen] ([PersoonID])
GO
ALTER TABLE [dbo].[Trainers] CHECK CONSTRAINT [FK_dbo.Trainers_dbo.Personen_PersoonID]
GO
ALTER TABLE [dbo].[Werkgevers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Werkgevers_dbo.Personen_PersoonID] FOREIGN KEY([PersoonID])
REFERENCES [dbo].[Personen] ([PersoonID])
GO
ALTER TABLE [dbo].[Werkgevers] CHECK CONSTRAINT [FK_dbo.Werkgevers_dbo.Personen_PersoonID]
GO
USE [master]
GO
ALTER DATABASE [PR_r0675759] SET  READ_WRITE 
GO
