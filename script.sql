USE [Apply]
GO
/****** Object:  Table [dbo].[acount_plan]    Script Date: 20.12.2017 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acount_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[price] [decimal](18, 0) NULL,
	[descriptin] [nvarchar](max) NULL,
 CONSTRAINT [PK_acount_plan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Acount_value]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acount_value](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NULL,
	[acount_plan_id] [int] NULL,
	[data-icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_Acount_value] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adm_User]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adm_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NULL,
	[email] [nvarchar](150) NULL,
	[password] [nvarchar](500) NULL,
	[user_level] [int] NULL,
	[photo] [nvarchar](250) NULL,
 CONSTRAINT [PK_Adm_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bugdet]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bugdet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[max-budget] [decimal](19, 4) NULL,
	[min-budget] [decimal](19, 4) NULL,
 CONSTRAINT [PK_Bugdet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[citizinship]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[citizinship](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[citizinship] [nvarchar](50) NULL,
 CONSTRAINT [PK_citizinship] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country_id] [int] NULL,
	[city_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[topic_id] [int] NULL,
	[message] [ntext] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[degree_level]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[degree_level](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[level] [nvarchar](50) NULL,
	[value] [int] NULL,
 CONSTRAINT [PK_degree_level] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faq]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faq](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[descripition] [nvarchar](max) NULL,
 CONSTRAINT [PK_Faq] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journey]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Journey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lang_name] [nvarchar](50) NULL,
	[profiency_id] [int] NULL,
	[test_type_id] [int] NULL,
	[score] [int] NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lastest_post]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lastest_post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[photo] [nvarchar](250) NULL,
	[title] [nvarchar](150) NULL,
	[category_id] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_lastest_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pay_method]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pay_method](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Pay_method] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[card_name] [nvarchar](50) NULL,
	[card_number] [int] NULL,
	[cvn_number] [int] NULL,
	[date] [date] NULL,
	[pay_method_id] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_galery]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_galery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](250) NULL,
	[photo] [nvarchar](250) NOT NULL,
	[description] [nvarchar](max) NULL,
	[type_id] [int] NULL,
 CONSTRAINT [PK_post_galery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profiency]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profiency](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[profiency_level] [nvarchar](150) NULL,
 CONSTRAINT [PK_profiency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rank_to_rait]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rank_to_rait](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[raiting_id] [int] NULL,
	[ranking_id] [int] NULL,
 CONSTRAINT [PK_rank_to_rait] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ranking_rating]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ranking_rating](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rate] [decimal](11, 4) NULL,
 CONSTRAINT [PK_ranking_rating] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[referance]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[referance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref_firstname] [nvarchar](50) NULL,
	[ref_lastname] [nvarchar](50) NULL,
	[ref_email] [nvarchar](150) NULL,
	[ref_Phone] [nvarchar](50) NULL,
	[ref_relation] [nvarchar](250) NULL,
	[essasy] [ntext] NULL,
 CONSTRAINT [PK_referance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SameDate]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SameDate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logo] [nvarchar](250) NULL,
	[facebook] [nvarchar](150) NULL,
	[linkedin] [nvarchar](150) NULL,
	[twitter] [nvarchar](150) NULL,
	[google] [nvarchar](150) NULL,
	[instagram] [nvarchar](150) NULL,
	[phone] [nvarchar](150) NULL,
	[location] [nvarchar](150) NULL,
 CONSTRAINT [PK_SameDate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[study_field]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[study_field](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_study_field] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[study_field_uni]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[study_field_uni](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uni_id] [int] NULL,
	[study_field_id] [int] NULL,
 CONSTRAINT [PK_study_field_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[study_program]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[study_program](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[program_name] [nvarchar](150) NULL,
	[program_fee] [nvarchar](150) NULL,
	[field_id] [int] NULL,
 CONSTRAINT [PK_study_program] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_type]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Test_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[topic_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_blog]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_blog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uni_date]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uni_date](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[graduate_date] [date] NULL,
	[start_date] [date] NULL,
 CONSTRAINT [PK_uni_date] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uni_detail]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uni_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[average_tution] [nvarchar](150) NULL,
	[accept_rate] [decimal](19, 9) NULL,
	[scholorship] [int] NULL,
	[student_fac_retio] [int] NULL,
	[information] [ntext] NULL,
 CONSTRAINT [PK_Uni_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uni_fact]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uni_fact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[point] [int] NULL,
 CONSTRAINT [PK_Uni_fact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uni_ranking]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uni_ranking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ranking_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_Uni_ranking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[University]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[University](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NULL,
	[detail_id] [int] NULL,
	[fact_id] [int] NULL,
	[rank_to_rate_id] [int] NULL,
	[uni_date_id] [int] NULL,
 CONSTRAINT [PK_University] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_finance_plan]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_finance_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[plan_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_finance_plan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](500) NULL,
	[birthday] [date] NULL,
	[phone] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[user_country_id] [int] NULL,
	[study_field_id] [int] NULL,
	[user_study_cont_id] [int] NULL,
	[degree_level_id] [int] NULL,
	[finance_plan_id] [int] NULL,
	[budget_id] [int] NULL,
	[citizinship_id] [int] NULL,
	[adress] [nvarchar](150) NULL,
	[postcode] [nvarchar](150) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsrLevel]    Script Date: 20.12.2017 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsrLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[level_name] [nchar](10) NULL,
 CONSTRAINT [PK_UsrLevel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Acount_value]  WITH CHECK ADD  CONSTRAINT [FK_Acount_value_acount_plan] FOREIGN KEY([acount_plan_id])
REFERENCES [dbo].[acount_plan] ([id])
GO
ALTER TABLE [dbo].[Acount_value] CHECK CONSTRAINT [FK_Acount_value_acount_plan]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_UsrLevel] FOREIGN KEY([user_level])
REFERENCES [dbo].[UsrLevel] ([id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_UsrLevel]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Topic] FOREIGN KEY([topic_id])
REFERENCES [dbo].[Topic] ([id])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Topic]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_profiency] FOREIGN KEY([profiency_id])
REFERENCES [dbo].[profiency] ([id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_profiency]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_Test_type] FOREIGN KEY([test_type_id])
REFERENCES [dbo].[Test_type] ([id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_Test_type]
GO
ALTER TABLE [dbo].[lastest_post]  WITH CHECK ADD  CONSTRAINT [FK_lastest_post_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[lastest_post] CHECK CONSTRAINT [FK_lastest_post_Category]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_method] FOREIGN KEY([pay_method_id])
REFERENCES [dbo].[Pay_method] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_method]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Users1] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Users1]
GO
ALTER TABLE [dbo].[post_galery]  WITH CHECK ADD  CONSTRAINT [FK_post_galery_Type] FOREIGN KEY([type_id])
REFERENCES [dbo].[Type_blog] ([id])
GO
ALTER TABLE [dbo].[post_galery] CHECK CONSTRAINT [FK_post_galery_Type]
GO
ALTER TABLE [dbo].[rank_to_rait]  WITH CHECK ADD  CONSTRAINT [FK_rank_to_rait_ranking_rating] FOREIGN KEY([raiting_id])
REFERENCES [dbo].[ranking_rating] ([id])
GO
ALTER TABLE [dbo].[rank_to_rait] CHECK CONSTRAINT [FK_rank_to_rait_ranking_rating]
GO
ALTER TABLE [dbo].[rank_to_rait]  WITH CHECK ADD  CONSTRAINT [FK_rank_to_rait_Uni_ranking] FOREIGN KEY([ranking_id])
REFERENCES [dbo].[Uni_ranking] ([id])
GO
ALTER TABLE [dbo].[rank_to_rait] CHECK CONSTRAINT [FK_rank_to_rait_Uni_ranking]
GO
ALTER TABLE [dbo].[study_field_uni]  WITH CHECK ADD  CONSTRAINT [FK_study_field_uni_study_field] FOREIGN KEY([study_field_id])
REFERENCES [dbo].[study_field] ([id])
GO
ALTER TABLE [dbo].[study_field_uni] CHECK CONSTRAINT [FK_study_field_uni_study_field]
GO
ALTER TABLE [dbo].[study_field_uni]  WITH CHECK ADD  CONSTRAINT [FK_study_field_uni_University] FOREIGN KEY([uni_id])
REFERENCES [dbo].[University] ([id])
GO
ALTER TABLE [dbo].[study_field_uni] CHECK CONSTRAINT [FK_study_field_uni_University]
GO
ALTER TABLE [dbo].[study_program]  WITH CHECK ADD  CONSTRAINT [FK_study_program_study_field] FOREIGN KEY([field_id])
REFERENCES [dbo].[study_field] ([id])
GO
ALTER TABLE [dbo].[study_program] CHECK CONSTRAINT [FK_study_program_study_field]
GO
ALTER TABLE [dbo].[University]  WITH CHECK ADD  CONSTRAINT [FK_University_rank_to_rait] FOREIGN KEY([rank_to_rate_id])
REFERENCES [dbo].[rank_to_rait] ([id])
GO
ALTER TABLE [dbo].[University] CHECK CONSTRAINT [FK_University_rank_to_rait]
GO
ALTER TABLE [dbo].[University]  WITH CHECK ADD  CONSTRAINT [FK_University_uni_date] FOREIGN KEY([uni_date_id])
REFERENCES [dbo].[uni_date] ([id])
GO
ALTER TABLE [dbo].[University] CHECK CONSTRAINT [FK_University_uni_date]
GO
ALTER TABLE [dbo].[University]  WITH CHECK ADD  CONSTRAINT [FK_University_Uni_detail] FOREIGN KEY([detail_id])
REFERENCES [dbo].[Uni_detail] ([id])
GO
ALTER TABLE [dbo].[University] CHECK CONSTRAINT [FK_University_Uni_detail]
GO
ALTER TABLE [dbo].[University]  WITH CHECK ADD  CONSTRAINT [FK_University_Uni_fact] FOREIGN KEY([fact_id])
REFERENCES [dbo].[Uni_fact] ([id])
GO
ALTER TABLE [dbo].[University] CHECK CONSTRAINT [FK_University_Uni_fact]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Bugdet] FOREIGN KEY([budget_id])
REFERENCES [dbo].[Bugdet] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Bugdet]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_citizinship] FOREIGN KEY([citizinship_id])
REFERENCES [dbo].[citizinship] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_citizinship]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Country] FOREIGN KEY([user_country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Country]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Country1] FOREIGN KEY([user_study_cont_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Country1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_degree_level] FOREIGN KEY([degree_level_id])
REFERENCES [dbo].[degree_level] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_degree_level]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_study_field] FOREIGN KEY([study_field_id])
REFERENCES [dbo].[study_field] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_study_field]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_user_finance_plan] FOREIGN KEY([finance_plan_id])
REFERENCES [dbo].[user_finance_plan] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_user_finance_plan]
GO
