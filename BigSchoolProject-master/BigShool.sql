GO
/****** Object: Table [dbo].[Category] Script Date: 03/23/2022 09:57:11
******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
[Id] [int] NOT NULL,
[Name] [nvarchar](255) NOT NULL,
CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =
OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
[Id] [int] IDENTITY(1,1) NOT NULL,
[LecturerId] [nvarchar](128) NOT NULL,
[Place] [nvarchar](255) NOT NULL,
[DateTime] [datetime] NOT NULL,
[CategoryId] [int] NOT NULL,
CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =
OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: ForeignKey [FK_Course_AspNetUsers] Script Date:
03/23/2022 09:57:11 ******/
ALTER TABLE [dbo].[Course] WITH CHECK ADD CONSTRAINT
[FK_Course_AspNetUsers] FOREIGN KEY([LecturerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_AspNetUsers]
GO
/****** Object: ForeignKey [FK_Course_Category] Script Date:
03/23/2022 09:57:11 ******/
ALTER TABLE [dbo].[Course] WITH CHECK ADD CONSTRAINT
[FK_Course_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Category]
GO
